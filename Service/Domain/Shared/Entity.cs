using System;
using System.Collections.Generic;

namespace PersonalFinanceManagement.Domain.Shared
{
    public abstract class Entity<T> : IEntity<T>
    {
        public abstract T Id { get; }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null))
                return false;
                
            if(this.GetType() != obj.GetType())
                return false;

            var left = obj as Entity<T>;
            if(ReferenceEquals(left, null))
                return false;

            return EqualityComparer<T>.Default.Equals(this.Id, left.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Entity<T> lhs, Entity<T> rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }
        public static bool operator !=(Entity<T> lhs, Entity<T> rhs)
        {
            return !(lhs == rhs);
        }
    }
}
