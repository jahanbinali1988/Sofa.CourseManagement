using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.Institutes
{
    public class Institute :  Entity<Guid>, IAggregateRoot
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
        public void AssignTitle(string title)
        {
            this.Title = title;
        }
        public void AssignCode(string code)
        {
            this.Code = code;
        }
        public void AssignWebsiteUrl(string websiteUrl)
        {
            this.WebsiteUrl = websiteUrl;
        }
        public void AssignFields(IEnumerable<Field> fields)
        {
            if (this.Fields.Any())
                this.Fields.ToList().AddRange(fields);
            else
                this.Fields = fields.ToArray();
        }

        public static Institute CreateInstance(Guid id, string title, string code, string websiteUrl, bool isActive, string description)
        {
            var institute = new Institute();

            institute.AssignId(id);
            institute.AssignTitle(title);
            institute.AssignCode(code);
            institute.AssignWebsiteUrl(websiteUrl);

            return institute;
        }
    }
}
