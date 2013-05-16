using FinalYearProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for Game1Test and is intended
    ///to contain all Game1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Game1Test
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
        ///A test for Game1 Constructor
        ///</summary>
        [TestMethod()]
        public void Game1ConstructorTest()
        {
            Game1 target = new Game1();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddEnemy
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void AddEnemyTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.AddEnemy();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddExplosion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void AddExplosionTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            target.AddExplosion(position);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddProjectile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void AddProjectileTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            Vector2 position = new Vector2(); // TODO: Initialize to an appropriate value
            target.AddProjectile(position);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void DrawTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Draw(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDirection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void GetDirectionTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            Vector2 positionOfObject = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 directionToPointAt = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 expected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 actual;
            actual = target.GetDirection(positionOfObject, directionToPointAt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRotation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void GetRotationTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            Vector2 direction = new Vector2(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.GetRotation(direction);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void InitializeTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.Initialize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void LoadContentTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.LoadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PlayMusic
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void PlayMusicTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            Song song = null; // TODO: Initialize to an appropriate value
            target.PlayMusic(song);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UnloadContent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UnloadContentTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.UnloadContent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdateTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateCollision
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdateCollisionTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateCollision();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateEnemies
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdateEnemiesTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.UpdateEnemies(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateExplosions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdateExplosionsTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.UpdateExplosions(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdatePlayer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdatePlayerTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.UpdatePlayer(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateProjectiles
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FinalYearProject.exe")]
        public void UpdateProjectilesTest()
        {
            Game1_Accessor target = new Game1_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateProjectiles();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
