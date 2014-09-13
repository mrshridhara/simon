using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simon.Infrastructure.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Shrould_ThrowException_For_NullArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullArgument<object>("test", null);
        }

        [TestMethod]
        public void ShrouldNot_ThrowException_For_NotNullArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullArgument("test", "sample text");
            Simon.Infrastructure.Utilities.Guard.NotNullArgument("test", new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shrould_ThrowException_For_EmptyStringArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", "");
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", "       ");
        }

        [TestMethod]
        public void ShrouldNot_ThrowException_For_NonEmptyStringArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", "sample text");
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", "another sample text");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultGuidArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", Guid.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultIntArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultDoubleArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultDeclimalArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0.0M);
        }

        [TestMethod]
        public void ShrouldNot_ThrowException_For_NonNonDefaultArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", Guid.NewGuid());
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 1);
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 3.5);
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 6.5M);
        }
    }
}