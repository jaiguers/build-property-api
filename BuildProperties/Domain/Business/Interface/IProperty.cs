using BuildProperties.CrossCutting.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IProperty
    {
        public int Count();
        public long Create(PropertyAM entity);
        public int Count(Expression<Func<PropertyAM, bool>> predicate);
        public PropertyAM Get(long id);
        public List<PropertyAM> Get();
        public List<PropertyAM> Get(Expression<Func<PropertyAM, bool>> predicate);
        public PropertyAM GetFirst(Expression<Func<PropertyAM, bool>> predicate);
        public void Update(PropertyAM entity);
    }
}
