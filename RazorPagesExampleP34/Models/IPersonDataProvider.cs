namespace RazorPagesExampleP34.Models;

public interface IPersonDataProvider
{
    public List<Person> GetAllPeople();

    public Person GetPersonById(int id);

    public void DeletePerson(int id);

    public void Add(Person person);

    public void SaveChanges();
}
