﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Contacts.\n");
            Console.WriteLine("Press [1] To Add a Contact");
            Console.WriteLine("Press [2] To Display All the Contacts");
            Console.WriteLine("Press [3] To Update a Contact");
            Console.WriteLine("Press [4] To Delete a contact");
            Console.WriteLine("Press 'E' to exit \n");

            var userInput = Console.ReadLine();

            var phoneBook = new PhoneBook();

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        
                        Console.Write("\nEnter contact name: ");
                        var name = Console.ReadLine();

                        Console.Write("Enter contact number: ");
                        var number = Console.ReadLine();

                        string filepath = @"D:\streamwriter";
                        StreamWriter sw;

                        if (File.Exists(filepath))
                            sw = new StreamWriter(filepath, true);
                        else
                            sw = new StreamWriter(@"D:\streamwriter");
                            sw.Write(name + " ");
                            sw.WriteLine(number);
                            sw.Close();

                        //sw.Write(string.Format("{0}", name));
                        //sw.WriteLine(string.Format("{0}", number));

                        break;

                    case "2":

                        String filePath = (@"D:\streamwriter");
                        List<string> lines = File.ReadAllLines(filePath).ToList();

                        foreach (string linee in lines)
                        {
                            Console.WriteLine(linee);
                        }

                        break;

                    case "3":

                        string text = File.ReadAllText(@"D:\streamwriter");

                        Console.Write("Enter the old contact name: ");
                        var oldName = Console.ReadLine();

                        Console.Write("Enter contact name that you want to update: ");
                        var updatedName = Console.ReadLine();

                        text = text.Replace(oldName, updatedName);
                        File.WriteAllText(@"D:\streamwriter", text);

                        break;

                    case "4":

                        var fileLocation = (@"D:\streamwriter");

                        Console.Write("Enter the contact number that you want to delete: ");
                        var searchDigit = Console.ReadLine();

                        string strSearchText = searchDigit;
                        string strOldText;
                        string n = "";

                        StreamReader sr = File.OpenText(fileLocation);
                        while ((strOldText = sr.ReadLine()) != null )
                        {
                            if (!strOldText.Contains(strSearchText))
                            {
                                n += strOldText + Environment.NewLine;
                            }
                        }
                        sr.Close();
                        File.WriteAllText(fileLocation, n);

                        break;

                    case "E":
                        return;

                    default:
                        Console.WriteLine("Select valid operation");
                        break;
                }

                Console.Write("\nPress [ok] to continue further OR Press [E] to exit the program : ");
                var output = Console.ReadLine();

                if(output == "ok")
                {
                    Console.WriteLine("\nWelcome to Contacts.\n");
                    Console.WriteLine("Press [1] To Add a Contact");
                    Console.WriteLine("Press [2] To Display All the Contacts");
                    Console.WriteLine("Press [3] To Update a Contact");
                    Console.WriteLine("Press [4] To Delete a contact");
                    Console.WriteLine("Press 'E' to exit \n");
                    userInput = Console.ReadLine();
                }
                else if(output == "E")
                {
                    Environment.Exit(0);
                }
                else
                {

                }
                
            }

        }
    }
}
