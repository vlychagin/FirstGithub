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
            Console.Title = "Пример проекта c геометрическими построениями";
            
            Console.WriteLine($"\n\nПривет, мир!\nСегодня {DateTime.Now:G}");
            double r = 100d;
            double area = Math.PI * r*r;

			Console.WriteLine($"r = {r:f3} ед., area = {area:f3} кв.ед.");

            // расчет объема сферы
            double volume = 4 * Math.PI * r * r * r / 3;
            Console.WriteLine($"объем сферы радиуса {r:f3} равен {volume:f3}");
        }
    }
}
