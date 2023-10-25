using SıgnalR.API.Enums;

namespace SıgnalR.API.Models
{
    public class Covid
    {
        public int ID { get; set; }
        public City City { get; set; }
        public int Count { get; set; }
        public DateTime CovidDate { get; set; }

    }
}
