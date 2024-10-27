using System;
using System.ComponentModel;
using System.Globalization;

namespace Sofa.CourseManagement.Application.Contract.Posts.Converter
{
	public class PostConverter<T> : TypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var casted = value as string;

			casted.IsValid<T>();

			return casted!.Parse<T>()!;
		}
	}
}
