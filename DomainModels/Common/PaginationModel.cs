using System;

namespace SampleEntityFramework.DomainModels.Common
{
    public class PaginationModel
    {
        public const int DefaultPageSize = 3;

        public const int MinPageSize = 1;
        public const int MaxPageSize = 100;

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling(TotalItems / (float)PageSize); } }
        public int SkipAmount { get { return (Page - 1) * PageSize; } }
        public bool ShouldSkip { get { return Page > 1; } }

        protected PaginationModel() { }

        public static PaginationModel Create(int totalItems, int? page = 1, int? pageSize = DefaultPageSize)
        {
            var model = new PaginationModel
            {
                PageSize = pageSize ?? DefaultPageSize,
                Page = page.HasValue && page > 1 ? page.Value : 1,
                TotalItems = totalItems,
            };

            if (pageSize < MinPageSize) model.PageSize = MinPageSize;
            else if (pageSize > MaxPageSize) model.PageSize = MaxPageSize;

            return model;
        }
    }
}