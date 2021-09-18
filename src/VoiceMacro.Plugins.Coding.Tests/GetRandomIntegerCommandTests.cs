//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using Moq;
using NUnit.Framework;

namespace VoiceMacro.Plugins.Coding.Tests
{
    [TestFixture]
    public sealed class GetRandomIntegerCommandTests
    {
        // ---------------- Fields ----------------

        private Mock<IVmCommands> vmCommands;
        private GetRandomIntegerCommand uut;

        // ---------------- Setup / Teardown ----------------

        [SetUp]
        public void TestSetup()
        {
            this.vmCommands = new Mock<IVmCommands>( MockBehavior.Strict );
            this.uut = new GetRandomIntegerCommand( this.vmCommands.Object );
        }

        [TearDown]
        public void TestTeardown()
        {
        }

        // ---------------- Tests ----------------

        [Test]
        public void HappyPathTest()
        {
            // Setup
            const int min = 5;
            const int max = 10;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, min.ToString(), max.ToString(), true );

            // Check
            this.vmCommands.VerifyAll();

            Assert.IsNotNull( setValue );

            Assert.IsTrue( int.TryParse( setValue, out int actualValue ) );
            Assert.IsTrue( actualValue >= min );
            Assert.IsTrue( actualValue < max );
        }

        [Test]
        public void NoMinValueTest()
        {
            // Setup
            const int max = 0;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate ( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, string.Empty, max.ToString(), true );

            // Check
            this.vmCommands.VerifyAll();

            Assert.IsNotNull( setValue );

            Assert.IsTrue( int.TryParse( setValue, out int actualValue ) );
            Assert.AreEqual( 0, actualValue ); // <- Should always be 0 since our min is always 0.
        }

        [Test]
        public void NoMaxValueTest()
        {
            // Setup
            const int min = int.MaxValue - 1;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate ( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, min.ToString(), string.Empty, true );

            // Check
            this.vmCommands.VerifyAll();

            Assert.IsNotNull( setValue );

            Assert.IsTrue( int.TryParse( setValue, out int actualValue ) );
            Assert.AreEqual( min, actualValue );
        }

        [Test]
        public void MinIsNotAnIntTest()
        {
            // Setup
            const int max = 10;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate ( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, "hello", max.ToString(), true );

            // Check
            Assert.IsNotNull( setValue );
            Assert.IsTrue( setValue.StartsWith( Constants.ErrorString ) );
        }

        [Test]
        public void MaxIsNotAnIntTest()
        {
            // Setup
            const int min = 10;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate ( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, min.ToString(), "hello", true );

            // Check
            Assert.IsNotNull( setValue );
            Assert.IsTrue( setValue.StartsWith( Constants.ErrorString ) );
        }

        [Test]
        public void MinIsGreaterThanMaxIsNotAnIntTest()
        {
            // Setup
            const int min = 10;
            const int max = min - 1;
            const string varName = "myvar_g";
            string setValue = null;

            this.vmCommands.Setup(
                m => m.SetVariable( varName, It.IsAny<string>(), string.Empty )
            ).Returns(
                delegate ( string name, string value, string GUIDP )
                {
                    setValue = value;
                    return true;
                }
            );

            // Act
            this.uut.ReceiveParams( varName, min.ToString(), max.ToString(), true );

            // Check
            Assert.IsNotNull( setValue );
            Assert.IsTrue( setValue.StartsWith( Constants.ErrorString ) );
        }
    }
}
