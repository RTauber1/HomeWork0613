using HomeWork0613.Data;
using HomeWork0614.Web;
using System.Collections.Generic;
using System.Linq;

public class Repository
{
    private readonly string _connectionString;

    public static object Faker { get; private set; }

    public Repository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Person> GetPeople()
    {
        using Context context = new Context(_connectionString);
        return context.Person.ToList();
    }
    public void DeleteAll()
    {
        List<Person> person = GetPeople();
        using Context context = new Context(_connectionString);
        context.Person.RemoveRange(person);
        context.SaveChanges();
    }

    public void AddPeople(List<Person> list )
    {
        using Context context = new Context(_connectionString);
        context.Person.AddRange(list);
        context.SaveChanges();
    }

}



