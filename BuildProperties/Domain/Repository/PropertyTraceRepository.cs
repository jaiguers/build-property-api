using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Repository
{
    public class PropertyTraceRepository : BaseRepository<PropertyTrace>
    {
        public PropertyTraceRepository(RealEstateContext context) : base(context)
        {

        }

        public override int Count()
        {
            try
            {
                return context.PropertyTraces.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<PropertyTrace, bool>> predicate)
        {
            try
            {
                return context.PropertyTraces.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(PropertyTrace entity)
        {
            try
            {
                context.PropertyTraces.Add(entity);
                context.SaveChanges();

                return entity.IdPropertyTrace;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override PropertyTrace Get(long id)
        {
            try
            {
                return context.PropertyTraces.Where(j => j.IdPropertyTrace == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyTrace> Get()
        {
            try
            {
                return context.PropertyTraces.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyTrace> Get(Expression<Func<PropertyTrace, bool>> predicate)
        {
            try
            {
                return context.PropertyTraces.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyTrace> Get(Expression<Func<PropertyTrace, bool>> predicate, int page, int size, Func<PropertyTrace, object> filterAttribute, bool descending)
        {
            return descending ? context.PropertyTraces.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.PropertyTraces.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override PropertyTrace GetFirst(Expression<Func<PropertyTrace, bool>> predicate)
        {
            try
            {
                return context.PropertyTraces.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(PropertyTrace entity)
        {
            try
            {
                context.PropertyTraces.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
