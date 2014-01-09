﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRUM
{
    class Program
    {
        People people = new People();
        static string GetMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1. Lägg till person.\n");
            sb.Append("2. Ändra uppgifter på person.\n");
            sb.Append("3. Ta bort person.\n");
            sb.Append("4. Lista alla personer.\n");
            sb.Append("5. Information om specifik person.\n");
            sb.Append("0. Avsluta.\n");
            return sb.ToString();
        }
        static void addPerson()
        {
            throw new NotImplementedException();
        }
        static void changeInfo()
        {
            throw new NotImplementedException();
        }
        static void removePerson()
        {
            throw new NotImplementedException();
        }
        static void listAllPeople()
        {
            throw new NotImplementedException();
        }
        static void exit()
        {
            throw new NotImplementedException();
        }
        static void getChoice()
        {
            throw new NotImplementedException();
        }
        static void listPerson()
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            string menuText = GetMenu();
            while (true)
            {
                Console.WriteLine("Gör ditt val");
                Console.WriteLine(menuText);
                Console.Write("Nummer: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        listAllPeople();
                        break;
                    case "0":
                        exit();
                        break;
                    default:
                        break;
                }
                //wut();
                //Console.SetCursorPosition(3, 10);
                //wut();
                Console.Write("Skriv q för att avsluta. ");
            }
        }
        static void wut()
        {
            Person chris = new Person("Chris", "Holm", "0738234460");
            People people = new People();
            people.addPerson(chris);
            Person test = people.getPerson(chris);
            Console.WriteLine(test);
            Console.WriteLine();

            Person towe = new Person("Towe", "1", "2");
            people.addPerson(towe);
            test = people.getPerson(towe);
            Console.WriteLine(test);
            Console.WriteLine();

            Person editPersonZero = people.getPerson(0);
            editPersonZero.firstName = "Test";
            editPersonZero.lastName = "TestAgain";

            List<Person> personList = people.getPersonAll();
            foreach (var person in personList)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}
