using CsvHelper;
using HomeWork0613.Data;
using HomeWork0614.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository;

namespace HomeWork0614.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getPeople")]
        public List<Person> GetPeople()
        {
            Repository repository = new Repository(_connectionString);
            return repository.GetPeople();
        }
        [Route("deleteAll")]
        public void DeleteAll()
        {
            Repository repository = new Repository(_connectionString);
            repository.DeleteAll();
        }
        [HttpGet]
        [Route("createCsvFile")]
        public IActionResult CreateCsvFile(int amount)
        {
            Csv getCsv = new Csv();
            string CsvFile = getCsv.GetCsvFile(amount);
            byte[] bytes = Encoding.UTF8.GetBytes(CsvFile);
            return File(bytes, "text/csv", $"{amount} People.csv");
        }

        [HttpPost]
        [Route("uploadCsvFile")]

        public void Upload(FileInfo fileInfo)
        {
            int index = fileInfo.Base64File.IndexOf(",") + 1;
            string base64 = fileInfo.Base64File.Substring(index);
            byte[] filebytes = Convert.FromBase64String(base64);List<Person> people = GetFromCsvBytes(filebytes);
            Repository repository = new Repository(_connectionString);
            repository.AddPeople(people);
        }
        static List<Person> GetFromCsvBytes(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);
            var streamReader = new StreamReader(memoryStream);
            using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }
    }

}
