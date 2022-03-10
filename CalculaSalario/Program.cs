using System;
using static System.Console;
using CalculaSalario.Entities;
using System.Collections.Generic;
using System.Globalization;


namespace CalculaSalario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Write("Enter the number of employees: ");
            int n = int.Parse(ReadLine());

            for (int i = 1; i <= n; i++)
            {
                WriteLine($"Employee #{i} data:");
                Write("Outsourced (y/n)? ");
                char ch = char.Parse(Console.ReadLine());
                Write("Name: ");
                string name = ReadLine();
                Write("Hours: ");
                int hours = int.Parse(ReadLine());
                Write("Value per hour: ");
                double valuePerHour = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'y')
                {
                    Write("Additional charge: ");
                    double additionalCharge = double.Parse(ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    list.Add(new Employee(name, hours, valuePerHour));
                }
            }

            WriteLine();
            WriteLine("------ PAYMENTS ------");

            foreach (Employee emp in list)
            {
                WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
