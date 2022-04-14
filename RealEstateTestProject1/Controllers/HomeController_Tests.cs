using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RealEstateRentalAdmin.Controllers;
using RealEstateRentalAdmin.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTestProject1.Controllers
{
    class HomeController_Tests
    {
        public MockDbHelper _dbHelper;
        public HomeController homeController;

        [SetUp]
        public void Setup()
        {
            _dbHelper = new MockDbHelper();
            homeController = new HomeController(_dbHelper);
        }

        [Test]
        public void Index_Test()
        {
            var dbResponse = homeController.Index();
            Assert.IsNotNull(dbResponse);


        }

    }
}
