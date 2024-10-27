using Sofa.CourseManagement.SharedKernel.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace Sofa.CourseManagement.Application.Contract.Posts.Converter
{
	public static class ConverterExtentions
	{
		public static T Parse<T>(this string value)
		{
			var deserializeOptions = new JsonSerializerOptions();
			deserializeOptions.Converters.Add(new CustomLongToStringConverter());

			var convertedValue = JsonSerializer.Deserialize<T>(value, deserializeOptions);

			if (convertedValue == null)
				throw new InvalidCastException(nameof(T));

			return convertedValue;
		}

		public static void IsValid<T>(this string? json)
		{
			if (string.IsNullOrEmpty(json))
				throw new ArgumentNullException(nameof(T));

			var deserializeOptions = new JsonSerializerOptions();
			deserializeOptions.Converters.Add(new CustomLongToStringConverter());

			object? deserializedObject = JsonSerializer.Deserialize(json, typeof(T), deserializeOptions);

			if (deserializedObject == null)
				throw new InvalidCastException(nameof(T));

			var validationContext = new ValidationContext(deserializedObject);
			var validationResult = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(deserializedObject, validationContext, validationResult, true);

			if (!isValid)
				throw new InvalidCastException(string.Join(",", validationResult.Select(s => s.ErrorMessage)));
		}
	}
}
