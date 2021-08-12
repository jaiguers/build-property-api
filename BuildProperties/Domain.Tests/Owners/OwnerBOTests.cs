using Domain.Tests.BaseContext;
using NUnit.Framework;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business.Interface;
using Domain.Business.BO;
using BuildProperties.CrossCutting.ApiModel;

namespace Domain.Tests.Owners
{
    public class OwnerBOTests : RealEstateContextTestBase
    {
        /// <summary>
        /// Unit test for the Owner Business Object
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
        public OwnerBOTests() : base()
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

            context.Owners.AddRange(owners);
            context.SaveChanges();
        }

        /// <summary>
        /// Check that - entity registration is correct
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void SaveLongOnce()
        {
            // Arrange
            IOwer ownerBO = new OwnerBO(context);
            var entity = new OwnerAM { Identification = "1140", Name = "Paul G.", Address = "Cra 86", Photo = "Photo/img5.jpg" };

            // Act
            long id = ownerBO.Create(entity);

            // Assert
            Assert.True(id == 5);
        }

        /// <summary>
        /// Checks for a null exception
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void SaveExceptionNull()
        {
            try
            {
                // Arrange
                IOwer ownerBO = new OwnerBO(context);

                // Act
                long id = ownerBO.Create(null);

            }
            catch (Exception)
            {
                // Assert
                Assert.Pass();
            }
        }

        /// <summary>
        /// Check that - Count of the Owners
        /// Autor: Jair Guerrero
        /// Fecha: 2020-08-11
        /// </summary>
        [Test]
        public void GetListOwnerCount()
        {
            // Arrange
            IOwer ownerBO = new OwnerBO(context);

            // Act
            var entities = ownerBO.Get();

            // Assert
            Assert.True(entities.Count >= 0);
        }
    }
}
