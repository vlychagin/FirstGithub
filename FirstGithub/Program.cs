using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGithub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ветвь master
            Console.WriteLine($"\n\nПривет, мир!\nСегодня {DateTime.Now:G}");
            double r = 100d;
            double area = Math.PI * r*r;
			Console.WriteLine($"r = {r:f3} ед., area = {area:f3} кв.ед.");
        }
    }
}
