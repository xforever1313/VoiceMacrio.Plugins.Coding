//
//          Copyright Seth Hendrick 2021.
// Distributed under the Boost Software License, Version 1.0.
//    (See accompanying file LICENSE_1_0.txt or copy at
//          http://www.boost.org/LICENSE_1_0.txt)
//

using System;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace VoiceMacro.Plugins.Coding.Tests.UnitTests
{
    [TestFixture]
    public sealed class CreateGuidOutVarCommandTests
    {
        // ---------------- Fields ----------------

        private Mock<IVmCommands> vmCommands;
        private CreateGuidOutVarCommand uut;

        // ---------------- Setup / Teardown ----------------

        [SetUp]
        public void TestSetup()
        {
            this.vmCommands = new Mock<IVmCommands>( MockBehavior.Strict );
            this.uut = new CreateGuidOutVarCommand( this.vmCommands.Object );
        }

        [TearDown]
        public void TestTeardown()
        {
        }

        // ---------------- Tests ----------------

        [Test]
        public void CreateGuidWithDefaultFormatTest()
        {
            string format = string.Empty;

            Regex expectedRegex = new Regex(
                @"^\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$"
            );

            DoCreateGuidTest( format, expectedRegex );
        }

        [Test]
        public void CreateGuidWithRegistryFormatTest()
        {
            const string format = "B";
            Regex expectedRegex = new Regex(
                @"^\{\w{8}-\w{4}-\w{4}-\w{4}-\w{12}\}$"
            );

            DoCreateGuidTest( format, expectedRegex );
        }

        // ---------------- Test Helpers ------------------

        private void DoCreateGuidTest( string format, Regex expectedRegex )
        {
            // Setup
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
            this.uut.ReceiveParams( varName, format, string.Empty, true );

            // Check
            Assert.IsNotNull( setValue );
            Assert.IsTrue( Guid.TryParse( setValue, out Guid _ ) );
            Assert.IsTrue( expectedRegex.IsMatch( setValue ) );
        }
    }
}
