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
    public class PropertyTraceBO : IPropertyTrace
    {
        private readonly RealEstateContext context;
        private readonly IMapper mapper;

        public PropertyTraceBO(RealEstateContext context)
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
        /// Create PropertyTrace
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public long Create(PropertyTraceAM entity)
        {
            try
            {
                var PropertyTrace = mapper.Map<PropertyTrace>(entity);

                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                return repo.Create(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the PropertyTrace count
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the PropertyTrace count according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count(Expression<Func<PropertyTraceAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyTrace, bool>>>(predicate);

                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyTrace for id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyTraceAM Get(long id)
        {
            try
            {
                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                var PropertyTrace = repo.Get(id);

                return mapper.Map<PropertyTraceAM>(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyTrace list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyTraceAM> Get()
        {
            try
            {
                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                var PropertyTrace = repo.Get();

                return mapper.Map<List<PropertyTraceAM>>(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyTrace list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyTraceAM> Get(Expression<Func<PropertyTraceAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyTrace, bool>>>(predicate);

                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                var PropertyTrace = repo.Get(where);

                return mapper.Map<List<PropertyTraceAM>>(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyTrace list according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyTraceAM GetFirst(Expression<Func<PropertyTraceAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyTrace, bool>>>(predicate);

                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                var PropertyTrace = repo.GetFirst(where);

                return mapper.Map<PropertyTraceAM>(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update PropertyTrace
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public void Update(PropertyTraceAM entity)
        {
            try
            {
                var PropertyTrace = mapper.Map<PropertyTrace>(entity);

                IRepository<PropertyTrace> repo = new PropertyTraceRepository(context);
                repo.Update(PropertyTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
