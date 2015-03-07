using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleEntityFramework.DomainModels.Common
{
    public abstract class PaginatedModel<TModel>
    {
        public const int DefaultPageSize = 10;

        public const int MinPageSize = 1;
        public const int MaxPageSize = 100;

        public IEnumerable<TModel> Data { get; private set; }

        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get { return (int)Math.Ceiling(TotalItems / (float)PageSize); } }

        private int SkipAmount { get { return (Page - 1) * PageSize; } }
        private bool ShouldSkip { get { return Page > 1; } }

        protected PaginatedModel() { } 

        protected PaginatedModel(IQueryable<TModel> data, int? page, int? pageSize)
        {
            ApplyPaging(data, page, pageSize);
        }

        protected void ApplyPaging(IQueryable<TModel> data, int? page, int? pageSize)
        {
            Page = page.HasValue && page > 1 ? page.Value : 1;
            PageSize = pageSize ?? DefaultPageSize;
            TotalItems = data.Count();

            if (pageSize < MinPageSize) PageSize = MinPageSize;
            else if (pageSize > MaxPageSize) PageSize = MaxPageSize;

            Data = (ShouldSkip ? data.Skip(SkipAmount) : data).Take(PageSize).ToList();
        }
    }
}