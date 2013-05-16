using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ParticleTest and is intended
    ///to contain all ParticleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParticleTest
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
        ///A test for Particle Constructor
        ///</summary>
        [TestMethod()]
        public void ParticleConstructorTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            target.Draw(spriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            target.Update();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Angle
        ///</summary>
        [TestMethod()]
        public void AngleTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Angle = expected;
            actual = target.Angle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AngularVelocity
        ///</summary>
        [TestMethod()]
        public void AngularVelocityTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.AngularVelocity = expected;
            actual = target.AngularVelocity;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            Color expected = new Color(); // TODO: Initialize to an appropriate value
            Color actual;
            target.Color = expected;
            actual = target.Color;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target.Size = expected;
            actual = target.Size;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TTL
        ///</summary>
        [TestMethod()]
        public void TTLTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.TTL = expected;
            actual = target.TTL;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Texture
        ///</summary>
        [TestMethod()]
        public void TextureTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            Texture2D expected = null; // TODO: Initialize to an appropriate value
            Texture2D actual;
            target.Texture = expected;
            actual = target.Texture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Velocity
        ///</summary>
        [TestMethod()]
        public void VelocityTest()
        {
            Texture2D texture = null; // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 velocity = new Vector2(); // TODO: Initialize to an appropriate value
            float angle = 0F; // TODO: Initialize to an appropriate value
            float angularVelocity = 0F; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            int ttl = 0; // TODO: Initialize to an appropriate value
            Particle target = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.Velocity = expected;
            actual = target.Velocity;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
