using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class PropertyImageRepository : BaseRepository<PropertyImage>
    {
        public PropertyImageRepository(RealEstateContext context) : base(context)
        {

        }

        public override int Count()
        {
            try
            {
                return context.PropertyImages.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<PropertyImage, bool>> predicate)
        {
            try
            {
                return context.PropertyImages.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(PropertyImage entity)
        {
            try
            {
                context.PropertyImages.Add(entity);
                context.SaveChanges();

                return entity.IdPropertyImage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override PropertyImage Get(long id)
        {
            try
            {
                return context.PropertyImages.Where(j => j.IdPropertyImage == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyImage> Get()
        {
            try
            {
                return context.PropertyImages.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyImage> Get(Expression<Func<PropertyImage, bool>> predicate)
        {
            try
            {
                return context.PropertyImages.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PropertyImage> Get(Expression<Func<PropertyImage, bool>> predicate, int page, int size, Func<PropertyImage, object> filterAttribute, bool descending)
        {
            return descending ? context.PropertyImages.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.PropertyImages.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override PropertyImage GetFirst(Expression<Func<PropertyImage, bool>> predicate)
        {
            try
            {
                return context.PropertyImages.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(PropertyImage entity)
        {
            try
            {
                context.PropertyImages.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
