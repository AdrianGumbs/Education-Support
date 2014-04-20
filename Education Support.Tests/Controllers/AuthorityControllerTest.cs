using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Website.Controllers;
using System.Web.Mvc;
using Moq;
using System.Collections.Generic;
using Framework.Interfaces;
using Framework.Domain;
using Website.Models.Lists;
using Website.Models;

namespace Website.Tests.Controllers
{
    [TestClass]
    public class AuthorityControllerTest
    {
        Mock<IAuthorityRepo> authorityRepositoryMock;
        AuthorityController controller;
        List<Authority> authorities;

        [TestInitialize]
        public void SetUp()
        {
            authorityRepositoryMock = new Mock<IAuthorityRepo>();
            controller = new AuthorityController(authorityRepositoryMock.Object);

            authorities = new List<Authority>();
            authorities.Add(new Authority() { Id = Guid.NewGuid(), Code = 111, Name = "Test_Authority_1" });
            authorities.Add(new Authority() { Id = Guid.NewGuid(), Code = 222, Name = "Test_Authority_2" });
            authorities.Add(new Authority() { Id = new Guid("43656BB4-85D5-4032-936F-14BCFFED6218"), Code = 333, Name = "Test_Authority_3" });
            authorities.Add(new Authority() { Id = Guid.NewGuid(), Code = 444, Name = "Test_Authority_4" });
            authorities.Add(new Authority() { Id = Guid.NewGuid(), Code = 555, Name = "Test_Authority_5" });
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            authorityRepositoryMock.Setup(x => x.LoadAll()).Returns(authorities);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var resultModel = (AuthorityListModel)result.Model;

            // Assert
            authorityRepositoryMock.Verify(x => x.LoadAll(), Times.Once());
            Assert.AreEqual(resultModel.AuthorityList.Count, 5);
            Assert.AreEqual(authorities, resultModel.AuthorityList);
        }
        [TestMethod]
        public void Details()
        {
            // Arrange
            var authority = new Authority();
            authority = authorities[2];
            authorityRepositoryMock.Setup(x => x.Load(authority.Id)).Returns(authority);

            // Act
            ViewResult result = controller.Details(authority.Id) as ViewResult;
            var resultModel = result.Model;

            // Assert
            authorityRepositoryMock.Verify(x => x.Load(authority.Id), Times.Once());
            //Assert.AreEqual(resultModel, authority);
        }
        [TestMethod]
        public void Add()
        {
            // Arrange
            AuthorityController controller = new AuthorityController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }
        [TestMethod]
        public void Edit()
        {
            // Arrange
            AuthorityController controller = new AuthorityController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }
        [TestMethod]
        public void Delete()
        {
            // Arrange
            AuthorityController controller = new AuthorityController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }
    }
}
