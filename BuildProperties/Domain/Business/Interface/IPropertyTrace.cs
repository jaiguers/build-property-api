using BuildProperties.CrossCutting.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.Interface
{
    public interface IPropertyTrace
    {
        public long Create(PropertyTraceAM entity);
        public int Count();
        public int Count(Expression<Func<PropertyTraceAM, bool>> predicate);
        public PropertyTraceAM Get(long id);
        public List<PropertyTraceAM> Get();
        public List<PropertyTraceAM> Get(Expression<Func<PropertyTraceAM, bool>> predicate);
        public PropertyTraceAM GetFirst(Expression<Func<PropertyTraceAM, bool>> predicate);
        public void Update(PropertyTraceAM entity);
    }
}
