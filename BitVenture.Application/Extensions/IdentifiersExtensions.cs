using System.Collections.Generic;
using System.Linq;
using BitVenture.Application.Models;

namespace BitVenture.Application.Extensions
{
    public static class IdentifiersExtensions
    {
        public static string GetValue(this IEnumerable<Identifier> identifiers, string key) 
        {
            var value = identifiers.SingleOrDefault(x => x.Key.Equals(key))?.Value;
            return value;
        }
    }
}
