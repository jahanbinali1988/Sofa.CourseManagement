namespace Sofa.CourseManagement.RestApi.Models
{
    public class GetListRequest
    {
        public string? Keyword { get; set; } = "";

        public int Offset { get; set; } = 0;

        public int Count { get; set; } = 10;
    }
}
