using Azure;
using ClientApp.Dto;

namespace ClientApp.Data
{
    public class ApiResponse
    {
        public int Count { get; set; }
        public string RequestId { get; set; }
        public List<Result> Results { get; set; }
        public string Status { get; set; }

    }
}
