﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRUM
{
    class Program
    {
        
        static People people = new People();
        /// <summary>
        /// Returns the menu with all options in the beginning of the program
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Adds a person to the people dictionary
        /// </summary>
        static void addPerson()
        {
            string firstName, lastName, telephoneNumber;
            Console.WriteLine("Ändra information");
            Console.WriteLine("Förnamn: ");
            Console.WriteLine("Efternamn: ");
            Console.WriteLine("Telefonnummer: ");

            Console.SetCursorPosition(9, 1);
            firstName = Console.ReadLine();
            Console.SetCursorPosition(11, 2);
            lastName = Console.ReadLine();
            Console.SetCursorPosition(15, 3);
            telephoneNumber = Console.ReadLine();

            /*Console.WriteLine("Lägg till person");
            Console.Write("Förnamn: ");
            string firstname = Console.ReadLine();
            Console.Write("Efternamn: ");
            string lastname = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            string telephonenumber = Console.ReadLine();*/

            people.addPerson(firstName, lastName, telephoneNumber);
        }
        /// <summary>
        /// Change the info on person
        /// </summary>
        /// <param name="person"></param>
        static void changeInfo(Person person)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Change the info of the person associated with id
        /// </summary>
        /// <param name="id"></param>
        static void changeInfo(string id)
        {
            if (people.Count != 0)
            {
                Person person = people.getPerson(id).Item2;
                Console.WriteLine("Ändra information (tidigare ifyllda värden visas i grön text)");
                Console.Write("Förnamn: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(String.Format("{0}", person.firstName) + "\n");
                Console.ResetColor();

                Console.Write("Efternamn: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(String.Format("{0}", person.lastName) + "\n");
                Console.ResetColor();

                Console.Write("Telefonnummer: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(String.Format("{0}", person.telephoneNumber)+"\n");
                Console.ResetColor();

                Console.SetCursorPosition(9, 1);
                person.firstName = Console.ReadLine();
                Console.SetCursorPosition(11, 2);
                person.lastName = Console.ReadLine();
                Console.SetCursorPosition(15, 3);
                person.telephoneNumber = Console.ReadLine();
            }
        }
        /// <summary>
        /// Removes person from the people dictionary
        /// </summary>
        /// <param name="person"></param>
        static void removePerson(Person person)
        {
            if(people.Count != 0)
                people.removePerson(person);
        }
        /// <summary>
        /// Removes the person associated with id
        /// </summary>
        /// <param name="id"></param>
        static void removePerson(string id)
        {
            if (people.Count!=0)
                people.removePerson(people.getPerson(id).Item2);
        }
        /// <summary>
        /// Prints a brief list of all people that are in the dictionary
        /// </summary>
        /// <returns>false if there are no people in people, true if there are</returns>
        static bool listAllPeople(string pretext)
        {
            Console.WriteLine(pretext);
            if (people.Count == 0)
            {
                Console.WriteLine();
                printErrorMessage("Tyvärr finns det inga personer registrerade. Försök registrera en ny person.");
                return false;
            }
            Console.Write(people.ToString());
            return true;
        }
        static void printErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
        /// <summary>
        /// Confirms that you want to exit before we call exit()
        /// </summary>
        static void confirmExit()
        {
            Console.Write("Är du säker att du vill avsluta? (y/n) ");
            while(true){
                ConsoleKey ck = Console.ReadKey().Key;
                if (ck == ConsoleKey.Y)
                    exit();
                /*else if (ck == ConsoleKey.N)
                    break;*/
                else
                    break;
            }
        }
        /// <summary>
        /// Exits the program
        /// </summary>
        static void exit()
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Gets a choice and returns it
        /// Might implement some form of checking here aswell
        /// This can be used to write some text and wait for user input, such as
        /// getChoice("Tryck enter för att fortsätta")
        /// Instead of writing two lines of code :)
        /// </summary>
        static string getChoice(string pretext)
        {
            Console.Write(pretext);
            string choice = Console.ReadLine();
            return choice;
        }
        /// <summary>
        /// Takes person and lists its information
        /// </summary>
        /// <param name="person"></param>
        static void listPerson(Person person)
        {
            Console.WriteLine(person);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        static void listPerson(string id, string errorText = "")
        {
            Tuple<bool, Person> tuplePerson = people.getPerson(id);

            if (tuplePerson.Item1)
            {
                Console.WriteLine(String.Format("{0} {1}:", tuplePerson.Item2.firstName, tuplePerson.Item2.lastName));
                Console.WriteLine(tuplePerson.Item2);
            }
            else
                Console.WriteLine(errorText);
        }
        static void Main(string[] args)
        {
            string personid;
            string choice;
            string menuText = GetMenu();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gör ditt val\n");
                Console.WriteLine(menuText);
                choice = getChoice("Nummer: ");
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        addPerson();
                        break;
                    case "2":
                        Console.Clear();
                        if (!listAllPeople("Ändra uppgifter på person.\nVälj person:"))
                        {
                            getChoice("Tryck enter för att gå tillbaka till menyn.");
                            break;
                        }
                        personid = getChoice("Nummer: ");
                        Console.Clear();
                        changeInfo(personid);
                        break;
                    case "3":
                        Console.Clear();
                        if (!listAllPeople("Ta bort en person.\nVälj person:"))
                        {
                            getChoice("Tryck enter för att gå tillbaka till menyn.");
                            break;
                        }
                        personid = getChoice("Nummer: ");
                        Console.Clear();
                        removePerson(personid);
                        break;
                    case "4":
                        Console.Clear();
                        listAllPeople("Lista på alla personer:");
                        //DRY
                        /*if (!listAllPeople("Lista på alla personer:"))
                        {
                            getChoice("Tryck enter för att gå tillbaka till menyn.");
                            break;
                        }*/
                        getChoice("Tryck enter för att gå tillbaka till menyn.");
                        break;
                    case "5":
                        Console.Clear();
                        if (!listAllPeople("Information om en specifik person.\nVälj en person:\n"))
                        {
                            getChoice("Tryck enter för att gå tillbaka till menyn.");
                            break;
                        }
                        personid = getChoice("\nNummer: ");
                        Console.Clear();
                        listPerson(personid, "Den personen finns tyvärr inte. Försök igen.");
                        getChoice("\nTryck enter när du är klar.");
                        break;

                    case "0":
                        Console.Clear();
                        confirmExit();
                        break;
                    default:
                        break;
                }
                //wut();
                //Console.SetCursorPosition(3, 10);
                //wut();
            }
        }
        /// <summary>
        /// Trash function that just contains code that I previously tested with
        /// </summary>
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

            List<Person> personList = people.getPersonList();
            foreach (var person in personList)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}
