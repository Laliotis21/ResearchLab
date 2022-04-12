using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchLab_Library.Abstractions
{
    public abstract class Entity<TKey>
        where TKey : IComparable, IComparable<TKey> , IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
