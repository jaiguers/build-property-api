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
    public class PropertyBO : IProperty
    {
        private readonly RealEstateContext context;
        private readonly IMapper mapper;

        public PropertyBO(RealEstateContext context)
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
        /// Create Property
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public long Create(PropertyAM entity)
        {
            try
            {
                var Property = mapper.Map<Property>(entity);

                IRepository<Property> repo = new PropertyRepository(context);
                return repo.Create(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the Property count
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Property> repo = new PropertyRepository(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the Property count according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count(Expression<Func<PropertyAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Property, bool>>>(predicate);

                IRepository<Property> repo = new PropertyRepository(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Property for id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyAM Get(long id)
        {
            try
            {
                IRepository<Property> repo = new PropertyRepository(context);
                var Property = repo.Get(id);

                return mapper.Map<PropertyAM>(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Property list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyAM> Get()
        {
            try
            {
                IRepository<Property> repo = new PropertyRepository(context);
                var Property = repo.Get();

                return mapper.Map<List<PropertyAM>>(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Property list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyAM> Get(Expression<Func<PropertyAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Property, bool>>>(predicate);

                IRepository<Property> repo = new PropertyRepository(context);
                var Property = repo.Get(where);

                return mapper.Map<List<PropertyAM>>(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get Property list according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyAM GetFirst(Expression<Func<PropertyAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Property, bool>>>(predicate);

                IRepository<Property> repo = new PropertyRepository(context);
                var Property = repo.GetFirst(where);

                return mapper.Map<PropertyAM>(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update Property
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public void Update(PropertyAM entity)
        {
            try
            {
                var Property = mapper.Map<Property>(entity);

                IRepository<Property> repo = new PropertyRepository(context);
                repo.Update(Property);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
