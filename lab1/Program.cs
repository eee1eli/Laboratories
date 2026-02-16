using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryPolymorphism
{
    
    public abstract class GeometricBody
    {
        public string Name { get; set; }

        
        public GeometricBody() : this("Невідоме тіло") { }
        public GeometricBody(string name) => Name = name;
        public GeometricBody(GeometricBody other) => Name = other.Name;

        
        public abstract double GetSurfaceArea();

        
        public virtual string GetInfo() => $"Це геометричне тіло: {Name}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return Name == ((GeometricBody)obj).Name;
        }

        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    }

    
    public class Sphere : GeometricBody
    {
        public double Radius { get; set; }

        public Sphere() : base("Куля") { Radius = 1.0; }
        public Sphere(string name, double radius) : base(name) => Radius = radius;
        public Sphere(Sphere other) : base(other) => Radius = other.Radius;

        public override double GetSurfaceArea() => 4 * Math.PI * Math.Pow(Radius, 2);

        public override string GetInfo() => $"Куля '{Name}' (Радіус: {Radius})";

        public override bool Equals(object obj) => base.Equals(obj) && Radius == ((Sphere)obj).Radius;
    }

   
    public class Parallelepiped : GeometricBody
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Parallelepiped() : base("Блок") { A = B = C = 1.0; }
        public Parallelepiped(string name, double a, double b, double c) : base(name)
        {
            A = a; B = b; C = c;
        }

        public override double GetSurfaceArea() => 2 * (A * B + B * C + A * C);

     
        public new string GetInfo() => $"Паралелепіпед '{Name}' (Раннє зв'язування)";

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            var p = (Parallelepiped)obj;
            return A == p.A && B == p.B && C == p.C;
        }
    }

   
    public class Tetrahedron : GeometricBody
    {
        public double Edge { get; set; }

        public Tetrahedron() : base("Тетраедр") { Edge = 1.0; }
        public Tetrahedron(string name, double edge) : base(name) => Edge = edge;

        public override double GetSurfaceArea() => Math.Pow(Edge, 2) * Math.Sqrt(3);

        public override bool Equals(object obj) => base.Equals(obj) && Edge == ((Tetrahedron)obj).Edge;
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.UTF8;

            List<GeometricBody> bodies = new List<GeometricBody>
            {
                new Sphere("М'яч", 5),
                new Parallelepiped("Коробка", 2, 3, 4),
                new Tetrahedron("Піраміда", 6)
            };

            Console.WriteLine("--- Поліморфізм (Площа поверхні) ---");
            foreach (var body in bodies)
            {
                
                Console.WriteLine($"{body.Name}: Площа = {body.GetSurfaceArea():F2}");
            }

            Console.WriteLine("\n--- Раннє vs Пізнє зв'язування ---");
            Parallelepiped p = new Parallelepiped("Блок", 2, 2, 2);
            GeometricBody pAsBase = p;

            
            Console.WriteLine($"Виклик через Parallelepiped: {p.GetInfo()}");

            
            Console.WriteLine($"Виклик через GeometricBody: {pAsBase.GetInfo()}");

            Console.WriteLine("\n--- Перевірка Equals та конструкторів копіювання ---");
            Sphere s1 = new Sphere("Планета", 6371);
            Sphere s2 = new Sphere(s1); 
            Console.WriteLine($"s1 == s2 за значеннями: {s1.Equals(s2)}");

            Console.ReadLine();
        }
    }
}