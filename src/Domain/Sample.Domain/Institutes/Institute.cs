using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.Entities.Users;
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

		private readonly List<Field> _fields;
		public IReadOnlyList<Field> Fields => _fields.AsReadOnly();

		private readonly List<InstituteUser> _instituteUsers;
		public IReadOnlyList<InstituteUser> InstituteUsers => _instituteUsers.AsReadOnly();
        
		private Institute() : base()
		{
			_fields = new List<Field>();
			_instituteUsers = new List<InstituteUser>();
		}

		private void AssignAddress(Address address)
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

		public static Institute CreateInstance(Guid id, string title, string code, string websiteUrl)
		{
			var institute = new Institute();

			institute.AssignId(id);
			institute.AssignTitle(title);
			institute.AssignCode(code);
			institute.AssignWebsiteUrl(websiteUrl);

			institute.AddDomainEvent(new AddInstituteDomainEvent(institute.Id, institute.Title.Value, institute.WebsiteUrl.Value, institute.Code.Value));

			return institute;
		}
		public void Update(string title, string code, string websiteUrl)
		{
			AssignTitle(title);
			AssignCode(code);
			AssignWebsiteUrl(websiteUrl);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateInstituteDomainEvent(Id, Title.Value, WebsiteUrl.Value, Address?.ToString(), Code.Value));
		}
		public void UpdateAddress(Address address)
		{
			AssignAddress(address);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateInstituteDomainEvent(Id, Title.Value, WebsiteUrl.Value, Address.ToString(), Code.Value));
		}
		public void Delete()
		{
			base.MarkAsDeleted();
			AddDomainEvent(new DeleteInstituteDomainEvent(Id));
		}
		public void AddField(Field field)
		{
			this._fields.Add(field);
		}
		public void DeleteField(Field field)
		{
			_fields.Remove(field);
		}
		public void AddUser(InstituteUser instituteUser)
		{
			_instituteUsers.Add(instituteUser);
		}
		public void DeleteUser(InstituteUser instituteUser)
		{
			_instituteUsers.Remove(instituteUser);
		}
	}
}
