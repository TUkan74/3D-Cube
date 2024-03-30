using System;
using System.Numerics;
using System.Windows.Forms;
using System.Drawing;

namespace Cube_Render
{


    public partial class Form1 : Form
    {
        private double angleX = 0;
        private double angleY = 35;
        private double angleZ = 0;

        private double rotationSpeed = 3 * Math.PI / 180; // Rotate 1 degree per tick
        private Cube myCube = new Cube(100);
        private bool isRotating = true;
        private double distance = 500;
        public bool drawSides = false;
        public bool drawLines = true;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Tick += (s, ev) =>
            {
                if (isRotating)
                {
                    UpdateCubeRotation();
                    this.Invalidate();  // This will cause the form to be redrawn
                }
            };
            timer1.Start();
        }
        



        /// <summary>
        /// Override ProcessCmdKey to make the form detect key presses
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    return true;

                case Keys.Enter:
                    isRotating = !isRotating; // Toggle the rotation status
                    checkBox1.Checked = true;
                    return true;

                case Keys.Down:
                    numericUpDown1.Value -= 1;
                    this.Invalidate(); // Redraw after changing distance
                    return true;

                case Keys.Up:
                    numericUpDown1.Value += 1;
                    this.Invalidate(); // Redraw after changing distance
                    return true;

                case Keys.W: // Rotate around X axis (Tilt up)
                    angleX -= rotationSpeed;
                    this.Invalidate();
                    return true;

                case Keys.S: // Rotate around X axis (Tilt down)
                    angleX += rotationSpeed;
                    this.Invalidate();
                    return true;

                case Keys.A: // Rotate around Y axis (Turn left)
                    angleY += rotationSpeed;
                    this.Invalidate();
                    return true;

                case Keys.D: // Rotate around Y axis (Turn right)
                    angleY -= rotationSpeed;
                    this.Invalidate();
                    return true;

                case Keys.R:
                    button1.PerformClick();
                    break;

                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Currently empty as we're handling the key presses in ProcessCmdKey
        }


        /// <summary>
        /// Initialize whole Draw cube process, after the form has been cleared
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            myCube.DrawCube(e.Graphics, angleX, angleY, angleZ, distance, 1f, this.Width, this.Height, drawSides, drawLines);
        }

        /// <summary>
        /// Update all angles accordning to current intended rotation
        /// </summary>
        private void UpdateCubeRotation()
        {
            angleX += rotationSpeed;
            angleY += rotationSpeed;
            angleZ += rotationSpeed;

            // Wrap around after full rotation (this step is optional but ensures angle values don't become too large)
            if (angleX >= 2 * Math.PI) angleX -= 2 * Math.PI;
            if (angleY >= 2 * Math.PI) angleY -= 2 * Math.PI;
            if (angleZ >= 2 * Math.PI) angleZ -= 2 * Math.PI;
        }

        /// <summary>
        /// This checkbox handles whether the cube should rotate automatically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isRotating = true;
                rotationSpeed = 1.5 * Math.PI / 180;
            }
            else
            {
                isRotating = false;
                rotationSpeed = 3 * Math.PI / 180;
            }
        }

        /// <summary>
        /// When this button is pressed, the cube will be reset to starting postition, and the rotation speed will be reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            angleX = 0;
            angleY = 35;
            angleZ = 0;
            numericUpDown1.Value = 1;

            this.Invalidate();
        }

        /// <summary>
        /// Changing speed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Convert the decimal value of the Numeric Up Down control to a double
            double newValue = Convert.ToDouble(numericUpDown1.Value);

            // Use the new value to adjust the rotation speed
            rotationSpeed = newValue * Math.PI / 180;

            
            this.Invalidate();
        }


        /// <summary>
        /// Whether or not lines should be created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                drawLines = true;
                this.Invalidate();
            }
            else
            {
                drawLines = false;
                this.Invalidate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }




    /// <summary>
    /// CUBE CLASS, all of the methods relating to the cube are stored here(rotation,projection,drawing), as well as its coordinates
    /// </summary>


    public class Cube
    {
        public float[,] Dots = new float[8, 3];
        private int Height, Width;
        private bool sides;
        private bool lines;

        public Cube(int size)
        {
            //initialize the cube coordinates, based on user input of the size of the cube
            int coor = size / 2;


            Dots[0, 0] = coor; Dots[0, 1] = coor; Dots[0, 2] = -coor;
            Dots[1, 0] = -coor; Dots[1, 1] = coor; Dots[1, 2] = -coor;
            Dots[2, 0] = -coor; Dots[2, 1] = coor; Dots[2, 2] = coor;
            Dots[3, 0] = coor; Dots[3, 1] = coor; Dots[3, 2] = coor;
            Dots[4, 0] = coor; Dots[4, 1] = -coor; Dots[4, 2] = -coor;
            Dots[5, 0] = -coor; Dots[5, 1] = -coor; Dots[5, 2] = -coor;
            Dots[6, 0] = -coor; Dots[6, 1] = -coor; Dots[6, 2] = coor;
            Dots[7, 0] = coor; Dots[7, 1] = -coor; Dots[7, 2] = coor;
        }

        /// <summary>
        /// method used for multiplying matricies
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private double[,] MultiplyMatrices(double[,] A, double[,] B)
        {
            int A_rows = A.GetLength(0);
            int A_cols = A.GetLength(1);

            int B_rows = B.GetLength(0);
            int B_cols = B.GetLength(1);

            double[,] result = new double[A_rows, B_cols];

            if (A_rows == B_rows)
            {
                for (int i = 0; i < A_rows; i++)
                {
                    for (int j = 0; j < B_cols; j++)
                    {
                        for (int k = 0; k < B_rows; k++)
                        {
                            result[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
            }
            else
            {
                //if the multiplication cant happen, it will throw an exeption
                throw new InvalidOperationException("Matrix dimensions do not match for multiplication.");
            }

            return result;
        }

        /// <summary>
        /// method to project the rotated coordinates from 3D onto 2D plane
        /// </summary>
        /// <param name="currentCube"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        private double[,] Project(double[,] currentCube, double distance)
        {
            double[,] projectedCube = new double[8, 2]; // Only need X and Y for projection
            for (int i = 0; i < 8; i++)
            {
                projectedCube[i, 0] = distance * (currentCube[i, 0] / (currentCube[i, 2] + distance));
                projectedCube[i, 1] = distance * (currentCube[i, 1] / (currentCube[i, 2] + distance));
            }
            return projectedCube;

        }

        /// <summary>
        /// method to rotate the cube with private matricies
        /// </summary>
        /// <param name="angle_x"></param>
        /// <param name="angle_y"></param>
        /// <param name="angle_z"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public double[,] Rotate(double angle_x, double angle_y, double angle_z, double distance)
        {
            double[,] rotatedCube = new double[8, 3];
            double[,] resultCube = new double[8, 3];

            //matricies for rotating the cube in all dimenstions
            double[,] rotation_x =
            {
                { 1, 0, 0 },
                { 0, Math.Cos(angle_x), -Math.Sin(angle_x) },
                { 0, Math.Sin(angle_x), Math.Cos(angle_x) }
            };

            double[,] rotation_y =
            {
                { Math.Cos(angle_y), 0, Math.Sin(angle_y) },
                { 0, 1, 0 },
                { -Math.Sin(angle_y), 0, Math.Cos(angle_y) }
            };


            double[,] rotation_z =
            {
                { Math.Cos(angle_z), -Math.Sin(angle_z), 0 },
                { Math.Sin(angle_z), Math.Cos(angle_z), 0 },
                { 0, 0, 1 }
            };

            //rotating the cube
            for (int i = 0; i < 8; i++)
            {
                // Convert each Dot into a 3x1 matrix for multiplication
                double[,] point = new double[3, 1]
                {
                { Dots[i, 0] },
                { Dots[i, 1] },
                { Dots[i, 2] }
                };

                // Multiply by rotation matrices
                double[,] Rotate_X = MultiplyMatrices(rotation_x, point);
                double[,] Rotate_Y = MultiplyMatrices(rotation_y, Rotate_X);
                double[,] Rotate_Z = MultiplyMatrices(rotation_z, Rotate_Y);

                // Assign rotated coordinates back to the rotatedCube
                rotatedCube[i, 0] = Rotate_Z[0, 0];
                rotatedCube[i, 1] = Rotate_Z[1, 0];
                rotatedCube[i, 2] = Rotate_Z[2, 0];
            }

            resultCube = Project(rotatedCube, distance);

            return resultCube;
        }


        /// <summary>
        /// Method to draw the cube, it is the main method that handles other method that draw lines or sides
        /// </summary>
        /// <param name="g"></param>
        /// <param name="angle_x"></param>
        /// <param name="angle_y"></param>
        /// <param name="angle_z"></param>
        /// <param name="distance"></param>
        /// <param name="scale"></param>
        /// <param name="WINDOW_SIZE_WIDTH"></param>
        /// <param name="WINDOW_SIZE_HEIGHT"></param>
        /// <param name="drawSides"></param>
        /// <param name="drawLines"></param>
        /// 
        public void DrawCube(Graphics g, double angle_x, double angle_y, double angle_z, double distance, float scale, int WINDOW_SIZE_WIDTH, int WINDOW_SIZE_HEIGHT, bool drawSides, bool drawLines)
        {
            sides = drawSides;
            lines = drawLines;

            double[,] projectedCube = Rotate(angle_x, angle_y, angle_z, distance);

            //size of the form window
            Height = WINDOW_SIZE_HEIGHT;
            Width = WINDOW_SIZE_WIDTH;

            // Pairs of indices representing the edges of the cube
            if (sides)
            {

            }
            if (lines)
            {
                DrawLinesOnly(g, projectedCube);
            }
            if (lines && sides)
            {
                DrawLinesOnly(g, projectedCube);
            }


        }

        /// <summary>
        /// Drawing lines methods, it is called when the checkbox3 is true
        /// </summary>
        /// <param name="g"></param>
        /// <param name="projectedCube"></param>

        //////////////////////////////////////////////////////////////      LINES       \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public void DrawLinesOnly(Graphics g, double[,] projectedCube)
        {
            int[,] edges =
            {
                {0, 1}, {1, 2}, {2, 3}, {3, 0},  // Top face
                {4, 5}, {5, 6}, {6, 7}, {7, 4},  // Bottom face
                {0, 4}, {1, 5}, {2, 6}, {3, 7}   // Vertical edges
            };



            // Drawing each edge
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int startIdx = edges[i, 0];
                int endIdx = edges[i, 1];

                DrawLine(g,
                   projectedCube[startIdx, 0], projectedCube[startIdx, 1],
                   projectedCube[endIdx, 0], projectedCube[endIdx, 1]);

            }
        }

        //Draws line on Form
        private void DrawLine(Graphics g, double x1, double y1, double x2, double y2)
        {
            int offsetX = this.Width / 2;  // Add this
            int offsetY = this.Height / 2;  // Add this

            int startX = (int)Math.Round(x1) + offsetX;  // Modify this
            int startY = (int)Math.Round(y1) + offsetY;  // Modify this
            int endX = (int)Math.Round(x2) + offsetX;  // Modify this
            int endY = (int)Math.Round(y2) + offsetY;  // Modify this

            g.DrawLine(Pens.Black, startX, startY, endX, endY);
        }

        //////////////////////////////////////////////////////////////      LINES       \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    }
}