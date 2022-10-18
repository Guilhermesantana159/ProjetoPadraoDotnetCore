using System.Linq.Dynamic.Core;
using Aplication.DTO.Grid;
using Aplication.Enum;

namespace Aplication.Utils.FilterDynamic;

public static class Filters
{
    public static IQueryable<TSource> AplicarFiltrosDinamicos<TSource>(this IQueryable<TSource> source,
        List<QueryFilters>? queryFilter)
    {
        if (queryFilter == null || !queryFilter.Any())
            return source;

        foreach (var filter in queryFilter)
        {
            string typeField = null!;
            
            switch (filter.Type)
            {
                case "string":
                    typeField = ETypeFilter.Contains.ToString();
                    break;
                case "number":
                    typeField = ETypeFilter.Equals.ToString();
                    break;
                case "data":
                    typeField = ETypeFilter.Greater.ToString();
                    break;
            }

            if (string.IsNullOrEmpty(typeField))
                return source;
            
            source = source.Where(filter.Field + '.' + typeField + "(" + filter.Value + ")");

        }
        
        return source;
    }    
}