using NUnit.Framework;
using CoreAPI;

namespace PruebasUnitariasUsuarioCore
{
    [TestFixture]
    public class Tests
    {
        private UsuarioManager usuarioManager;
        private const string Test_PasswordA = "Contrasena12!";
        private const string Test_PasswordB = "contrasenna";
        private const string Test_EmailA = "valentina@gmail.com";
        private const string Test_EmailB = "triddi";
        private const string Test_EmailC = "triddi.com";

        [SetUp]
        public void Setup()
        {
            usuarioManager = new UsuarioManager("test");
        }


        [TestCase]
        public void PasswordFormatTests()
        {
            bool correctFormat = usuarioManager.ValidatePassword(Test_PasswordA);
            Assert.IsTrue(correctFormat);
            bool incorrectFormat = usuarioManager.ValidatePassword(Test_PasswordB);
            Assert.IsFalse(incorrectFormat);
        }

        [TestCase]
        public void EmailFormatTests()
        {
            bool correctFormat = usuarioManager.ValidateEmail(Test_EmailA);
            Assert.IsTrue(correctFormat);
            bool incorrectFormatA = usuarioManager.ValidateEmail(Test_EmailB);
            Assert.IsFalse(incorrectFormatA);
            bool incorrectFormatB = usuarioManager.ValidateEmail(Test_EmailC);
            Assert.IsFalse(incorrectFormatB);
        }
    }
}