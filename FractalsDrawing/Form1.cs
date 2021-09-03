using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalsDrawing
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Bitmap backBuffer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backBuffer = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(backBuffer);

            canvas.BackColor = Color.CornflowerBlue;

            DrawTree(x:Width / 2, y: Height, width: 0, height: -80, angle: 8, branchNumber: 0, numberOfBranches: 15);
            canvas.Image = backBuffer;
        }

        private void DrawTree(int x, int y, decimal width, decimal height, int angle, int branchNumber, int numberOfBranches)
        {

            Pen pen = new Pen(Brushes.White, 2);

            graphics.DrawLine(pen, x, y, (float)(x + width), (float)(y + height));

            if (branchNumber >= numberOfBranches)
            {
                return;
            }

            double angleInRadians = (double)(angle * (decimal)(Math.PI / 180f));

            decimal newWidth = (height * (decimal)Math.Sin(angleInRadians));
            decimal newHeight = (height * (decimal)Math.Cos(angleInRadians));

            int newX = (int)width;
            int newY = (int)height;

            branchNumber++;
            DrawTree(x + newX, y + newY, newWidth, newHeight, angle + angle, branchNumber, numberOfBranches);

            newWidth = -newWidth;
            branchNumber++;
            DrawTree(x + newX, y + newY, newWidth, newHeight, angle + angle, branchNumber, numberOfBranches);
        }
    }
}
