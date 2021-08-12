using BuildProperties.CrossCutting.ApiModel;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Models;
using Domain.Tests.BaseContext;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tests.PropBuild
{
    public class PropertyBOTests : RealEstateContextTestBase
    {
        /// <summary>
        /// Unit test for the Property Business Object
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Initialize initial values for tests
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        public PropertyBOTests() : base()
        {
            Seed(context);
        }

        /// <summary>
        /// Initialize initial values for tests
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        /// <param name="context">Database Context</param>
        private void Seed(RealEstateContext context)
        {
            var owners = new[]
            {
                new Owner { IdOwner = 1, Identification="1110", Name="Carl Pax", Address="Cra 100", Photo="Photo/img1.jpg"},
                new Owner { IdOwner = 2, Identification="1120", Name="Robert Smith", Address="Cra 100", Photo="Photo/img2.jpg"},
                new Owner { IdOwner = 3, Identification="1130", Name="Man Power", Address="Cra 100", Photo="Photo/img3.jpg"},
                new Owner { IdOwner = 4, Identification="1140", Name="Paul G.", Address="Cra 100", Photo="Photo/img4.jpg"},
            };

            var States = new[]
            {
                new State { IdState = 1},
                new State { IdState = 2},
                new State { IdState = 3},
                new State { IdState = 4},
            };

            var properties = new[]
            {
                new Property { IdOwner = 1, Name="Boca raton mansion", Address="601 North Ocean", Year=2000, Price=2000000, InternalCode="INTER123",IdState=1},
                new Property { IdOwner = 2, Name="Palm beach mansion", Address="Chapel Hill", Year=1986, Price=1000000, InternalCode="INTER456",IdState=1},
            };

            context.Properties.AddRange(properties);
            context.SaveChanges();
        }

        /// <summary>
        /// Check that - entity registration is correct
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void SavePropertyLongOnce()
        {
            // Arrange
            IProperty propertyBO = new PropertyBO(context);
            var entity = new PropertyAM { IdOwner = 3, Name = "Boca raton mansion", Address = "601 North Ocean", Year = 2000, Price = 2000000, InternalCode = "INTER123", IdState = 1 };

            // Act
            long id = propertyBO.Create(entity);

            // Assert
            Assert.True(id == 3);
        }

        /// <summary>
        /// Check that - PropertyImage  registration is correct
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void SavePropertyImgLongOnce()
        {
            // Arrange
            IPropertyImage propertyImgBO = new PropertyImageBO(context);
            var entity = new PropertyImageAM { IdProperty = 3, Files = "/photo/img/1.jpg", IdState = 3 };

            // Act
            long id = propertyImgBO.Create(entity);

            // Assert
            Assert.True(id == 1);
        }

        /// <summary>
        /// Check that - PropertyTrace  registration is correct
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void SavePropertyTraceLongOnce()
        {
            // Arrange
            IPropertyTrace propTraceBO = new PropertyTraceBO(context);
            var entity = new PropertyTraceAM { IdProperty = 3, DateSale = DateTime.Now, Name = "Jair Guerrero", Tax = 2000, Value = 2000000 };

            // Act
            long id = propTraceBO.Create(entity);

            // Assert
            Assert.True(id == 1);
        }
    }
}
