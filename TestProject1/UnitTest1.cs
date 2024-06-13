using LK_Veebirakendus.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestProject1.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Index_Should_return_correct_view_to_anonymous_user()
        {
            //arrange
            var controller = new HomeController(null);

            //act
            var result = controller.Index() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.True(result.ViewName == "index" ||
                string.IsNullOrEmpty(result.ViewName));

        }

        [Fact]
        public void Privacy_Should_return_correct_view_to_user()
        {
            //arrange
            var controller = new HomeController(null);

            //act
            var result = controller.Privacy() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.True(result.ViewName == "Privacy" ||
                string.IsNullOrEmpty(result.ViewName));

        }
        [Fact]
        public void Index_Should_return_correct_view_to_authenticated_user()
        {
            var identity = new ClaimsIdentity("TEST");
            var user = new ClaimsPrincipal(identity);
            var controller = new HomeController(null);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };


            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.True(result.ViewName == "IndexAuthenticated");
        }
    }
}