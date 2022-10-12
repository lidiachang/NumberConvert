using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberConvert.Controllers
{
    [TestClass]
    public class TestController
    {

        [TestMethod]
        public void Test1()
        {
            var controller = new MainController();
            var result = controller.Index(0) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("zero dollars", res);
        }
        [TestMethod]
        public void Test2()
        {
            var controller = new MainController();
            var result = controller.Index(1) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("one dollar", res);
        }
        [TestMethod]
        public void Test3()
        {
            var controller = new MainController();
            var result = controller.Index(25.1) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("twenty-five dollars and ten cents", res);
        }
        [TestMethod]
        public void Test4()
        {
            var controller = new MainController();
            var result = controller.Index(0.01) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("zero dollars and one cent", res);
        }
        [TestMethod]
        public void Test5()
        {
            var controller = new MainController();
            var result = controller.Index(45100) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("forty-five thousand one hundred dollars", res);
        }
        [TestMethod]
        public void Test6()
        {
            var controller = new MainController();
            var result = controller.Index(999999999.99) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents", res);
        }
        [TestMethod]
        public void Test7()
        {
            var controller = new MainController();
            var result = controller.Index(13) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("thirteen dollars", res);
        }
        [TestMethod]
        public void Test8()
        {
            var controller = new MainController();
            var result = controller.Index(50) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("fifty dollars", res);
        }
        [TestMethod]
        public void Test9()
        {
            var controller = new MainController();
            var result = controller.Index(401) as ViewResult;
            var res = result.ViewBag.result;
            Assert.AreEqual("four hundred one dollars", res);
        }
    }
}