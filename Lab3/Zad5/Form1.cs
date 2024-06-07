using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zad5
{
    public partial class Form1 : Form
    {
        [DllImport("gdi32.dll", EntryPoint = "MoveToEx")]
        private static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);

        [DllImport("gdi32.dll", EntryPoint = "LineTo")]
        private static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RysujSinusoide();
        }

        private void RysujSinusoide()
        {
            IntPtr hdc = GetDC(this.Handle);

            if (hdc != IntPtr.Zero)
            {
                int szerokosc = this.ClientSize.Width;
                int wysokosc = this.ClientSize.Height;
                int srodekY = wysokosc / 2;

                MoveToEx(hdc, 0, srodekY, IntPtr.Zero);

                for (int i = 0; i < szerokosc; i++)
                {
                    int x = i;
                    int y = (int)(srodekY - (Math.Sin(i * 2 * Math.PI / szerokosc) * 100)); 
                    LineTo(hdc, x, y);
                }

                ReleaseDC(this.Handle, hdc);
            }
        }
    }
}
