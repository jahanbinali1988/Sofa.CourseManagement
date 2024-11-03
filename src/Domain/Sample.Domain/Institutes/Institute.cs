using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes
{
    public class Institute : Entity<Guid>, IAggregateRoot
	{
		public Title Title { get; private set; }
		public WebsiteUrl WebsiteUrl { get; private set; }
		public Address Address { get; private set; }
		public Code Code { get; private set; }

		public ICollection<Field> Fields { get; set; }
		public ICollection<User> Users { get; set; }

		private Institute()
		{
			Fields = new List<Field>();
			Users = new List<User>();
		}

		public void AssignAddress(Address address)
		{
			if (Address is null)
			{
				Address = new Address();
			}

			var existed = this.Address.Equals(address);
			if (!existed)
			{
				this.Address = address;
			}
		}
		private void AssignTitle(string title)
		{
			this.Title = title;
		}
		private void AssignCode(string code)
		{
			this.Code = code;
		}
		private void AssignWebsiteUrl(string websiteUrl)
		{
			this.WebsiteUrl = websiteUrl;
		}
		public void AssignField(Field field)
		{
			this.Fields.Add(field);
		}

		public static Institute CreateInstance(Guid id, string title, string code, string websiteUrl)
		{
			var institute = new Institute();

			institute.AssignId(id);
			institute.AssignTitle(title);
			institute.AssignCode(code);
			institute.AssignWebsiteUrl(websiteUrl);

			return institute;
		}

		public void Update(string title, string code, string websiteUrl)
		{
			AssignTitle(title);
			AssignCode(code);
			AssignWebsiteUrl(websiteUrl);
		}

		public void Delete(Field field)
		{
			Fields.Remove(field);
		}
	}
}
