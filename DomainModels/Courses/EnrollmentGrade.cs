using System;
using System.Collections.Generic;
using System.Linq;
using SampleEntityFramework.Utilities;

namespace SampleEntityFramework.DomainModels.Courses
{
    public abstract class EnrollmentGrade : Enumeration
    {
        public static readonly EnrollmentGrade A = new GradeA();
        public static readonly EnrollmentGrade B = new GradeB();
        public static readonly EnrollmentGrade C = new GradeC();
        public static readonly EnrollmentGrade D = new GradeD();
        public static readonly EnrollmentGrade F = new GradeF();
        public static readonly EnrollmentGrade NotSet = new GradeNotSet();

        public abstract decimal Points { get; }

        private EnrollmentGrade(int value, string displayName) : base(value, displayName) { }

        #region Parsing

        public static IEnumerable<EnrollmentGrade> GetAll()
        {
            return new[] { A, B, C, D, F, NotSet };
        }

        public static EnrollmentGrade FromValue(int value)
        {
            return Parse(value, "value", x => x.Value == value);
        }

        public static EnrollmentGrade FromDisplayName(string displayName)
        {
            return Parse(displayName, "display name", x => x.DisplayName == displayName);
        }

        private static EnrollmentGrade Parse<TValue>(TValue value, string description,
            Func<EnrollmentGrade, bool> predicate)
        {
            var item = GetAll().FirstOrDefault(predicate);
            if (item != null) return item;
            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(EnrollmentGrade));
            throw new ApplicationException(message);
        }

        #endregion

        #region Grade Implementations

        private class GradeNotSet : EnrollmentGrade
        {
            public GradeNotSet() : base(0, "Not Set") { }

            public override decimal Points
            {
                get { return -1.0m; }
            }
        }

        private class GradeA : EnrollmentGrade
        {
            public GradeA() : base(1, "A") { }

            public override decimal Points
            {
                get { return 4.0m; }
            }
        }

        private class GradeB : EnrollmentGrade
        {
            public GradeB() : base(2, "B") { }

            public override decimal Points
            {
                get { return 3.0m; }
            }
        }

        private class GradeC : EnrollmentGrade
        {
            public GradeC() : base(3, "C") { }

            public override decimal Points
            {
                get { return 2.0m; }
            }
        }

        private class GradeD : EnrollmentGrade
        {
            public GradeD() : base(4, "D") { }

            public override decimal Points
            {
                get { return 1.0m; }
            }
        }

        private class GradeF : EnrollmentGrade
        {
            public GradeF() : base(5, "F") { }

            public override decimal Points
            {
                get { return 0.0m; }
            }
        }

        #endregion
    }
}