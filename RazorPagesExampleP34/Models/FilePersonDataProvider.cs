using System.Text.Json;

namespace RazorPagesExampleP34.Models;

public class FilePersonDataProvider : IPersonDataProvider
{
    public FilePersonDataProvider()
    {
        LoadFromFile();
    }
    private List<Person> _people = [];
    private string _filename = "persondata.json";


    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_people, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filename, json);
    }

    private void LoadFromFile()
    {
        if (File.Exists(_filename))
        {
            _people = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(_filename));
        }
        else
        {
            _people = [];
        }
    }


    public void Add(Person person)
    {
        if (_people.Any())
        {
            person.Id = _people.Max(p => p.Id) + 1;
        }
        else
        {
            person.Id = 1;
        }

        _people.Add(person);
    }

    public void DeletePerson(int id)
    {
        var person = _people.First(p => p.Id == id);
        _people.Remove(person);
    }

    public List<Person> GetAllPeople()
    {
        return _people;
    }

    public Person GetPersonById(int id)
    {
        return _people.First(p => p.Id == id);
    }

    public void SaveChanges()
    {
        SaveToFile();
    }
}
