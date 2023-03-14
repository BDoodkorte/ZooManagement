using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models;
using ZooManagement.Repositories;

namespace ZooManagement.Data
{
    public static class SampleAnimals
    {
        public const int NumberOfAnimals = 100;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "Nellie", "Bob", "El", "Boris", "Sophie", "Adelaide", "Blue", "Zuzu", "Delilah", "Naomi" },
            new List<string> { "Female", "Male"},
            new List<string> { "01/01/2022", "01/01/2021", "01/01/2020", "06/04/1995" },
            new List<string> { "01/01/2023", "02/02/2023", "03/03/2023", "15/11/2000" },
        };

        private static readonly IList<AnimalType> Data2 = new List<AnimalType>
        {
            new AnimalType("Elephant","Asian"),
            new AnimalType("Owl","Barn"),
            new AnimalType("Butterfly","Monarch"),
            new AnimalType("Beetle","Dung"),
        };

        public static IEnumerable<AnimalDetail> GetAnimals()
        {
            return Enumerable.Range(0, NumberOfAnimals).Select(CreateRandomAnimal);
        }

        private static AnimalDetail CreateRandomAnimal(int index)
        {
            return new AnimalDetail
            {
                Name = Data[0][new Random().Next(10)],
                Sex = Data[1][new Random().Next(2)],
                DOB = Data[2][new Random().Next(4)],
                DateAcquired = Data[3][new Random().Next(4)],
                Type = Data2[new Random().Next(4)]
            };
        }
    }
}
