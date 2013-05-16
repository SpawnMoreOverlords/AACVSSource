using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using FinalFinalYearProject;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Player1Test and is intended
    ///to contain all Player1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Player1Test
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
        ///A test for Player1 Constructor
        ///</summary>
        [TestMethod()]
        public void Player1ConstructorTest()
        {
            Player1 target = new Player1();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Player1 target = new Player1(); // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            target.Draw(spriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            Player1 target = new Player1(); // TODO: Initialize to an appropriate value
            Animation animation = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            target.Initialize(animation, position);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Player1 target = new Player1(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Height
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            Player1 target = new Player1(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Height;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Width
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            Player1 target = new Player1(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Width;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
