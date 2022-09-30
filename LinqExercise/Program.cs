using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            //TODO: Print the Average of numbers
            var inOrder = numbers.OrderBy(item => item);

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("----------------------------------------------------");
            foreach (var number in inOrder)
            {
                Console.WriteLine(number);
            }

            //TODO: Order numbers in decsending order adn print to the console
            var noOrder = numbers.OrderByDescending(num => num);
            Console.WriteLine("----------------------------------------------------");
            foreach (var number in noOrder)
            {
                Console.WriteLine(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("----------------------------------------------------");
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("----------------------------------------------------");
            foreach (var num in noOrder.Take(4))
            {
                Console.WriteLine(num);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("----------------------------------------------------");
            numbers.SetValue(32, 4);

            var descAge = numbers.OrderByDescending(num => num);
            foreach (var number in descAge)
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's')
                            .OrderBy(person => person.FirstName);

            var otherFiltered = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                                .OrderBy(name => name.FirstName);

            Console.WriteLine("----------------------------------------------------");
            foreach (var person in filtered)
            {
                Console.WriteLine(person.FullName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);

            Console.WriteLine("----------------------------------------------------");
            foreach (var item in twentySix)
            {
                Console.WriteLine($"Name: {item.FullName}, Age: {item.Age}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Total EXP:{sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg EXP:{sumAndYOE.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("First", "Last", 35, 10)).ToList();

            Console.WriteLine("----------------------------------------------------");
            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
            Console.ReadLine();
            }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
