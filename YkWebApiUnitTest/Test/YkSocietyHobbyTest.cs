using System;
using System.Reflection;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YkWebApiUnitTest.Test
{
    [TestClass]
    public class YkSocietyHobbyTest: ApiTestBase
    {

        [TestMethod]
        public void GetTest()
        {
            var result =Get("/api/Values/Get/1");
            Assert.AreEqual(result,"\"1\"");
        }

        [TestMethod]
        public void PostTest()
        {
            var result = Post<TestModel>("/api/values",new TestModel {Name = "test"});
            Assert.AreEqual("test",result.Name);
        }

        protected override void RegisterRoute(HttpConfiguration config)
        {
            ApiDemo.WebApiConfig.Register(config);;
        }
    }

    public class TestModel
    {
        public string Name { get; set; }
    }
}
