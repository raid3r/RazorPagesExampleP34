namespace RazorPagesExampleP34.Models;

public interface IPersonDataProvider
{
    public List<Person> GetAllPeople();

    public Person GetPersonById(int id);

    public void SaveChanges();
}
