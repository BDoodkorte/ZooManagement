namespace ZooManagement.Models
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }


    public class AnimalSearchRequest : SearchRequest
    {
        public string? Species { get; set; }
        public string? Classification { get; set; }
        public int? Age { get; set; }
        public string? DateAcquired { get; set; }

        public override string Filters
        {
            get
            {
                var filters = "";

                filters += $"&Species={Species}";

                filters += $"&Classification={Classification}";

                filters += $"&Age={Age}";

                filters += $"&DateAcquired={DateAcquired}";

                return filters;
            }
        }
    }
}