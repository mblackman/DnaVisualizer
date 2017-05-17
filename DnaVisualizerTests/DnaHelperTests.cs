using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DnaBase;

namespace DnaVisualizerTests
{
    [TestClass]
    public class DnaHelperTests
    {
        private const string testDnaFileName = "dnatestfilemale.txt";

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("TestData\\" + testDnaFileName)]
        [Description("A basic test to check that the 23andMe data source can read in the basic male data.")]
        public void Read23AndMeDataSourceMale()
        {
            var dataFilePath = Path.Combine(this.TestContext.DeploymentDirectory, testDnaFileName);
            var myDna = DnaHelper.CreateDna(dataFilePath, new TwentyThreeAndMeDnaSource());
            Assert.AreEqual(25, myDna.Chromosomes.Count);
        }
    }
}
