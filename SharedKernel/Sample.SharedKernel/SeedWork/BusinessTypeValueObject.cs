using Sofa.CourseManagement.SharedKernel.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sofa.CourseManagement.SharedKernel.SeedWork
{
	public abstract class BusinessTypeValueObject<TEnum> : ValueObject where TEnum : Enum
	{
		private string _title;

		public TEnum Value { get; private set; }

		public string Title => _title;

		protected internal BusinessTypeValueObject()
		{
		}

		public BusinessTypeValueObject(TEnum value)
		{
			Type typeFromHandle = typeof(TEnum);
			if (!typeFromHandle.IsEnumDefined(value))
			{
				throw new BusinessException(typeFromHandle.Name + " value is not valid");
			}

			SetValue(value);
		}

		private void SetValue(TEnum value)
		{
			Value = value;
			_title = GetDisplayName(Value);
		}

		public int Code()
		{
			return Convert.ToInt32(Value.ToString("D"));
		}

		public string Name()
		{
			return Value.ToString();
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		private static string GetDisplayName(Enum enu)
		{
			Type type = enu.GetType();
			MemberInfo[] member = type.GetMember(enu.ToString());
			if (member != null && member.Length != 0)
			{
				object[] customAttributes = member[0].GetCustomAttributes(typeof(DisplayAttribute), inherit: false);
				if (customAttributes != null && customAttributes.Length != 0)
				{
					return ((DisplayAttribute)customAttributes[0]).Name;
				}
			}

			return enu.ToString();
		}
	}

}
