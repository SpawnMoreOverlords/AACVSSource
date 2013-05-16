using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProjectileTest and is intended
    ///to contain all ProjectileTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectileTest
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
        ///A test for Projectile Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectileConstructorTest()
        {
            Projectile target = new Projectile();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
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
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            Viewport viewport = new Viewport(); // TODO: Initialize to an appropriate value
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 direction = new Vector2(); // TODO: Initialize to an appropriate value
            float rotation = 0F; // TODO: Initialize to an appropriate value
            target.Initialize(viewport, texture, position, direction, rotation);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            target.Update();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Direction
        ///</summary>
        [TestMethod()]
        public void DirectionTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Direction = expected;
            actual = target.Direction;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Height
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Height;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Rotation
        ///</summary>
        [TestMethod()]
        public void RotationTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Rotation = expected;
            actual = target.Rotation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Width
        ///</summary>
        [TestMethod()]
        public void WidthTest()
        {
            Projectile target = new Projectile(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Width;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
