using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kalori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Welcome to the calorie calculator");

            Console.Write("Please enter your weight in kg:");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your height in cm:");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter your gender F or M:");
            char gender = Convert.ToChar(Console.ReadLine().ToUpper());

            Console.Write("Daily step count:");
            int steps = Convert.ToInt32(Console.ReadLine());

            double stepCalories = weight * steps * 0.0005;

            Console.Write("How much calories have you taken today?:");
            int calorietaken = Convert.ToInt32(Console.ReadLine());

            double bmr;
            double dailycalorieneed;
            double remainingcalories;

            if (gender == 'M')
            {
                bmr = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else
            {
                bmr = 10 * weight + 6.25 * height - 5 * age - 161;
            }

            dailycalorieneed = bmr + stepCalories;
            remainingcalories = dailycalorieneed - calorietaken;

            Console.WriteLine($"Your daily calorie need is: {dailycalorieneed}");
            Console.WriteLine($"Your calorie deficit: {remainingcalories}");

            if (remainingcalories > 0)
            {
                Console.WriteLine("You are losing weight");
            }
            else
            {
                Console.WriteLine("You are gaining weight");
            }

            //KAYDETME KISMI
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string data = $"{date} | {weight}kg | {height}cm | age:{age} | {gender} | steps:{steps} | kcal:{calorietaken} | need:{dailycalorieneed} | deficit:{remainingcalories}";

            // masaüstüne kaydetmek için:
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\kalori.txt";

            File.AppendAllText(path, data + Environment.NewLine);

            Console.WriteLine("Saved to desktop ");

            // dosyanın nerede olduğunu göster
            Console.WriteLine(path);

            Console.ReadKey();
        }
    }
}