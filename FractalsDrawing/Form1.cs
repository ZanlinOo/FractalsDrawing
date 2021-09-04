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

            DrawTree(Width / 2, Height, -50, -1, 0, 20, 0, 8);
            canvas.Image = backBuffer;
        }
        private void DrawTree(float x, float y, float branchLength, float decreaseBranchLengthBy, float angle, int incrementAngleBy, int branchNumber, int numberOfBranches)
        {
            Pen pen = new Pen(Brushes.White, 2);

            double angleInRadians = (double)(angle * (Math.PI / 180f));
            float x2 = (float)(branchLength * Math.Sin(angleInRadians));
            float y2 = (float)(branchLength * Math.Cos(angleInRadians));

            graphics.DrawLine(pen, x, y, x + x2, y + y2);

            if (branchNumber >= numberOfBranches)
            {
                return;
            }

            branchNumber++;
            DrawTree(x + x2, y + y2, branchLength - decreaseBranchLengthBy, decreaseBranchLengthBy, angle + incrementAngleBy, incrementAngleBy, branchNumber, numberOfBranches);

            DrawTree(x + x2, y + y2, branchLength - decreaseBranchLengthBy, decreaseBranchLengthBy, angle - incrementAngleBy, incrementAngleBy, branchNumber, numberOfBranches);

        }
       
    }
}
