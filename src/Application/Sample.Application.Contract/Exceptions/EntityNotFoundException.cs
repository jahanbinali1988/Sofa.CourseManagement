﻿using System;

namespace Sofa.CourseManagement.Application.Contract.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
