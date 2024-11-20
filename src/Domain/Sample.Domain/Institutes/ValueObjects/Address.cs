using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.ValueObjects
{
	public class Address : ValueObject
	{
		public String Street { get; internal set; }
		public String City { get; internal set; }
		public String State { get; internal set; }
		public String Country { get; internal set; }
		public String ZipCode { get; internal set; }

		public Address() { }

		public void AssignStreet(string street) { this.Street = street; }
		public void AssignCity(string city) { this.City = city; }
		public void AssignState(string state) { this.State = state; }
		public void AssignCountry(string country) { this.Country = country; }
		public void AssignZipCode(string zipCode) { this.ZipCode = zipCode; }
		public static Address CreateInstance(string street, string city, string state, string country, string zipcode)
		{
			return new Address()
			{
				Street = street,
				City = city,
				State = state,
				Country = country,
				ZipCode = zipcode
			};
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Street;
			yield return City;
			yield return State;
			yield return Country;
			yield return ZipCode;
		}

		public override string ToString()
		{
			return $"{Country} - {City} - {State} - {City} - {ZipCode}";
		}
	}
}
