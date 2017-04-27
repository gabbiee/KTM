using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTM.Data.Mocks
{
    using System.Data.Entity;

    public class FakeDbSet<T> : DbSet<T>, IEnumerable<T>, IQueryable where T : class

    {
        protected HashSet<T> set;
        protected IQueryable query;

        public FakeDbSet()
        {
            this.set = new HashSet<T>();
            this.query = this.set.AsQueryable();
        }

        public override T Add(T entity)
        {
            this.set.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            this.set.Remove(entity);
            return entity;
        }

     
        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return this.query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }
    }
}
