using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for BackgroundVisTest and is intended
    ///to contain all BackgroundVisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BackgroundVisTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            GraphicsDeviceManager graphicsMan = null; // TODO: Initialize to an appropriate value
            GraphicsDevice graphicsDev = null; // TODO: Initialize to an appropriate value
            Song music = null; // TODO: Initialize to an appropriate value
            BackgroundVis target = new BackgroundVis(graphicsMan, graphicsDev, music); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnloadContent
        ///</summary>
        [TestMethod()]
        public void UnloadContentTest()
        {
            GraphicsDeviceManager graphicsMan = null; // TODO: Initialize to an appropriate value
            GraphicsDevice graphicsDev = null; // TODO: Initialize to an appropriate value
            Song music = null; // TODO: Initialize to an appropriate value
            BackgroundVis target = new BackgroundVis(graphicsMan, graphicsDev, music); // TODO: Initialize to an appropriate value
            target.UnloadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            GraphicsDeviceManager graphicsMan = null; // TODO: Initialize to an appropriate value
            GraphicsDevice graphicsDev = null; // TODO: Initialize to an appropriate value
            Song music = null; // TODO: Initialize to an appropriate value
            BackgroundVis target = new BackgroundVis(graphicsMan, graphicsDev, music); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            GraphicsDevice graphicsDev1 = null; // TODO: Initialize to an appropriate value
            double movementCap = 0F; // TODO: Initialize to an appropriate value
            target.Draw(gameTime, graphicsDev1, movementCap);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BackgroundVis Constructor
        ///</summary>
        [TestMethod()]
        public void BackgroundVisConstructorTest()
        {
            GraphicsDeviceManager graphicsMan = null; // TODO: Initialize to an appropriate value
            GraphicsDevice graphicsDev = null; // TODO: Initialize to an appropriate value
            Song music = null; // TODO: Initialize to an appropriate value
            BackgroundVis target = new BackgroundVis(graphicsMan, graphicsDev, music);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
