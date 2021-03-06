/* Justin Thoreson
 * beacon_test.cs
 * 9 November 2020
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using P5;

namespace P5_Test
{
    [TestClass]
    public class beacon_test
    {
        [TestMethod]
        public void Test_switchOnOff_beacon()
        {
            // Arrange
            uint[] seq = new uint[] { 1, 2, 3, 4, 5 };
            beacon obj;
            int expectedSignalOff = 0;
            int expectedSignalOn1 = 5;
            int expectedSignalOn2 = 4;
            // Act
            obj = new beacon(seq);
            int signalOff1 = obj.emitSignal();
            obj.switchOnOff();
            int signalOn1 = obj.emitSignal();
            obj.switchOnOff();
            int signalOff2 = obj.emitSignal();
            obj.switchOnOff();
            int signalOn2 = obj.emitSignal();
            // Assert
            Assert.AreEqual(expectedSignalOff, signalOff1);
            Assert.AreEqual(expectedSignalOn1, signalOn1);
            Assert.AreEqual(expectedSignalOff, signalOff2);
            Assert.AreEqual(expectedSignalOn2, signalOn2);
        }

        [TestMethod]
        public void Test_emitSignal_beacon()
        {
            // Arrange
            uint[] seq = new uint[] { 1, 4, 3, 2, 5, 0, 1, 2};
            beacon obj;
            int expectedSignalOff = 0;
            int expectedSignal1 = 5;
            int expectedSignal2 = 4;
            int expectedSignal3 = 3;
            int expectedSignal4 = 2;
            int expectedSignal5 = 1;
            int expectedSignalNotCharged = 0;
            // Act
            obj = new beacon(seq);
            int signalOff = obj.emitSignal();
            obj.switchOnOff();
            int signal1 = obj.emitSignal();
            int signal2 = obj.emitSignal();
            int signal3 = obj.emitSignal();
            int signal4 = obj.emitSignal();
            int signal5 = obj.emitSignal();
            int signalNotCharged = obj.emitSignal();
            // Assert
            Assert.AreEqual(expectedSignalOff, signalOff);
            Assert.AreEqual(expectedSignal1, signal1);
            Assert.AreEqual(expectedSignal2, signal2);
            Assert.AreEqual(expectedSignal3, signal3);
            Assert.AreEqual(expectedSignal4, signal4);
            Assert.AreEqual(expectedSignal5, signal5);
            Assert.AreEqual(expectedSignal1, signal1);
            Assert.AreEqual(expectedSignalNotCharged, signalNotCharged);
        }

        [TestMethod]
        public void Test_newSeq_beacon()
        {
            // Arrange
            uint[] origSeq = new uint[] { 1, 2, 3, 4, 5, };
            uint[] newSeq = new uint[] { 6, 7, 8, 9 };
            int expectedSignal1 = 5;
            int expectedSignal2 = 9;
            beacon obj;
            // Act
            obj = new beacon(origSeq);
            obj.switchOnOff();
            int signal1 = obj.emitSignal();
            obj.newSeq(newSeq);
            int signal2 = obj.emitSignal();
            // Assert
            Assert.AreEqual(expectedSignal1, signal1);
            Assert.AreEqual(expectedSignal2, signal2);
        }
    
        [TestMethod]
        public void Test_whoAmI_beacon()
        {
            // Arrange 
            uint[] seq = new uint[] { 1, 2, 3, 4, 5 };
            beacon obj;
            uint expectedWhoAmI = 0;
            // Act
            obj = new beacon(seq);
            uint whoAmI = obj.whoAmI();
            // Assert
            Assert.AreEqual(expectedWhoAmI, whoAmI);
        }

        [TestMethod]
        public void Test_resetToOrigSeq_beacon()
        {
            // Arrange
            uint[] seq1 = new uint[] { 1, 2, 3, 4, 5 };
            uint[] seq2 = new uint[] { 6, 7, 8, 9, 10 };
            beacon obj;
            int expectedSignal1 = 5;
            int expectedSignal2 = 10;
            int expectedSignal3 = 5;
            // Act
            obj = new beacon(seq1);
            obj.switchOnOff();
            int signal1 = obj.emitSignal();
            obj.newSeq(seq2);
            int signal2 = obj.emitSignal();
            obj.resetToOrigSeq();
            int signal3 = obj.emitSignal();
            // Assert
            Assert.AreEqual(expectedSignal1, signal1);
            Assert.AreEqual(expectedSignal2, signal2);
            Assert.AreEqual(expectedSignal3, signal3);
        }
    }
}
