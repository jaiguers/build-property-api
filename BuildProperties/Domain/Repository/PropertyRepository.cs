using Domain.Models;
using Domain.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class PropertyRepository : BaseRepository<Property>
    {
        public PropertyRepository(RealEstateContext context) : base(context)
        {

        }

        public override int Count()
        {
            try
            {
                return context.Properties.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Property, bool>> predicate)
        {
            try
            {
                return context.Properties.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Property entity)
        {
            try
            {
                context.Properties.Add(entity);
                context.SaveChanges();

                return entity.IdProperty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Property Get(long id)
        {
            try
            {
                return context.Properties.Where(j => j.IdProperty == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Property> Get()
        {
            try
            {
                return context.Properties.Include(j=>j.Owner).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Property> Get(Expression<Func<Property, bool>> predicate)
        {
            try
            {
                return context.Properties.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Property> Get(Expression<Func<Property, bool>> predicate, int page, int size, Func<Property, object> filterAttribute, bool descending)
        {
            return descending ? context.Properties.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Properties.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Property GetFirst(Expression<Func<Property, bool>> predicate)
        {
            try
            {
                return context.Properties.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Property entity)
        {
            try
            {
                context.Properties.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
