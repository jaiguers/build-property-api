using BuildProperties.CrossCutting.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IOwer
    {
        public int Count();
        public long Create(OwnerAM entity);
        public int Count(Expression<Func<OwnerAM, bool>> predicate);
        public OwnerAM Get(long id);
        public List<OwnerAM> Get();
        public List<OwnerAM> Get(Expression<Func<OwnerAM, bool>> predicate);
        public OwnerAM GetFirst(Expression<Func<OwnerAM, bool>> predicate);
        public void Update(OwnerAM entity);

    }
}
