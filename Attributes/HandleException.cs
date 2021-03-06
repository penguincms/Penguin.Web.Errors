﻿using System;

namespace Penguin.Web.Errors.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class HandleExceptionAttribute : Attribute
    {
        public Type[] ToHandle { get; set; }

        public HandleExceptionAttribute(params Type[] toHandle)
        {
            if (toHandle is null || toHandle.Length == 0)
            {
                throw new ArgumentException("Must specify at least one exception type to handle", nameof(toHandle));
            }

            foreach (Type t in toHandle)
            {
                if (!typeof(Exception).IsAssignableFrom(t))
                {
                    throw new Exception($"Type {t} is not an Exception type");
                }
            }
            this.ToHandle = toHandle ?? throw new ArgumentNullException(nameof(toHandle));
        }
    }
}