namespace Sofa.CourseManagement.RestApi.Models
{
    public class GetListRequest
    {
        public string Keyword { get; set; }

        public virtual int Offset { get; set; }

        public virtual int Count { get; set; }
    }
}
