using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class OwnerRepository : BaseRepository<Owner>
    {
        public OwnerRepository(RealEstateContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.Owners.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Owner, bool>> predicate)
        {
            try
            {
                return context.Owners.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Owner entity)
        {
            try
            {
                context.Owners.Add(entity);
                context.SaveChanges();

                return entity.IdOwner;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Owner Get(long id)
        {
            try
            {
                return context.Owners.Where(j => j.IdOwner == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Owner> Get()
        {
            try
            {
                return context.Owners.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Owner> Get(Expression<Func<Owner, bool>> predicate)
        {
            try
            {
                return context.Owners.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Owner> Get(Expression<Func<Owner, bool>> predicate, int page, int size, Func<Owner, object> filterAttribute, bool descending)
        {
            return descending ? context.Owners.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Owners.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Owner GetFirst(Expression<Func<Owner, bool>> predicate)
        {
            try
            {
                return context.Owners.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Owner entity)
        {
            try
            {
                context.Owners.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
