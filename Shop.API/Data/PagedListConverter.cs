using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Data
{
    public class PagedListConverter<TSource, TDest> : ITypeConverter<PagedList<TSource>, PagedList<TDest>>
    {
        private readonly IMapper mapper;

        public PagedListConverter(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public PagedList<TDest> Convert(PagedList<TSource> source, PagedList<TDest> destination, ResolutionContext context)
        {
            return new PagedList<TDest>(source.Select(item => mapper.Map<TSource, TDest>(item)), source.PageNumber, source.PageSize);
        }
    }
}
