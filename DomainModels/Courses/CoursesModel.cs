﻿using System.Collections.Generic;
using SampleEntityFramework.DomainModels.Common;

namespace SampleEntityFramework.DomainModels.Courses
{
    public class CoursesModel
    {
        public IEnumerable<CourseListModel> Courses { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}