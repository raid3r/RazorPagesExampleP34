namespace RazorPagesExampleP34.Models;

public class PersonDataProvider: IPersonDataProvider
{
    private readonly List<Person> people = [
        new Person
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Profession = "Software Developer",
            BirthDate = new DateTime(1990, 1, 1),
            Skills = new List<Skill>
            {
                new Skill { Id = 1, Title = "C#", Proficiency = 90 },
                new Skill { Id = 2, Title = "ASP.NET Core", Proficiency = 85 },
                new Skill { Id = 3, Title = "Razor Pages", Proficiency = 80 }
            }
        },
        new Person
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            Profession = "Web Designer",
            BirthDate = new DateTime(1985, 5, 15),
            Skills = new List<Skill>
            {
                new Skill { Id = 4, Title = "HTML", Proficiency = 95 },
                new Skill { Id = 5, Title = "CSS", Proficiency = 90 },
                new Skill { Id = 6, Title = "JavaScript", Proficiency = 85 }
            }
        }
        ];


    public List<Person> GetAllPeople()
    {
        return people;
    }

    public Person GetPersonById(int id)
    {
        return people.First(p => p.Id == id);
    }

    public void SaveChanges()
    {
        // In-memory implementation does not require saving changes
    }
}
