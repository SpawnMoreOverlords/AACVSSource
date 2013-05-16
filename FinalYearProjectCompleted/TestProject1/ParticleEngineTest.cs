using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ParticleEngineTest and is intended
    ///to contain all ParticleEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParticleEngineTest
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
        ///A test for ParticleEngine Constructor
        ///</summary>
        [TestMethod()]
        public void ParticleEngineConstructorTest()
        {
            List<Texture2D> textures = null; // TODO: Initialize to an appropriate value
            Vector2 location = new Vector2(); // TODO: Initialize to an appropriate value
            ParticleEngine target = new ParticleEngine(textures, location);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            List<Texture2D> textures = null; // TODO: Initialize to an appropriate value
            Vector2 location = new Vector2(); // TODO: Initialize to an appropriate value
            ParticleEngine target = new ParticleEngine(textures, location); // TODO: Initialize to an appropriate value
            SpriteBatch spriteBatch = null; // TODO: Initialize to an appropriate value
            target.Draw(spriteBatch);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GenerateNewParticle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void GenerateNewParticleTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ParticleEngine_Accessor target = new ParticleEngine_Accessor(param0); // TODO: Initialize to an appropriate value
            float velocity1 = 0F; // TODO: Initialize to an appropriate value
            float velocity2 = 0F; // TODO: Initialize to an appropriate value
            int staticttl = 0; // TODO: Initialize to an appropriate value
            int randttl = 0; // TODO: Initialize to an appropriate value
            Color color = new Color(); // TODO: Initialize to an appropriate value
            float size = 0F; // TODO: Initialize to an appropriate value
            Particle expected = null; // TODO: Initialize to an appropriate value
            Particle actual;
            actual = target.GenerateNewParticle(velocity1, velocity2, staticttl, randttl, color, size);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            List<Texture2D> textures = null; // TODO: Initialize to an appropriate value
            Vector2 location = new Vector2(); // TODO: Initialize to an appropriate value
            ParticleEngine target = new ParticleEngine(textures, location); // TODO: Initialize to an appropriate value
            bool playerMoving = false; // TODO: Initialize to an appropriate value
            target.Update(playerMoving);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateExplosion
        ///</summary>
        [TestMethod()]
        public void UpdateExplosionTest()
        {
            List<Texture2D> textures = null; // TODO: Initialize to an appropriate value
            Vector2 location = new Vector2(); // TODO: Initialize to an appropriate value
            ParticleEngine target = new ParticleEngine(textures, location); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.UpdateExplosion();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EmitterLocation
        ///</summary>
        [TestMethod()]
        public void EmitterLocationTest()
        {
            List<Texture2D> textures = null; // TODO: Initialize to an appropriate value
            Vector2 location = new Vector2(); // TODO: Initialize to an appropriate value
            ParticleEngine target = new ParticleEngine(textures, location); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            target.EmitterLocation = expected;
            actual = target.EmitterLocation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
