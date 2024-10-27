﻿using Sofa.CourseManagement.Domain.LessonPlans.Constants;

namespace Sofa.CourseManagement.Domain.LessonPlans.Services
{
	public interface ITitleLengthService
	{
		bool IsValid(string value);
	}
	public class TitleLengthService : ITitleLengthService
	{
		public bool IsValid(string value)
		{
			if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringTitleLength)
				return false;

			return true;
		}
	}
}