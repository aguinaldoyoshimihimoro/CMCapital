using System.Collections.Generic;

namespace CMCapital.Domain
{
    public interface IEntity
    {
        int Id { get; set; }

        State State { get; set; }
    }

    public class EntityComparer<T> : IEqualityComparer<T> where T : IEntity
    {
        public bool Equals(T x, T y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(T obj)
        {
            return obj.Id;
        }
    }

    public enum State
    {
        Unchanged = 1,
        Deleted   = 2,
        Modified  = 3,
        Added     = 4
    }
}