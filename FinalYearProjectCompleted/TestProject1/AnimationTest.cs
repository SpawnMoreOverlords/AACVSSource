using FinalFinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AnimationTest and is intended
    ///to contain all AnimationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnimationTest
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
        ///A test for Rotation
        ///</summary>
        [TestMethod()]
        public void RotationTest()
        {
            Animation target = new Animation(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Rotation = expected;
            actual = target.Rotation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Direction
        ///</summary>
        [TestMethod()]
        public void DirectionTest()
        {
            Animation target = new Animation(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Direction = expected;
            actual = target.Direction;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Animation target = new Animation(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            Animation target = new Animation(); // TODO: Initialize to an appropriate value
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            int frameWidth = 0; // TODO: Initialize to an appropriate value
            int frameHeight = 0; // TODO: Initialize to an appropriate value
            int frameCount = 0; // TODO: Initialize to an appropriate value
            int frametime = 0; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float scale = 0F; // TODO: Initialize to an appropriate value
            bool looping = false; // TODO: Initialize to an appropriate value
            target.Initialize(texture, position, frameWidth, frameHeight, frameCount, frametime, color, scale, looping);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Animation target = new Animation(); // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            target.Draw(spriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Animation Constructor
        ///</summary>
        [TestMethod()]
        public void AnimationConstructorTest()
        {
            Animation target = new Animation();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
