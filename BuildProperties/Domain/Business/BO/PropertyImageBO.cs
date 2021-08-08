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
    public class PropertyImageBO : IPropertyImage
    {
        private readonly RealEstateContext context;
        private readonly IMapper mapper;

        public PropertyImageBO(RealEstateContext context)
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
        /// Create PropertyImage
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public long Create(PropertyImageAM entity)
        {
            try
            {
                var PropertyImage = mapper.Map<PropertyImage>(entity);

                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                return repo.Create(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the PropertyImage count
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get the PropertyImage count according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public int Count(Expression<Func<PropertyImageAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyImage, bool>>>(predicate);

                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyImage for id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyImageAM Get(long id)
        {
            try
            {
                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                var PropertyImage = repo.Get(id);

                return mapper.Map<PropertyImageAM>(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyImage list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyImageAM> Get()
        {
            try
            {
                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                var PropertyImage = repo.Get();

                return mapper.Map<List<PropertyImageAM>>(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyImage list
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public List<PropertyImageAM> Get(Expression<Func<PropertyImageAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyImage, bool>>>(predicate);

                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                var PropertyImage = repo.Get(where);

                return mapper.Map<List<PropertyImageAM>>(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Get PropertyImage list according filter
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public PropertyImageAM GetFirst(Expression<Func<PropertyImageAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PropertyImage, bool>>>(predicate);

                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                var PropertyImage = repo.GetFirst(where);

                return mapper.Map<PropertyImageAM>(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Update PropertyImage
        /// Autor: Jair Guerrero
        /// Fecha: 2021-07-31
        /// </summary>
        public void Update(PropertyImageAM entity)
        {
            try
            {
                var PropertyImage = mapper.Map<PropertyImage>(entity);

                IRepository<PropertyImage> repo = new PropertyImageRepository(context);
                repo.Update(PropertyImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
