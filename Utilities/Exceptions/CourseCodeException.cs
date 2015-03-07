using System;

namespace SampleEntityFramework.Utilities.Exceptions
{
    public class CourseCodeException : Exception
    {
        public CourseCodeException() : base(@"The course code is already taken.") { }
    }
}