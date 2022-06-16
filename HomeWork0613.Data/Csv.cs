using CsvHelper;
using HomeWork0614.Web.Models;
using HomeWork0613.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

public class Csv
    {
        public string GetCsvFile(int amount)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);
            using var csv = new CsvWriter(stringWriter, CultureInfo.InvariantCulture);
            csv.WriteRecords(GetRandomPeople(amount));
            return builder.ToString();
        }
        static List<Person> GetRandomPeople(int amount)
        {
            List<Person> result = new List<Person>();
            for (int i = 1; i <= amount; i++)
            {
                result.Add(new Person
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    Age = RandomNumber.Next(0, 120).ToString(),
                    Address = Address.StreetAddress(),
                    Email = Internet.Email()
                });
            }

            return result;

        }
    //    public List<Person> AddPeople(FileInfo fileInfo)
    //    {
    //        int index = fileInfo.Base64File.IndexOf(",") + 1;
    //        string base64 = fileInfo.Base64File.Substring(index);
    //        byte[] theFile = Convert.FromBase64String(base64);
    //        using var memoryStream = new MemoryStream(theFile);
    //        var streamReader = new StreamReader(memoryStream);
    //        using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
    //        return reader.GetRecords<Person>().ToList();
    //        //System.IO.File.WriteAllBytes($"uploads/{fileInfo.Name}", theFile);
       }

    //    //public static List<Person> GetFromCsvBytes(byte[] bytes)
    //    //{
    //    //    using var memoryStream = new MemoryStream(bytes);
    //    //    var streamReader = new StreamReader(memoryStream);
    //    //    using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
    //    //    return reader.GetRecords<Person>().ToList();
    //    //}

    //    //public void GetRandomPeople()
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
    public class FileInfo
    {
        public string Base64File { get; set; }
        public string Name { get; set; }
    }




