using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories
{
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;
            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        public PagedList(IQueryable<T> source, int? pageIndex, int? pageSize)
        {
            if (pageIndex == null) pageIndex = 1;
            if (pageSize == null) pageSize = 10;
            TotalCount = source.Count();
            PageSize = pageSize.Value;
            PageIndex = pageIndex.Value;
            if (HasPreviousPage == false) pageIndex = 1;
            if (HasNextPage == false) pageIndex = TotalPages;
            int BeforePageIndex = pageIndex.Value - 1;
            if (BeforePageIndex < 0) BeforePageIndex = 0;
            AddRange(source.Skip((BeforePageIndex) * pageSize.Value).Take(pageSize.Value));
        }
    }
}
