namespace ZooManagement.Models;
public class AnimalDetail
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public string DOB { get; set; }
    public string DateAcquired { get; set; }
    public AnimalType Type { get; set; } //create foreign key

    
}