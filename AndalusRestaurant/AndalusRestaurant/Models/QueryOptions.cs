﻿using System.Linq.Expressions;

namespace AndalusRestaurant.Models
{
    public class QueryOptions<T> where T : class
    {
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> where { get; set; } = null!;
        private string[] includes = Array.Empty<string>();
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }
        public string[] GetIncludes() =>includes;
        public bool HasWhere => where != null;
        public bool HasOrderBy => OrderBy != null;
    }
}
