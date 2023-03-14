
namespace ZooManagement.Models;

public class AnimalType
{
    public int Id { get; set; }
    public string Species { get; set; }
    public string Classification { get; set; }

    public AnimalType(string species, string classification)
    {
        Species = species;
        Classification = classification;
    }


}