namespace Sofa.CourseManagement.Application.Contract.Shared
{
	public class GetListQueryBase
    {
		public GetListQueryBase(int offset, int count, string keyword)
		{
			Offset = offset;
			Count = count;
			Keyword = keyword;
		}

		public string Keyword { get; set; }
		public int Offset { get; set; } = 1;
		public int Count { get; set; } = 10;
	}
}
