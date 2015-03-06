using System;
using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Common;
using SampleEntityFramework.DomainModels.Courses;

namespace SampleEntityFramework.DomainModels.Students
{
    public class StudentDetailsModel : StudentListModel
    {
        public IEnumerable<CourseEnrollmentListModel> Courses { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}