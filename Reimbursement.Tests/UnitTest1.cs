using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReimbursementClaim.Controllers;
using ReimbursementClaim.Models;

namespace ReimbursementClaim
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void Login_Get_ReturnsView()
        {
            // Arrange
            var controller = new LoginController(null); // Pass null for IHttpContextAccessor since it's not needed for this test

            // Act
            var result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ViewName);
        }

        [TestMethod]
        public void Login_Post_ValidUser_AdminSuccess_RedirectsToAdminDashboard()
        {
            // Arrange
            var controller = new LoginController(null); // Pass null for IHttpContextAccessor since it's not needed for this test
            var validUser = new UserCredentials
            {
                username = "admin", // Replace with an actual admin username
                // Add other required properties for a valid admin user
            };

            // Act
            var result = controller.Login(validUser) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AdminDashboard", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public void Login_Post_ValidUser_EmpSuccess_RedirectsToViewDetails()
        {
            // Arrange
            var controller = new LoginController(null); // Pass null for IHttpContextAccessor since it's not needed for this test
            var validUser = new UserCredentials
            {
                username = "employee", // Replace with an actual employee username
                // Add other required properties for a valid employee user
            };

            // Act
            var result = controller.Login(validUser) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewDetails", result.ActionName);
            Assert.AreEqual("Details", result.ControllerName);
        }

        // Add more test methods for different scenarios and error cases
    }
}
