using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
namespace ConsoleApp4
{
    public class People
    {
        private readonly int year, month, day;
        private readonly DateTime birthDate;
        public string Name { get; protected set; }
        public string Sex { get; protected set; }

        public People()
        {
            Write("Имя: ");
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
        public int Age()
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
            List<People> peoples = new List<People>();
            string yes = "y";
            
            do
            {
                People people = new People();
                peoples.Add(people);
                Console.WriteLine();
                
                using (StreamWriter file = File.AppendText(@"d:\people.csv"))
                {
                    foreach (var human in peoples)
                    {
                        file.WriteLine(human.ToFile());
                    }
                    Console.WriteLine("Запись в файл прошла успешно!");
                }
                
                Write("Хотете продолжить?: Y - да");
                yes = ReadLine();
            }
            while (yes == "Y" || yes == "y");
        }
    }
}
