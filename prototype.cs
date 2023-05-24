using System;

namespace main
{
    public abstract class Shape
    {
        public int X;
        public int Y;
        public string colour;
        
        public abstract Shape Clone();
        
        
    }
    
    public class Rectangle : Shape 
    {
        public int width;
        public int height;
        
        public override Shape Clone()
        {
            return (Rectangle) this.MemberwiseClone();
        }
    }
    
    public class Circle : Shape 
    {
        public int radius;
        
        public override Shape Clone()
        {
            return (Circle) this.MemberwiseClone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           Rectangle rect = new Rectangle();
           rect.width = 10;
           rect.height = 20;
           
           Rectangle newRect = (Rectangle) rect.Clone();
           
           Console.Write(newRect.width);
           
           Circle crcl = new Circle();
           crcl.radius = 10;
           
           Circle newCrcl = (Circle) crcl.Clone(); 
           
           Console.Write(newCrcl.radius);
        }
    }
}