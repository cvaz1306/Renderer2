using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer2
{
    public class Frame
    {
        static Vector2 offset = new Vector2(200, 150);
        private MyColor[,] colorMatrix;
        private int cellSize;

        public int Rows => colorMatrix.GetLength(0);
        public int Columns => colorMatrix.GetLength(1);
        public int Width => Columns * cellSize;
        public int Height => Rows * cellSize;

        public Frame(int rows, int columns, int cellSize)
        {
            colorMatrix = new MyColor[rows, columns];
            this.cellSize = cellSize;
        }

        public MyColor GetColor(int row, int column)
        {
            if (IsValidIndex(row, column))
            {
                return colorMatrix[row, column];
            }
            throw new ArgumentOutOfRangeException("Invalid row or column index.");
        }

        public void SetColor(int row, int column, MyColor color)
        {
            if (IsValidIndex(row, column))
            {
                Vector2 ax=new Vector2(row, column);
                Vector2 a2 = ScreenDistortion.DistortPoint(ax, 300, 400);
                //colorMatrix[(int)a2.X, (int)a2.Y] = color;
                colorMatrix[(int)ax.X, (int)ax.Y] = color;
            }
            else
            {
                //throw new ArgumentOutOfRangeException("Invalid row or column index.");
            }
        }

        public void FillWithColor(MyColor color)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    colorMatrix[i, j] = color;
                }
            }
        }

        public void FillWithRandomColors()
        {
            Random rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);
                    colorMatrix[i, j] = new MyColor(r, g, b);
                }
            }
        }

        public void AddLine(Vector2 startPoint, Vector2 endPoint, MyColor lineColor)
        {

            startPoint += offset;
            endPoint += offset;
            int x0 = (int)startPoint.X;
            int y0 = (int)startPoint.Y;
            int x1 = (int)endPoint.X;
            int y1 = (int)endPoint.Y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;
            int err = dx - dy;
            int ct = 0;
            while (true)
            {
                // Check if the current point is within the frame bounds.
                if (x0 >= 0 && x0 < Width && y0 >= 0 && y0 < Height)
                {
                    int row = y0 / cellSize;
                    int col = x0 / cellSize;
                    colorMatrix[row, col] = (ct != 0) ? lineColor : new MyColor(0, 0, 0);
                    ct++;
                }

                if (x0 == x1 && y0 == y1)
                {
                    break;
                }

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        public void AddLine(Vector3 startPoint, Vector3 endPoint, MyColor lineColor, Vector3 cameraPosition, Vector3 screenNormal, Vector3 screenCenter)
        {

            // Calculate the direction vector from start to end
            Vector3 direction = endPoint - startPoint;
            float length = direction.Length();

            // Normalize the direction vector
            direction /= length;

            // Iterate through points along the line
            for (float t = 0; t <= length; t += 0.1f)
            {
                // Calculate the current point in 3D space
                Vector3 currentPointIn3D = startPoint + t * direction;

                // Calculate the screen point of the current 3D point
                Vector2 currentScreenPoint = Geometry.FindIntersectionOnScreen(currentPointIn3D, screenCenter, screenNormal);

                // Check if the current point is in front of the camera
                if (IsPointAboveCameraPlane(cameraPosition, screenNormal, currentPointIn3D))
                {
                    int x = (int)(currentScreenPoint + offset).X;
                    int y = (int)(currentScreenPoint + offset).Y;

                    // Check if the current pixel is within the frame bounds
                    if (x >= 0 && x < Width && y >= 0 && y < Height)
                    {
                        int row = y / cellSize;
                        int col = x / cellSize;
                        SetColor(row, col, lineColor);
                    }
                }
                else
                {
                    // Stop rendering if the current point is behind the camera
                    break;
                }
            }
        }







        public Bitmap ToBitmap()
        {
            var bitmap = new Bitmap(Width, Height);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    MyColor color = colorMatrix[i, j];
                    using (var brush = new SolidBrush(Color.FromArgb(color.R, color.G, color.B)))
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.FillRectangle(brush, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                }
            }

            return bitmap;
        }

        private bool IsValidIndex(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }
        public static bool IsPointAboveCameraPlane(Vector3 cameraPosition, Vector3 ScreenNormal, Vector3 point)
        {
            // Calculate the vector from the camera position to the point.
            Vector3 vectorToPoint = point - cameraPosition;

            // Calculate the dot product between the camera's up vector and the vector to the point.
            float dotProduct = Vector3.Dot(ScreenNormal, vectorToPoint);

            // If the dot product is positive, the point is above the camera plane; if negative, it's below.
            return dotProduct > 0;
        }
        public void FillTriangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3, MyColor fillColor)
        {
            // Sort vertices by Y-coordinate to find the top, middle, and bottom vertices.
            List<Vector2> vertices = new List<Vector2> { vertex1, vertex2, vertex3 };
            vertices.Sort((a, b) => a.Y.CompareTo(b.Y));

            Vector2 topVertex = vertices[0];
            Vector2 middleVertex = vertices[1];
            Vector2 bottomVertex = vertices[2];

            // Calculate slopes for the top-to-middle and top-to-bottom edges.
            float slope1 = (middleVertex.X - topVertex.X) / (middleVertex.Y - topVertex.Y);
            float slope2 = (bottomVertex.X - topVertex.X) / (bottomVertex.Y - topVertex.Y);

            // Initialize the starting and ending X-coordinates for the top and bottom edges.
            float topX1 = topVertex.X;
            float topX2 = topVertex.X;
            float bottomX = topVertex.X;

            // Loop through each scanline and fill the pixels between the top and bottom edges.
            for (int y = (int)topVertex.Y; y <= (int)bottomVertex.Y; y++)
            {
                int startX = (int)topX1;
                int endX = (int)topX2;

                for (int x = startX; x <= endX; x++)
                {
                    SetColor(y / cellSize, x / cellSize, fillColor);
                }

                topX1 += slope1;
                topX2 += slope2;

                // Adjust the slopes if needed for flat top or flat bottom triangles.
                if (y >= middleVertex.Y)
                {
                    topX1 += (middleVertex.X - topVertex.X) / (middleVertex.Y - topVertex.Y);
                }

                if (y == middleVertex.Y)
                {
                    topX2 = middleVertex.X;
                }
            }
        }


    }
    public static class Geometry
    {
        public static Vector2 FindIntersectionOnScreen(Vector3 pointIn3DSpace, Vector3 screenCenter, Vector3 screenNormal)
        {
            // Calculate the direction vector from the point to the screen center.
            Vector3 direction = screenCenter - pointIn3DSpace;

            // Calculate the parameter t at which the line intersects the screen plane.
            float t = Vector3.Dot(direction, screenNormal);

            // Calculate the intersection point in 3D space.
            Vector3 intersection3D = pointIn3DSpace + t * direction;

            // Calculate the intersection point on the screen relative to the screen center.
            Vector3 screenVector = intersection3D - screenCenter;
            Vector2 intersection2D = new Vector2(screenVector.X, screenVector.Y); // Assuming Z-axis is screen depth.

            return intersection2D;
        }
        public static Vector3 CalculateScreenNormal(float xRotation, float yRotation, float zRotation)
        {
            // Convert degrees to radians.
            float xRad = xRotation * (float)Math.PI / 180.0f;
            float yRad = yRotation * (float)Math.PI / 180.0f;
            float zRad = zRotation * (float)Math.PI / 180.0f;

            // Calculate the screen normal vector.
            Vector3 screenNormal = Vector3.UnitZ;

            // Apply rotations in order: Z, Y, X
            // Rotate around Z-axis (Yaw)
            screenNormal = Vector3.Transform(screenNormal, Matrix4x4.CreateRotationZ(zRad));

            // Rotate around Y-axis (Pitch)
            screenNormal = Vector3.Transform(screenNormal, Matrix4x4.CreateRotationY(yRad));

            // Rotate around X-axis (Roll)
            screenNormal = Vector3.Transform(screenNormal, Matrix4x4.CreateRotationX(xRad));

            return screenNormal;
        }
    }
    public class ScreenDistortion
    {
        // Define your custom field of view (FOV) in degrees
        public static float CustomFOV = 90.0f;

        public static Vector2 DistortPoint(Vector2 point, float screenWidth, float screenHeight)
        {
            // Calculate the center of the screen
            Vector2 screenCenter = new Vector2(screenWidth / 2.0f, screenHeight / 2.0f);

            // Calculate the focal length based on the FOV
            float focalLength = (screenWidth / 2.0f) / (float)Math.Tan(Math.PI * CustomFOV / 360.0);

            // Calculate the vector from the screen center to the input point
            Vector2 vectorToCenter = point - screenCenter;

            // Calculate the distance from the screen center to the input point
            float distanceToCenter = vectorToCenter.Length();

            // Calculate the angle between the vector and the x-axis
            float angleToCenter = (float)Math.Atan2(vectorToCenter.Y, vectorToCenter.X);

            // Apply distortion based on the distance and angle
            float distortedDistance = distanceToCenter * (1.0f + (distanceToCenter / focalLength) * 0.2f);
            float distortedX = screenCenter.X + distortedDistance * (float)Math.Cos(angleToCenter);
            float distortedY = screenCenter.Y + distortedDistance * (float)Math.Sin(angleToCenter);

            return new Vector2(distortedX, distortedY);
        }
    }

}
