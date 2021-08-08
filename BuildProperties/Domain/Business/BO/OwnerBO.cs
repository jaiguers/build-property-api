using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BuildProperties.CrossCutting.ApiModel;
using Domain.Business.Interface;
using Domain.Business.Profiles;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.BO
{
    public class OwnerBO : IOwer
    {
        private readonly RealEstateContext context;
        private readonly IMapper mapper;

        public OwnerBO(RealEstateContext context)
        {
            this.context = context;

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile<AdminProfile>();
            });

            mapper = new Mapper(mapConfig);
        }

        /// <summary>
        /// Create Owner
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public long Create(OwnerAM entity)
        {
            try
            {
                var Owner = mapper.Map<Owner>(entity);

                IRepository<Owner> repo = new OwnerRepository(context);
                return repo.Create(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the owner count
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Owner> repo = new OwnerRepository(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the owner count according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count(Expression<Func<OwnerAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Owner, bool>>>(predicate);

                IRepository<Owner> repo = new OwnerRepository(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get owner for id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public OwnerAM Get(long id)
        {
            try
            {
                IRepository<Owner> repo = new OwnerRepository(context);
                var Owner = repo.Get(id);

                return mapper.Map<OwnerAM>(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Owner list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<OwnerAM> Get()
        {
            try
            {
                IRepository<Owner> repo = new OwnerRepository(context);
                var Owner = repo.Get();

                return mapper.Map<List<OwnerAM>>(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Owner list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<OwnerAM> Get(Expression<Func<OwnerAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Owner, bool>>>(predicate);

                IRepository<Owner> repo = new OwnerRepository(context);
                var Owner = repo.Get(where);

                return mapper.Map<List<OwnerAM>>(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Owner list according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public OwnerAM GetFirst(Expression<Func<OwnerAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Owner, bool>>>(predicate);

                IRepository<Owner> repo = new OwnerRepository(context);
                var Owner = repo.GetFirst(where);

                return mapper.Map<OwnerAM>(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update Owner
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public void Update(OwnerAM entity)
        {
            try
            {
                var Owner = mapper.Map<Owner>(entity);

                IRepository<Owner> repo = new OwnerRepository(context);
                repo.Update(Owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
