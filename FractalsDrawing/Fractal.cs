using System;
using System.Drawing;

namespace FractalsDrawing
{
    public class FractalTree
    {
        private Point location;
        private Point branchLocation;
        private int width;
        private int height;
        private int angle;
        private int numberOfBranches;
        private int currentBranch;
        private Brush brushColor;

        public FractalTree(Point location, int width, int height, int angle, int numberOfBranches, Color color)
        {
            this.location = location;
            branchLocation = location;

            this.width = width;
            this.height = height;
            this.angle = angle;
            this.numberOfBranches = numberOfBranches;
            this.brushColor = new SolidBrush(color);
        }

        private void UpdateRectangle()
        {
            int newX = (int)(height * Math.Cos(branchLocation.X));
            int newY = (int)(height * Math.Sin(branchLocation.Y));

            branchLocation = new Point(newX, newY);

        }

        public void Draw(Graphics graphics)
        {
            if (currentBranch >= numberOfBranches)
            {
                return;
            }
            graphics.FillRectangle(brushColor, branchLocation.X, branchLocation.Y, width, height);

            UpdateRectangle();

            currentBranch++;
            Draw(graphics);
        }
    }
}