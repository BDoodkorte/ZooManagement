using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models;

namespace ZooManagement.Models
{
    public class AnimalModel : ListResponse<AnimalResponse>
    {
        private AnimalModel(SearchRequest search, IEnumerable<AnimalResponse> items, int totalNumberOfItems)
            : base(search, items, totalNumberOfItems, "animalList") { }

        public static AnimalModel Create(SearchRequest searchRequest, IEnumerable<AnimalDetail> animals, int totalNumberOfItems)
        {
            var animal = animals.Select(p => new AnimalResponse(p));
            return new AnimalModel(searchRequest, animal, totalNumberOfItems);
        }
    }
}