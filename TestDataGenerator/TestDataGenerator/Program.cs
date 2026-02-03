using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TestDataGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Pick an object \n 1 - SF Contact \n 2 - SF Leads \n 3 - SF Accounts \n 4 - MC Standard DataExtension");

            var objectSelection = Console.ReadLine();

            Console.WriteLine("Total rows to generate :");

            var totalRows = Console.ReadLine();

            Console.WriteLine("File path with file name and extn :");

            var filepath = Console.ReadLine();

            switch (objectSelection)
            {
                case "1":
                    var contacts = Contacts.FakeData.Generate(int.Parse(totalRows)).ToList();
                    using (var csv = new CsvWriter(new StreamWriter(filepath), CultureInfo.CurrentCulture))
                    {
                        csv.WriteRecords(contacts);
                    }
                    break;
                case "2":
                    var leads = Leads.FakeData.Generate(int.Parse(totalRows)).ToList();
                    using (var csv = new CsvWriter(new StreamWriter(filepath), CultureInfo.CurrentCulture))
                    {
                        csv.WriteRecords(leads);
                    }
                    break;
                case "3":
                    var accounts = Accounts.FakeData.Generate(int.Parse(totalRows)).ToList();
                    using (var csv = new CsvWriter(new StreamWriter(filepath), CultureInfo.CurrentCulture))
                    {
                        csv.WriteRecords(accounts);
                    }
                    break;
                case "4":
                    var mcDeList = StandardDataExtension.FakeData.Generate(int.Parse(totalRows)).ToList();
                    using (var csv = new CsvWriter(new StreamWriter(filepath), CultureInfo.CurrentCulture))
                    {
                        csv.WriteRecords(mcDeList);
                    }
                    break;
            }

            Console.WriteLine("File Generation Completed !");
            Console.ReadLine();
        }
    }
}