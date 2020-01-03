using System;
using System.IO;
using static System.Console;

namespace WriteFileClassPeople
{
    public class People
    {
        private readonly int year, month, day;
        private readonly DateTime birthDate;
        private string Name { get; set; }
        private string Sex { get; set; }

        public People()
        {
            Write("ФИО: ");
            Name = ReadLine();
            Write("Укажите пол: ");
            Sex = ReadLine();
            Write("Год рождения: ");
            year = GetInt();
            Write("Месяц рождения: ");
            month = GetInt();
            Write("День рождения: ");
            day = GetInt();
            birthDate = new DateTime(year, month, day);
        }
        private int Age()
        {
            return DateTime.Now.Subtract(birthDate).Days / 365;
        }
        public string ToFile()
        {
            return $"Имя: {Name} пол: {Sex} Возраст {Age()}";
        }
        private int GetInt()
        {
            return int.Parse(ReadLine());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string yes = "y";

            do
            {
                People people = new People();                     
                Console.WriteLine();

                using (StreamWriter file = File.AppendText(@"d:\people.csv"))
                {
                    file.WriteLine(people.ToFile());
                    Console.WriteLine("Запись в файл прошла успешно!");
                }

                Write("Хотете продолжить?: Y - да: ");
                yes = ReadLine();
            }
            while (yes == "Y" || yes == "y");
        }
    }
}