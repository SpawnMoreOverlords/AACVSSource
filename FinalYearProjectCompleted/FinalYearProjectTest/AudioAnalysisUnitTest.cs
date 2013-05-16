using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalYearProject;

namespace FinalYearProjectTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AudioAnalysisUnitTest
    {

        AudioAnalysisXNAClass audioAnalysis; //global variable for testing.

        public AudioAnalysisUnitTest()
        {
            //instantiate the audio analysis class for testing! 
            audioAnalysis = new AudioAnalysisXNAClass();
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //I am using Equivalence Partitioning to test my Audio Analysis Class
        /*
         Equivalence partitioning: (Project Management Testing Slide 15)
        An equivalence partition is a subset of the program inputs such that elements in the same partition have common 
         characteristics and yield “equivalent” program behaviour
        Test cases should be chosen from each partition
        •from the middle (as “typical” elements of the partition)
        •from the boundaries (“atypical” elements)
         */

        //Test Low, Mid and High FrBandAverage getters and setters.
        [TestMethod]
        public void TestAverageGettersAndSetters()
        {
            audioAnalysis.LowFrBandAverage = 0f;
            Assert.AreEqual(0f, audioAnalysis.LowFrBandAverage);
            audioAnalysis.LowFrBandAverage = 0.0001f;
            Assert.AreEqual(0.0001f, audioAnalysis.LowFrBandAverage);
            audioAnalysis.LowFrBandAverage = 0.5f;
            Assert.AreEqual(0.5f, audioAnalysis.LowFrBandAverage);
            audioAnalysis.LowFrBandAverage = 0.9999f;
            Assert.AreEqual(0.9999f, audioAnalysis.LowFrBandAverage);
            audioAnalysis.LowFrBandAverage = 1f;
            Assert.AreEqual(1f, audioAnalysis.LowFrBandAverage);

            audioAnalysis.HighFrBandAverage = 0f;
            Assert.AreEqual(0f, audioAnalysis.HighFrBandAverage);
            audioAnalysis.HighFrBandAverage = 0.0001f;
            Assert.AreEqual(0.0001f, audioAnalysis.HighFrBandAverage);
            audioAnalysis.HighFrBandAverage = 0.5f;
            Assert.AreEqual(0.5f, audioAnalysis.HighFrBandAverage);
            audioAnalysis.HighFrBandAverage = 0.9999f;
            Assert.AreEqual(0.9999f, audioAnalysis.HighFrBandAverage);
            audioAnalysis.HighFrBandAverage = 1f;
            Assert.AreEqual(1f, audioAnalysis.HighFrBandAverage);

            audioAnalysis.MidFrBandAverage = 0f;
            Assert.AreEqual(0f, audioAnalysis.MidFrBandAverage);
            audioAnalysis.MidFrBandAverage = 0.0001f;
            Assert.AreEqual(0.0001f, audioAnalysis.MidFrBandAverage);
            audioAnalysis.MidFrBandAverage = 0.5f;
            Assert.AreEqual(0.5f, audioAnalysis.MidFrBandAverage);
            audioAnalysis.MidFrBandAverage = 0.9999f;
            Assert.AreEqual(0.9999f, audioAnalysis.MidFrBandAverage);
            audioAnalysis.MidFrBandAverage = 1f;
            Assert.AreEqual(1f, audioAnalysis.MidFrBandAverage);
        }

        //Test getBool_2Step Low, Mid, and High functions
        [TestMethod]
        public void getBool_2Step_EquivalencePartitioning()
        {
            audioAnalysis.LowFrBandAverage = 0.5f; //Set LowFrBandAverage to 0.7
            //This function should return true is the minimun value parameter is exceeded by the current LowFrBandAverage (0.7).
            //Otherwise it should return false.
            Assert.AreEqual(true, audioAnalysis.getBool_2StepLowFrq(0.0f)); //Lower edge value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepLowFrq(0.25f)); //Lower middle value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepLowFrq(0.49f)); //Lower boundry value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepLowFrq(0.5f)); //Upper boundry value (The LowFrBandAverage no longer exceeds the minimun value parameter).
            Assert.AreEqual(false, audioAnalysis.getBool_2StepLowFrq(0.75f)); //Upper middle value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepLowFrq(1.0f)); //Upper edge value

            audioAnalysis.MidFrBandAverage = 0.1f; //Set MidFrBandAverage to 0.1
            //This function should return true is the minimun value parameter is exceeded by the current MidFrBandAverage (0.1).
            //Otherwise it should return false.
            Assert.AreEqual(true, audioAnalysis.getBool_2StepMidFrq(0.0001f)); //Lower edge value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepMidFrq(0.001f)); //Lower middle value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepMidFrq(0.099f)); //Lower boundry value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepMidFrq(0.1f)); //Upper boundry value (The MidFrBandAverage no longer exceeds the minimun value parameter).
            Assert.AreEqual(false, audioAnalysis.getBool_2StepMidFrq(0.15f)); //Upper middle value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepMidFrq(0.9f)); //Upper edge value

            audioAnalysis.HighFrBandAverage = 0.9f; //Set HighFrBandAverage to 0.9
            //This function should return true is the minimun value parameter is exceeded by the current HighFrBandAverage (0.9).
            //Otherwise it should return false.
            Assert.AreEqual(true, audioAnalysis.getBool_2StepHighFrq(0.1f)); //Lower edge value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepHighFrq(0.5f)); //Lower middle value
            Assert.AreEqual(true, audioAnalysis.getBool_2StepHighFrq(0.89f)); //Lower boundry value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepHighFrq(0.9f)); //Upper boundry value (The HighFrBandAverage no longer exceeds the minimun value parameter).
            Assert.AreEqual(false, audioAnalysis.getBool_2StepHighFrq(0.95f)); //Upper middle value
            Assert.AreEqual(false, audioAnalysis.getBool_2StepHighFrq(1.0f)); //Upper edge value
        }

        //Test getInt_2Step Low, Mid, and High functions
        [TestMethod]
        public void getInt_2Step_EquivalencePartitioning() 
        {
            int minInt = 10; int maxInt = 134;

            //This function should return the maxInt value if the min value is exceeded by the LowFrBandAverage, otherwise return the minInt value. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Lower edge value
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Lower middle value
            audioAnalysis.LowFrBandAverage = 0.5f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Lower boundry value
            audioAnalysis.LowFrBandAverage = 0.51f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Upper boundry value (The LowFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.LowFrBandAverage = 0.75f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Upper middle value
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepLowFrq(minInt, maxInt, 0.5f)); //Upper edge value

            //This function should return the maxInt value if the min value is exceeded by the MidFrBandAverage, otherwise return the minInt value. 
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Lower edge value
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Lower middle value
            audioAnalysis.MidFrBandAverage = 0.5f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Lower boundry value
            audioAnalysis.MidFrBandAverage = 0.51f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Upper boundry value (The MidFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.MidFrBandAverage = 0.75f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Upper middle value
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepMidFrq(minInt, maxInt, 0.5f)); //Upper edge value

            //This function should return the maxInt value if the min value is exceeded by the HighFrBandAverage, otherwise return the minInt value. 
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Lower edge value
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Lower middle value
            audioAnalysis.HighFrBandAverage = 0.5f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Lower boundry value
            audioAnalysis.HighFrBandAverage = 0.51f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Upper boundry value (The HighFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.HighFrBandAverage = 0.75f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Upper middle value
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_2StepHighFrq(minInt, maxInt, 0.5f)); //Upper edge value
        }
        //Test getInt_6Step Low, Mid, and High functions
        //Return the minInt value if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return minInt + increment if min < low/mid/high FrBandAverag <= x1. 
        //Return minInt + increment * 2 if x1 < low/mid/high FrBandAverag <= x2. 
        //Return minInt + increment * 3 if x2 < low/mid/high FrBandAverag <= x3. 
        //Return minInt + increment * 4 if x3 < low/mid/high FrBandAverag >= max. 
        //Return minInt + increment * 5 if low/mid/high FrBandAverag > max.
        //Depending on the current low / mid / high FrBandAverage each function can return one of 6 different outputs. 
        [TestMethod]
        public void getInt_6Step_EquivalencePartitioning() 
        {
            //I will use the following values to test each function:
            int minInt = 198; int maxInt = 1337; //min and max int
            int range = maxInt - minInt; //Find the range
            float increment = range / 5; //Divide the range by 5, to create an incremental step value to be used below:

            //Low Frequency Band / getInt_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getInt_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getInt_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f
        }

        //Test getFloat_2Step Low, Mid, and High functions
        [TestMethod]
        public void getFloat_2Step_EquivalencePartitioning() 
        {
            float minFloat = 0.832f; float maxFloat = 1.93f;

            //This function should return the maxFloat value if the min value is exceeded by the LowFrBandAverage, otherwise return the minFloat value. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Lower edge value
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Lower middle value
            audioAnalysis.LowFrBandAverage = 0.5f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Lower boundry value
            audioAnalysis.LowFrBandAverage = 0.51f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Upper boundry value (The LowFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.LowFrBandAverage = 0.75f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Upper middle value
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepLowFrq(minFloat, maxFloat, 0.5f)); //Upper edge value

            //This function should return the maxFloat value if the min value is exceeded by the MidFrBandAverage, otherwise return the minFloat value. 
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Lower edge value
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Lower middle value
            audioAnalysis.MidFrBandAverage = 0.5f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Lower boundry value
            audioAnalysis.MidFrBandAverage = 0.51f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Upper boundry value (The MidFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.MidFrBandAverage = 0.75f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Upper middle value
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepMidFrq(minFloat, maxFloat, 0.5f)); //Upper edge value

            //This function should return the maxFloat value if the min value is exceeded by the HighFrBandAverage, otherwise return the minFloat value. 
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Lower edge value
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Lower middle value
            audioAnalysis.HighFrBandAverage = 0.5f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Lower boundry value
            audioAnalysis.HighFrBandAverage = 0.51f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Upper boundry value (The HighFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.HighFrBandAverage = 0.75f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Upper middle value
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_2StepHighFrq(minFloat, maxFloat, 0.5f)); //Upper edge value
        }        
        //Test getFloat_6Step Low, Mid, and High functions
        //Return the minFloat value if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return minFloat + increment if min < low/mid/high FrBandAverag <= x1. 
        //Return minFloat + increment * 2 if x1 < low/mid/high FrBandAverag <= x2. 
        //Return minFloat + increment * 3 if x2 < low/mid/high FrBandAverag <= x3. 
        //Return minFloat + increment * 4 if x3 < low/mid/high FrBandAverag >= max. 
        //Return minFloat + increment * 5 if low/mid/high FrBandAverag > max.
        //Depending on the current low / mid / high FrBandAverage each function will return one of 6 different outputs equal to or between the min and max floats.
        [TestMethod]
        public void getFloat_6Step_EquivalencePartitioning() 
        {
            //I will use the following values to test each function:
            float minFloat = 0.175f; float maxFloat = 9.1337f; //min and max float
            float range = maxFloat - minFloat; //Find the range
            float increment = range / 5; //Divide the range by 5, to create an incremental step value to be used below:

            //Low Frequency Band / getFloat_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getFloat_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getFloat_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f
        }

        //Test getString_2Step Low, Mid, and High functions
        [TestMethod]
        public void getString_2Step_EquivalencePartitioning() 
        {
            String string1 = "hello";
            String string2 = "goodbye";

            //This function should return string2 if the min value is exceeded by the LowFrBandAverage, otherwise return string1. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Lower edge value
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Lower middle value
            audioAnalysis.LowFrBandAverage = 0.5f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Lower boundry value
            audioAnalysis.LowFrBandAverage = 0.51f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Upper boundry value (The LowFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.LowFrBandAverage = 0.75f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Upper middle value
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepLowFrq(string1, string2, 0.5f)); //Upper edge value

            //This function should return string2 if the min value is exceeded by the MidFrBandAverage, otherwise return string1. 
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Lower edge value
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Lower middle value
            audioAnalysis.MidFrBandAverage = 0.5f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Lower boundry value
            audioAnalysis.MidFrBandAverage = 0.51f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Upper boundry value (The MidFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.MidFrBandAverage = 0.75f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Upper middle value
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepMidFrq(string1, string2, 0.5f)); //Upper edge value

            //This function should return string2 if the min value is exceeded by the HighFrBandAverage, otherwise return string1. 
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Lower edge value
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Lower middle value
            audioAnalysis.HighFrBandAverage = 0.5f;
            Assert.AreEqual(string1, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Lower boundry value
            audioAnalysis.HighFrBandAverage = 0.51f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Upper boundry value (The HighFrBandAverage now exceeds the minimun value parameter).
            audioAnalysis.HighFrBandAverage = 0.75f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Upper middle value
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(string2, audioAnalysis.getString_2StepHighFrq(string1, string2, 0.5f)); //Upper edge value
        }
        //Test getString_6Step Low, Mid, and High functions
        //Return string1 if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return string2 if min < low/mid/high FrBandAverag <= x1. 
        //Return string3 * 2 if x1 < low/mid/high FrBandAverag <= x2. 
        //Return string4 * 3 if x2 < low/mid/high FrBandAverag <= x3. 
        //Return string5 * 4 if x3 < low/mid/high FrBandAverag >= max. 
        //Return string6 * 5 if low/mid/high FrBandAverag > max.
        [TestMethod]
        public void getString_6Step_EquivalencePartitioning() 
        {
            String string1 = "string1";
            String string2 = "string2";
            String string3 = "string3";
            String string4 = "string4";
            String string5 = "string5";
            String string6 = "string6";

            //Low Frequency Band / getString_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage < 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepLowFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getString_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage < 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepMidFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getString_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(string1, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage < 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(string2, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle value of of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(string3, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(string4, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(string5, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper broundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Mid broundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(string6, audioAnalysis.getString_6StepHighFrq(string1, string2, string3, string4, string5, string6, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f  
        }

        //Test getVector2_3Step Low, Mid, and High functions
        //returns a string depending on the float values:
        //Return minVector2 if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call). 
        //Return midVector2 if min < low/mid/high FrBandAverag >= max. 
        //Return maxVector2 if low/mid/high FrBandAverag > max.
        [TestMethod]
        public void getVector2_3Step_EquivalencePartitioning() 
        { 
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //I am unable to test XNA classes using straight C# unit testing, so i must look for another method. Maybe NUnit?//
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //Vector2 minVector2 = new Vector2(); Vector2 midVector2 = new Vector2(); Vector2 maxVector2 = new Vector2();
           // audioAnalysis.LowFrBandAverage = 0.0;
        }
        //Test getVector2_6Step Low, Mid, and High functions
        [TestMethod]
        public void getVector2_6Step_EquivalencePartitioning() { }

        //Test getTimeSpan_3Step Low, Mid, and High functions
        [TestMethod]
        public void getTimeSpan_3Step_EquivalencePartitioning() { }
        //Test getTimeSpan_6Step Low, Mid, and High functions
        [TestMethod]
        public void getTimeSpan_6Step_EquivalencePartitioning() { }

        //Test getColour_3Step Low, Mid, and High functions
        [TestMethod]
        public void getColour_3Step_EquivalencePartitioning() { }
        //Test getColour_6Step Low, Mid, and High functions
        [TestMethod]
        public void getColour_6Step_EquivalencePartitioning() { }

        //Test getColourArray_3Step Low, Mid, and High functions
        [TestMethod]
        public void getColourArray_3Step_EquivalencePartitioning() { }
        //Test getColourArray_6Step Low, Mid, and High functions
        [TestMethod]
        public void getColourArray_6Step_EquivalencePartitioning() { }

        
    }
}
