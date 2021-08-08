using BuildProperties.CrossCutting.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Business.Interface
{
    public interface IPropertyImage
    {
        public long Create(PropertyImageAM entity);
        public int Count();
        public int Count(Expression<Func<PropertyImageAM, bool>> predicate);
        public PropertyImageAM Get(long id);
        public List<PropertyImageAM> Get();
        public List<PropertyImageAM> Get(Expression<Func<PropertyImageAM, bool>> predicate);
        public PropertyImageAM GetFirst(Expression<Func<PropertyImageAM, bool>> predicate);
        public void Update(PropertyImageAM entity);
    }
}
