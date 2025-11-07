namespace RazorPagesExampleP34.Models;

public class PersonDataProvider: IPersonDataProvider
{
    public Person GetPerson()
    {
        return new Person
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
        };
    }

}
