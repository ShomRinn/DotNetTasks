namespace PointStruct
{
    /// <summary>
    /// Represents a point in the Cartesian coordinate system.
    /// </summary>
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// Gets or sets initializes a new instance of the <see cref="Point"/> structure with the specified <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <param name="x">An x-coordinate of this <see cref="Point"/> structure.</param>
        /// <param name="y">An y-coordinate of this <see cref="Point"/> structure.</param>
        public Point(int x, int y)
            : this((long)x, (long)y)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> structure with the specified <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        /// <param name="x">An x-coordinate of this <see cref="Point"/> structure.</param>
        /// <param name="y">An y-coordinate of this <see cref="Point"/> structure.</param>
        public Point(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the x-coordinate of this <see cref="Point"/> structure.
        /// </summary>
        public long X { get; private set; }

        /// <summary>
        /// Gets the y-coordinate of this <see cref="Point"/> structure.
        /// </summary>
        public long Y { get; private set; }

        /// <summary>
        /// Compares the <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="Point"/> is equal to the right <see cref="Point"/>; otherwise, false.
        /// </summary>
        /// <param name="left">A left <see cref="Point"/>.</param>
        /// <param name="right">A right <see cref="Point"/>.</param>
        /// <returns>true if the left <see cref="Point"/> is equal to the right <see cref="Point"/>; otherwise, false.</returns>
        public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Compares the <paramref name="left"/> and <paramref name="right"/> objects. Returns true if the left <see cref="Point"/> is not equal to the right <see cref="Point"/>; otherwise, false.
        /// </summary>
        /// <param name="left">A left <see cref="Point"/>.</param>
        /// <param name="right">A right <see cref="Point"/>.</param>
        /// <returns>true if the left <see cref="Point"/> is not equal to the right <see cref="Point"/>; otherwise, false.</returns>
        public static bool operator !=(Point left, Point right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Converts the string representation of a point to its <see cref="Point"/> equivalent.
        /// </summary>
        /// <param name="pointString">A string containing a point to convert.</param>
        /// <returns>A <see cref="Point"/> equivalent to the point contained in <paramref name="pointString"/>.</returns>
        public static Point Parse(string pointString)
        {
            string[] points = pointString.Split(',');

            if (points.Length != 2)
            {
                throw new ArgumentException("Input string should contain exactly two numbers separated by a comma.", nameof(pointString));
            }

            if (!long.TryParse(points[0], out long x) || !long.TryParse(points[1], out long y))
            {
                throw new ArgumentException("Both input values should be valid long numbers.", nameof(pointString));
            }

            if (string.IsNullOrEmpty(pointString))
            {
                throw new ArgumentNullException(nameof(pointString), "Point string cannot be null or empty.");
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Converts the string representation of a point to its <see cref="Point"/> equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="pointString">A string containing a point to convert.</param>
        /// <param name="point">A <see cref="Point"/> equivalent to the point contained in <paramref name="pointString"/>.</param>
        /// <returns>true if <paramref name="rgbString"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string pointString, out Point point)
        {
            point = default;

            if (string.IsNullOrEmpty(pointString))
            {
                return false;
            }

            string[] points = pointString.Split(',');

            if (points.Length != 2)
            {
                return false;
            }

            if (!long.TryParse(points[0], out long x) || !long.TryParse(points[1], out long y))
            {
                return false;
            }

            point = new Point(x, y);
            return true;
        }

        /// <summary>
        /// Returns the number of points that have exact same coordinates as the <see cref="Point"/>.
        /// </summary>
        /// <param name="points">A collection of points.</param>
        /// <returns>The number of points that have exact same coordinates as the <see cref="Point"/>.</returns>
        public int CountPointsInExactSameLocation(IEnumerable<Point> points)
        {
            Point thisPoint = this;
            return points.Count(p => p == thisPoint);
        }

        /// <summary>
        /// Returns a string with points that are collinear to the <see cref="Point"/>.
        /// </summary>
        /// <param name="points">A collection of points.</param>
        /// <returns>A string with points that are collinear to the <see cref="Point"/>.</returns>
        public string GetCollinearPointCoordinates(ICollection<Point> points)
        {
            var coordinates = new List<string>();

            foreach (Point point in points)
            {
                if (this.X == point.X && this.Y == point.Y)
                {
                    coordinates.Add($"({point.X},{point.Y},\"SAME\")");
                }
                else if (this.X == point.X)
                {
                    coordinates.Add($"({point.X},{point.Y},\"X\")");
                }
                else if (this.Y == point.Y)
                {
                    coordinates.Add($"({point.X},{point.Y},\"Y\")");
                }
            }

            return string.Join(',', coordinates);
        }

        /// <summary>
        /// Returns a collection of points that are distance-neighbors for the <see cref="Point"/>.
        /// </summary>
        /// <param name="distance">Distance around a given point.</param>
        /// <param name="points">A list of points.</param>
        /// <returns>A collection of points that are distance-neighbors.</returns>
        public ICollection<Point> GetNeighbors(int distance, IList<Point> points)
        {
            if (distance <= 0)
            {
                throw new ArgumentException("Wrong input.", nameof(distance));
            }

            var neighbors = new List<Point>();
            foreach (Point point in points)
            {
                if (this.IsNeighbor(distance, point))
                {
                    neighbors.Add(point);
                }
            }

            return neighbors;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <param name="other">The <see cref="Point"/> to compare with the current <see cref="Point"/>.</param>
        /// <returns>true if the specified <see cref="Point"/> is equal to the current <see cref="Point"/>; otherwise, false.</returns>
        public bool Equals(Point other) => new Point(this.X, this.Y) == other;

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Point"/>.</param>
        /// <returns>true if the specified <see cref="Point"/> is equal to the current <see cref="Point"/>; otherwise, false.</returns>
        public override bool Equals(object? obj) => obj != null && this.GetType() == obj.GetType() && (Point)obj == new Point(this.X, this.Y);

        /// <summary>
        /// Returns a string that represents the current <see cref="Point"/>.
        /// </summary>
        /// <returns>A string that represents the current <see cref="Point"/>.</returns>
        public override string ToString() => $"{this.X},{this.Y}";

        /// <summary>
        /// Gets a hash code of the current <see cref="Point"/>.
        /// </summary>
        /// <returns>A hash code of the current <see cref="Point"/>.</returns>
        public override int GetHashCode()
        {
            uint lowX = (uint)(this.X & 0xFFFFFFFF);
            uint highX = (uint)(this.X >> 32);
            uint hashX = lowX ^ highX;

            uint lowY = (uint)(this.Y & 0xFFFFFFFF);
            uint highY = (uint)(this.Y >> 32);
            uint hashY = lowY ^ highY;

            return (int)(hashX ^ hashY);
        }

        private bool IsNeighbor(long distance, Point point) => Math.Abs(point.X - this.X) <= distance && Math.Abs(point.Y - this.Y) <= distance;
    }
}
