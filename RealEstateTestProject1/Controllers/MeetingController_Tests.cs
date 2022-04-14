using Kendo.Mvc.UI;
using NUnit.Framework;
using RealEstateRentalAdmin.Controllers;
using RealEstateRentalAdmin.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTestProject1.Controllers
{
    class MeetingController_Tests
    {
        private DbHelper _dbHelper;
        private MeetingController meetingController;
        private DataSourceRequest request;

        [SetUp]
        public void Setup()
        {
            meetingController = new MeetingController(_dbHelper);
            request = new DataSourceRequest();
        }

        [Test]
        public void All_Test()
        {
            var dbResponse = meetingController.All();

            Assert.IsNotNull(dbResponse);
        }

        [Test]
        public void Pending_Read_Test()
        {
            var dbResponse = meetingController.Pending_Read(request);

            Assert.IsNotNull(dbResponse);
        }

    }
}
