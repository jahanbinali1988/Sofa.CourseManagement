namespace Sofa.CourseManagement.Application.Contract.Shared
{
	public abstract class GetListQueryBase
    {
		public GetListQueryBase(int offset, int count, string keyword)
		{
			Offset = offset;
			Count = count;
			Keyword = keyword;
		}

		public string Keyword { get; set; }
		public virtual int Offset { get; set; }
        public virtual int Count { get; set; }
	}
}
