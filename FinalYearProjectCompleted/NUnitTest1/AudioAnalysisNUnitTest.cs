using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using FinalYearProject;


namespace NUnitTest1
{
    [TestFixture]
    public class AudioAnalysisNUnitTest
    {
        AudioAnalysisXNAClass audioAnalysis; //global variable for testing.

        public AudioAnalysisNUnitTest()
        {
            //instantiate the audio analysis class for testing! 
            audioAnalysis = new AudioAnalysisXNAClass();
        }

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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
        public void getInt_6Step_EquivalencePartitioning()
        {
            //I will use the following values to test each function:
            int minInt = 198; int maxInt = 1337; //min and max int
            int range = maxInt - minInt; //Find the range
            float increment = range / 5; //Divide the range by 5, to create an incremental step value to be used below:

            //Low Frequency Band / getInt_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepLowFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getInt_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepMidFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getInt_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(minInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual((int)(minInt + increment), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual((int)(minInt + increment * 2), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual((int)(minInt + increment * 3), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual((int)(minInt + increment * 4), audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxInt, audioAnalysis.getInt_6StepHighFrq(minInt, maxInt, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f
        }

        //Test getFloat_2Step Low, Mid, and High functions
        [Test]
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
        [Test]
        public void getFloat_6Step_EquivalencePartitioning()
        {
            //I will use the following values to test each function:
            float minFloat = 0.175f; float maxFloat = 9.1337f; //min and max float
            float range = maxFloat - minFloat; //Find the range
            float increment = range / 5; //Divide the range by 5, to create an incremental step value to be used below:

            //Low Frequency Band / getFloat_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepLowFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getFloat_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepMidFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getFloat_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(minFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual((minFloat + increment), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual((minFloat + increment * 2), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual((minFloat + increment * 3), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual((minFloat + increment * 4), audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxFloat, audioAnalysis.getFloat_6StepHighFrq(minFloat, maxFloat, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f
        }

        //Test getString_2Step Low, Mid, and High functions
        [Test]
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
        //returns a string depending on the float values:
        //Return string_MinResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return string_LowMediumResponce if min < low/mid/high FrBandAverag <= x1. 
        //Return string_MediumResponce if x1 < low/mid/high FrBandAverag <= x2. 
        //Return string_HighMediumResponce if x2 < low/mid/high FrBandAverag <= x3. 
        //Return string_HighResponce if x3 < low/mid/high FrBandAverag >= max. 
        //Return string_MaxResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getString_6Step_EquivalencePartitioning()
        {
            String string_MinResponce = "string_MinResponce";
            String string_LowMediumResponce = "string_LowMediumResponce";
            String string_MediumResponce = "string_MediumResponce";
            String string_HighMediumResponce = "string_HighMediumResponce";
            String string_HighResponce = "string_HighResponce";
            String string_MaxResponce = "string_MaxResponce";

                //Low Frequency Band / getString_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepLowFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getString_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepMidFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getString_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(string_MinResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(string_LowMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(string_MediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(string_HighMediumResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(string_HighResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(string_MaxResponce, audioAnalysis.getString_6StepHighFrq(string_MinResponce, string_LowMediumResponce, string_MediumResponce,
                string_HighMediumResponce, string_HighResponce, string_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f  
        }

        //Test getVector2_3Step Low, Mid, and High functions
        //returns an XNA Vector2 depending on the float values:
        //Return minVector2 if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call). 
        //Return midVector2 if min < low/mid/high FrBandAverag >= max. 
        //Return maxVector2 if low/mid/high FrBandAverag > max.
        [Test]
        public void getVector2_3Step_EquivalencePartitioning()
        {
            float min = 0.25f; float max = 0.9f;

            Vector2 minVector2 = new Vector2(); Vector2 midVector2 = new Vector2(); Vector2 maxVector2 = new Vector2();         
            minVector2.X = 0.1f; minVector2.Y = 9.9f;
            midVector2.X = 1; midVector2.Y = 2;
            maxVector2.X = 5000; maxVector2.Y = 10000;
            
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Lower edge of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.125f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.26f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.45f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.9f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Upper boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.91f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 0.955f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepLowFrq(minVector2, midVector2, maxVector2, min, max)); //Upper edge of LowFrBandAverage > 0.9f

            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Lower edge of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.125f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.26f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.45f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.9f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Upper boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.91f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 0.955f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepMidFrq(minVector2, midVector2, maxVector2, min, max)); //Upper edge of MidFrBandAverage > 0.9f

            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Lower edge of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.125f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(minVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.26f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.45f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.9f;
            Assert.AreEqual(midVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Upper boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.91f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Lower boundry of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 0.955f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Middle of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(maxVector2, audioAnalysis.getVector2_3StepHighFrq(minVector2, midVector2, maxVector2, min, max)); //Upper edge of HighFrBandAverage > 0.9f
        }
        //Test getVector2_6Step Low, Mid, and High functions
        //returns an XNA Vector2 depending on the float values: 
        //Return vector2_MinResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return vector2_LowMediumResponce if min < low/mid/high FrBandAverag <= x1. 
        //Return vector2_MediumResponce if x1 < low/mid/high FrBandAverag <= x2. 
        //Return vector2_HighMediumResponce if x2 < low/mid/high FrBandAverag <= x3. 
        //Return vector2_HighResponce if x3 < low/mid/high FrBandAverag >= max. 
        //Return vector2_MaxResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getVector2_6Step_EquivalencePartitioning()
        {
            Vector2 vector2_MinResponce = new Vector2(); Vector2 vector2_LowMediumResponce = new Vector2(); Vector2 vector2_MediumResponce = new Vector2();
            Vector2 vector2_HighMediumResponce = new Vector2(); Vector2 vector2_HighResponce = new Vector2(); Vector2 vector2_MaxResponce = new Vector2();
            vector2_MinResponce.X = 0.1f; vector2_MinResponce.Y = 9.9f;
            vector2_LowMediumResponce.X = 1; vector2_LowMediumResponce.Y = 2;
            vector2_MediumResponce.X = 50; vector2_MediumResponce.Y = 100;
            vector2_HighMediumResponce.X = 150f; vector2_HighMediumResponce.Y = 500f;
            vector2_HighResponce.X = 170f; vector2_HighResponce.Y = 1000f;
            vector2_MaxResponce.X = 1000f; vector2_MaxResponce.Y = 90000f;

            //Low Frequency Band / getVector2_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepLowFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getVector2_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepMidFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getVector2_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(vector2_MinResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(vector2_LowMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(vector2_MediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(vector2_HighMediumResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(vector2_HighResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(vector2_MaxResponce, audioAnalysis.getVector2_6StepHighFrq(vector2_MinResponce, vector2_LowMediumResponce, vector2_MediumResponce,
                vector2_HighMediumResponce, vector2_HighResponce, vector2_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f  
        }

        //Test getTimeSpan_3Step Low, Mid, and High functions
        //returns an XNA TimeSpan depending on the float values:
        //Return minimunInterval if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call). 
        //Return midInterval if min < low/mid/high FrBandAverag >= max. 
        //Return maximunInterval if low/mid/high FrBandAverag > max.
        [Test]
        public void getTimeSpan_3Step_EquivalencePartitioning()
        {
            float min = 0.25f; float max = 0.9f;
            float minimunInterval = 0.15f;
            float midInterval = 0.54f;
            float maximunInterval = 0.92f;
            TimeSpan timeSpanMax = TimeSpan.FromSeconds(maximunInterval);
            TimeSpan timeSpanMid = TimeSpan.FromSeconds(midInterval);
            TimeSpan timeSpanMin = TimeSpan.FromSeconds(minimunInterval);

            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower edge of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.125f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.26f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.45f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.9f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.91f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 0.955f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepLowFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper edge of LowFrBandAverage > 0.9f

            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower edge of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.125f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.26f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.45f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.9f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.91f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 0.955f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepMidFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper edge of MidFrBandAverage > 0.9f

            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower edge of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.125f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.26f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.45f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.9f;
            Assert.AreEqual(timeSpanMid, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.91f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Lower boundry of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 0.955f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Middle of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_3StepHighFrq(minimunInterval, midInterval, maximunInterval, min, max)); //Upper edge of HighFrBandAverage > 0.9f
        }
        //Test getTimeSpan_6Step Low, Mid, and High functions
        //returns an XNA TimeSpan depending on the float values: 
        //Return TimeSpan_MinResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return TimeSpan_LowMediumResponce if min < low/mid/high FrBandAverag <= x1. 
        //Return TimeSpan_MediumResponce if x1 < low/mid/high FrBandAverag <= x2. 
        //Return TimeSpan_HighMediumResponce if x2 < low/mid/high FrBandAverag <= x3. 
        //Return TimeSpan_HighResponce if x3 < low/mid/high FrBandAverag >= max. 
        //Return TimeSpan_MaxResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getTimeSpan_6Step_EquivalencePartitioning()
        {
            float minInterval = 0.15f;
            float lowMediumInterval = 0.54f;
            float mediumInterval = 0.92f;
            float highMediumInterval = 1.5f;
            float highInterval = 2f;
            float maxInterval = 1000.5201f;
            TimeSpan timeSpanMax = TimeSpan.FromSeconds(minInterval);
            TimeSpan timeSpanHigh = TimeSpan.FromSeconds(lowMediumInterval);
            TimeSpan timeSpanHighMedium = TimeSpan.FromSeconds(mediumInterval);
            TimeSpan timeSpanMedium = TimeSpan.FromSeconds(highMediumInterval);
            TimeSpan timeSpanLowMedium = TimeSpan.FromSeconds(highInterval);
            TimeSpan timeSpanMin = TimeSpan.FromSeconds(maxInterval);

            //Low Frequency Band / getTimeSpan_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepLowFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getTimeSpan_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepMidFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getTimeSpan_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(timeSpanMin, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(timeSpanLowMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(timeSpanMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(timeSpanHighMedium, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(timeSpanHigh, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(timeSpanMax, audioAnalysis.getTimeSpan_6StepHighFrq(minInterval, lowMediumInterval, mediumInterval,
                highMediumInterval, highInterval, maxInterval, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f 
        }

        //Test getColour_3Step Low, Mid, and High functions
        //returns an XNA Color depending on the float values:
        //Return colour_LowResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call). 
        //Return colour_MediumResponce if min < low/mid/high FrBandAverag >= max. 
        //Return colour_HighResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getColour_3Step_EquivalencePartitioning()
        {
                float min = 0.25f; float max = 0.9f;
            Color colour_LowResponce = new Color(1.0f, 0.0f, 0.0f);
            Color colour_MediumResponce = new Color(0.0f, 1.0f, 0.0f);
            Color colour_HighResponce = new Color(0.0f, 0.0f, 1.0f);

            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower edge of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.125f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.26f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.45f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.9f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.91f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 0.955f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepLowFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper edge of LowFrBandAverage > 0.9f

            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower edge of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.125f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.26f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.45f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.9f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.91f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 0.955f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepMidFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper edge of MidFrBandAverage > 0.9f

            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower edge of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.125f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(colour_LowResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.26f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.45f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.9f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.91f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Lower boundry of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 0.955f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Middle of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_3StepHighFrq(colour_LowResponce, colour_MediumResponce, colour_HighResponce, min, max)); //Upper edge of HighFrBandAverage > 0.9f   
        }
        //Test getColour_6Step Low, Mid, and High functions
        //returns an XNA colour depending on the float values: 
        //Return colour_MinResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return colour_LowMediumResponce if min < low/mid/high FrBandAverag <= x1. 
        //Return colour_MediumResponce if x1 < low/mid/high FrBandAverag <= x2. 
        //Return colour_HighMediumResponce if x2 < low/mid/high FrBandAverag <= x3. 
        //Return colour_HighResponce if x3 < low/mid/high FrBandAverag >= max. 
        //Return colour_MaxResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getColour_6Step_EquivalencePartitioning()
        {
            float min = 0.25f; float max = 0.9f;
            Color colour_MinResponce = new Color(1.0f, 0.0f, 0.0f);
            Color colour_LowMediumResponce = new Color(0.0f, 1.0f, 0.0f);
            Color colour_MediumResponce = new Color(0.0f, 0.0f, 1.0f);
            Color colour_HighMediumResponce = new Color(1.0f, 0.0f, 0.0f);
            Color colour_HighResponce = new Color(0.0f, 1.0f, 0.0f);
            Color colour_MaxResponce = new Color(0.0f, 0.0f, 1.0f);

            //Low Frequency Band / getColour_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepLowFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getColour_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepMidFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getColour_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(colour_MinResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(colour_LowMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(colour_MediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(colour_HighMediumResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(colour_HighResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(colour_MaxResponce, audioAnalysis.getColour_6StepHighFrq(colour_MinResponce, colour_LowMediumResponce, colour_MediumResponce,
                colour_HighMediumResponce, colour_HighResponce, colour_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f  
        }

        //Test getColourArray_3Step Low, Mid, and High functions
        //returns an XNA Color[] depending on the float values:
        //Return colourArray_LowResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call). 
        //Return colourArray_MediumResponce if min < low/mid/high FrBandAverag >= max. 
        //Return colourArray_HighResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getColourArray_3Step_EquivalencePartitioning()
        {
            float min = 0.25f; float max = 0.9f;
            Color[] colourArray_LowResponce = new Color[2]; //array of 2 colours
            Color[] colourArray_MediumResponce = new Color[2]; //array of 2 colours
            Color[] colourArray_HighResponce = new Color[2]; //array of 2 colours
            //Colours for a low responce
            colourArray_LowResponce[0] = new Color(0, 153, 153);
            colourArray_LowResponce[1] = new Color(153, 153, 0);
            //Colours for a medium responce
            colourArray_MediumResponce[0] = new Color(152, 237, 0);
            colourArray_MediumResponce[1] = new Color(0, 237, 152);
            //Colours for a high responce
            colourArray_HighResponce[0] = new Color(208, 0, 110);
            colourArray_HighResponce[1] = new Color(110, 0, 208);

            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower edge of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.125f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of LowFrBandAverage <= 0.25f
            audioAnalysis.LowFrBandAverage = 0.26f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.45f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.9f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper boundry of 0.25f < LowFrBandAverage >= 0.9f
            audioAnalysis.LowFrBandAverage = 0.91f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 0.955f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of LowFrBandAverage > 0.9f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepLowFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper edge of LowFrBandAverage > 0.9f

            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower edge of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.125f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of MidFrBandAverage <= 0.25f
            audioAnalysis.MidFrBandAverage = 0.26f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.45f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.9f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper boundry of 0.25f < MidFrBandAverage >= 0.9f
            audioAnalysis.MidFrBandAverage = 0.91f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 0.955f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of MidFrBandAverage > 0.9f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepMidFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper edge of MidFrBandAverage > 0.9f

            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower edge of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.125f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_LowResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of HighFrBandAverage <= 0.25f
            audioAnalysis.HighFrBandAverage = 0.26f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.45f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.9f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper boundry of 0.25f < HighFrBandAverage >= 0.9f
            audioAnalysis.HighFrBandAverage = 0.91f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Lower boundry of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 0.955f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Middle of HighFrBandAverage > 0.9f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_3StepHighFrq(colourArray_LowResponce, colourArray_MediumResponce, colourArray_HighResponce, min, max)); //Upper edge of HighFrBandAverage > 0.9f   
        }
        //Test getColourArray_6Step Low, Mid, and High functions
        //returns an XNA Color[] depending on the float values: 
        //Return colourArray_MinResponce if the min value is not exceeded by the low/mid/high FrBandAverage (depending on the function call).
        //Return colourArray_LowMediumResponce if min < low/mid/high FrBandAverag <= x1. 
        //Return colourArray_MediumResponce if x1 < low/mid/high FrBandAverag <= x2. 
        //Return colourArray_HighMediumResponce if x2 < low/mid/high FrBandAverag <= x3. 
        //Return colourArray_HighResponce if x3 < low/mid/high FrBandAverag >= max. 
        //Return colourArray_MaxResponce if low/mid/high FrBandAverag > max.
        [Test]
        public void getColourArray_6Step_EquivalencePartitioning()
        {
            Color[] colourArray_MinResponce = new Color[2]; //array of 2 colours
            Color[] colourArray_LowMediumResponce = new Color[2]; //array of 2 colours
            Color[] colourArray_MediumResponce = new Color[5]; //array of 2 colours
            Color[] colourArray_HighMediumResponce = new Color[1]; //array of 2 colours
            Color[] colourArray_HighResponce = new Color[1]; //array of 2 colours
            Color[] colourArray_MaxResponce = new Color[3]; //array of 2 colours
            //Colours for a min responce
            colourArray_MinResponce[0] = new Color(0, 153, 153);
            colourArray_MinResponce[1] = new Color(153, 153, 0);
            //Colours for a lowMedium responce
            colourArray_LowMediumResponce[0] = new Color(152, 237, 0);
            colourArray_LowMediumResponce[1] = new Color(0, 237, 152);
            //Colours for a medium responce
            colourArray_MediumResponce[0] = new Color(208, 0, 110);
            colourArray_MediumResponce[1] = new Color(110, 0, 208);
            colourArray_MediumResponce[2] = new Color(0, 0, 110);
            colourArray_MediumResponce[3] = new Color(110, 0, 0);
            colourArray_MediumResponce[4] = new Color(110, 200, 208);
            //Colours for a highMedium responce
            colourArray_HighMediumResponce[0] = new Color(153, 153, 153);
            //Colours for a high responce
            colourArray_HighResponce[0] = new Color(111, 111, 111);
            //Colours for a max responce
            colourArray_MaxResponce[0] = new Color(1, 0, 0);
            colourArray_MaxResponce[1] = new Color(0, 1, 0);
            colourArray_MaxResponce[2] = new Color(0, 0, 1);

            //Low Frequency Band / getColourArray_6StepLowFrq(...) Testing. 
            audioAnalysis.LowFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.05f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.1f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage <= 0.1f
            audioAnalysis.LowFrBandAverage = 0.11f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.15f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.2f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < LowFrBandAverage <= 0.2f
            audioAnalysis.LowFrBandAverage = 0.21f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.3f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < LowFrBandAverage <= 0.3f
            audioAnalysis.LowFrBandAverage = 0.31f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.35f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.4f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < LowFrBandAverage <= 0.4f
            audioAnalysis.LowFrBandAverage = 0.41f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.55f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.7f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < LowFrBandAverage <= 0.7f
            audioAnalysis.LowFrBandAverage = 0.71f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 0.85f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of LowFrBandAverage > 0.7f
            audioAnalysis.LowFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepLowFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of LowFrBandAverage > 0.7f

            //Mid Frequency Band / getColourArray_6StepHighFrq(...) Testing.
            audioAnalysis.MidFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.05f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.1f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage <= 0.1f
            audioAnalysis.MidFrBandAverage = 0.11f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.15f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.2f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < MidFrBandAverage <= 0.2f
            audioAnalysis.MidFrBandAverage = 0.21f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.3f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < MidFrBandAverage <= 0.3f
            audioAnalysis.MidFrBandAverage = 0.31f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.35f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.4f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < MidFrBandAverage <= 0.4f
            audioAnalysis.MidFrBandAverage = 0.41f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.55f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.7f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < MidFrBandAverage <= 0.7f
            audioAnalysis.MidFrBandAverage = 0.71f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 0.85f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of MidFrBandAverage > 0.7f
            audioAnalysis.MidFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepMidFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of MidFrBandAverage > 0.7f

            //High Frequency Band / getColourArray_6StepHighFrq(...) Testing.
            audioAnalysis.HighFrBandAverage = 0.0f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower edge of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.05f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.1f;
            Assert.AreEqual(colourArray_MinResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage <= 0.1f
            audioAnalysis.HighFrBandAverage = 0.11f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.15f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.2f;
            Assert.AreEqual(colourArray_LowMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.1f < HighFrBandAverage <= 0.2f
            audioAnalysis.HighFrBandAverage = 0.21f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.25f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.3f;
            Assert.AreEqual(colourArray_MediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.2f < HighFrBandAverage <= 0.3f
            audioAnalysis.HighFrBandAverage = 0.31f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.35f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.4f;
            Assert.AreEqual(colourArray_HighMediumResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.3f < HighFrBandAverage <= 0.4f
            audioAnalysis.HighFrBandAverage = 0.41f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.55f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.7f;
            Assert.AreEqual(colourArray_HighResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper boundry of 0.4f < HighFrBandAverage <= 0.7f
            audioAnalysis.HighFrBandAverage = 0.71f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Lower boundry of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 0.85f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Middle of HighFrBandAverage > 0.7f
            audioAnalysis.HighFrBandAverage = 1.0f;
            Assert.AreEqual(colourArray_MaxResponce, audioAnalysis.getColourArray_6StepHighFrq(colourArray_MinResponce, colourArray_LowMediumResponce, colourArray_MediumResponce,
                colourArray_HighMediumResponce, colourArray_HighResponce, colourArray_MaxResponce, 0.1f, 0.2f, 0.3f, 0.4f, 0.7f)); //Upper edge of HighFrBandAverage > 0.7f      
        }
    }
}
