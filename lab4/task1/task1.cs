using System;

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Rectangle
{
    private Point TopLeft;
    private Point BottomRight;

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        return point.X >= TopLeft && point.X <= BottomRight.X &&
               point.Y >= TopLeft && point.Y <= BottomRight.Y;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the coordinates of the rectangle (<topLeftX> <topLeftY> <bottomRightX> <bottomRightY>):");
        var rectInput =  Console.ReadLine().Split(' ');
        var topLeft = new Point(int.Parse(rectInput[0]), int.Parse(rectInput[1]));
        var bottomRight = new Point(int.Parse(rectInput[2]), int.Parse(rectInput[3]));
        var rectangle = new Rectangle(topLeft, bottomRight);
        
        Console.WriteLine("Enter the number of points to check: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the coordinates of each point: ");
        for (int i = 0; i < n; i++)
        {
            var pointInput = Console .ReadLine().Split(' ');
            var point = new Point(int.Parse(pointInput[0]), int.Parse(pointInput[1]));
            bool result = rectangle.Contains(point);
            Console.WriteLine($"-> Result: {result}");
        }

        Console.ReadKey();
    }
}