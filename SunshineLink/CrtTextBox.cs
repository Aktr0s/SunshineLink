using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sun6502IDE
{
    // TextBox that paints CRT-style scanlines over itself.
    public class CrtTextBox : TextBox
    {
        private const int WM_PAINT = 0x000F;
        private const int WM_SETTEXT = 0x000C;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int EM_SCROLL = 0x00B5;
        private const int EM_LINESCROLL = 0x00B6;
        private const int EM_SCROLLCARET = 0x00B7;
        private const int EM_REPLACESEL = 0x00C2;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int Left, Top, Right, Bottom; }

        [DllImport("user32.dll")]
        private static extern bool GetUpdateRect(IntPtr hWnd, out RECT rect, bool erase);

        private bool scanlines = true;
        private int period = 3;
        private int strength = 90;
        private bool broken;       // set if user32 is unavailable (Mono/Linux): effect is just skipped

        [Category("CRT"), DefaultValue(true)]
        public bool Scanlines
        {
            get { return scanlines; }
            set { scanlines = value; Invalidate(); }
        }

        [Category("CRT"), DefaultValue(3), Description("Pixels between scanlines (2 = dense, 4 = subtle)")]
        public int ScanlinePeriod
        {
            get { return period; }
            set { period = value < 2 ? 2 : value; Invalidate(); }
        }

        [Category("CRT"), DefaultValue(90), Description("Scanline darkness 0-255")]
        public int ScanlineStrength
        {
            get { return strength; }
            set { strength = value < 0 ? 0 : (value > 255 ? 255 : value); Invalidate(); }
        }

        protected override void WndProc(ref Message m)
        {
            int msg = m.Msg;

            if (msg == WM_PAINT && scanlines && !broken && IsHandleCreated)
            {
                RECT r = new RECT();
                bool has = false;
                try { has = GetUpdateRect(Handle, out r, false); }
                catch (Exception) { broken = true; }

                base.WndProc(ref m);
                if (has) DrawScanlines(r);
                return;
            }

            base.WndProc(ref m);

            // Scrolling moves already-painted pixels (with their scanlines) - repaint fully
            if (scanlines && !broken &&
                (msg == WM_VSCROLL || msg == WM_MOUSEWHEEL || msg == EM_SCROLL ||
                 msg == EM_LINESCROLL || msg == EM_SCROLLCARET || msg == EM_REPLACESEL || msg == WM_SETTEXT))
            {
                Invalidate();
            }
        }

        private void DrawScanlines(RECT r)
        {
            int w = r.Right - r.Left;
            if (w <= 0 || r.Bottom <= r.Top) return;

            using (Graphics g = CreateGraphics())
            using (SolidBrush b = new SolidBrush(Color.FromArgb(strength, 0, 0, 0)))
            {
                for (int y = r.Top - (r.Top % period); y < r.Bottom; y += period)
                {
                    int ly = y + period - 1;
                    if (ly >= r.Top && ly < r.Bottom)
                        g.FillRectangle(b, r.Left, ly, w, 1);
                }
            }
        }
    }
}