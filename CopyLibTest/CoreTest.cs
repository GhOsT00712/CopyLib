using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopyLib;
using System.Threading.Tasks;

namespace CopyLibTest

{
    [TestClass]
    public class CoreTest
    {
        ICore copyUtil;

        [TestInitialize()]
        public void setup()
        {
            copyUtil = new Core();
        }
        [TestMethod]
        public async Task TestCopyValid()
        {
            string result = await copyUtil.copyDirAsync("/Users/pidubey/Downloads/Test", "/Users/pidubey/Documents/Test");
            Assert.AreEqual("Copy complete.", result);

        }
        [TestMethod]
        public async Task TestInvalidInput()
        {
            string result = await copyUtil.copyDirAsync("/Users/pidubey/Downloads/Test.asd", "/Users/pidubey/Documents/Test");
            Assert.AreEqual("/Users/pidubey/Downloads/Test.asd location not found", result);
        }
        [TestMethod]
        public async Task TestEmptySourcePath()
        {
            string result = await copyUtil.copyDirAsync("", "/Test");
            Assert.AreEqual("Invalid path", result);
        }
        [TestMethod]
        public async Task TestEmptyDestinationPath()
        {
            string result = await copyUtil.copyDirAsync("/Users/pidubey/Downloads/Test", "");
            Assert.AreEqual("Invalid path", result);
        }
        [TestMethod]
        public async Task TestCustomDestinationPath()
        {
            string result = await copyUtil.copyDirAsync("/Users/pidubey/Downloads/Test", "/Users/pidubey/Documents/Test2.txt");
            Assert.AreEqual("Copy complete.", result);
        }


    }
}