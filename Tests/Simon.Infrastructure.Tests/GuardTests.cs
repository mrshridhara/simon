﻿using NUnit.Framework;
using System;

namespace Simon.Infrastructure.Tests
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void Shrould_ThrowException_For_NullArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullArgument<object>("test", null);
        }

        [Test]
        public void ShrouldNot_ThrowException_For_NotNullArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotNullArgument("test", "sample text");
            Simon.Infrastructure.Utilities.Guard.NotNullArgument("test", new object());
        }

        [Test]
        [TestCase("")]
        [TestCase("       ")]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Shrould_ThrowException_For_EmptyStringArgument(string argumentValue)
        {
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", argumentValue);
        }

        [Test]
        [TestCase("sample text")]
        [TestCase("another sample text")]
        public void ShrouldNot_ThrowException_For_NonEmptyStringArgument(string argumentValue)
        {
            Simon.Infrastructure.Utilities.Guard.NotNullOrEmptyStringArgument("test", argumentValue);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultGuidArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", Guid.Empty);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultIntArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultDoubleArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0.0);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void Shrould_ThrowException_For_DefaultDeclimalArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 0.0M);
        }

        [Test]
        public void ShrouldNot_ThrowException_For_NonNonDefaultArgument()
        {
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", Guid.NewGuid());
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 1);
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 3.5);
            Simon.Infrastructure.Utilities.Guard.NotDefaultValueArgument("test", 6.5M);
        }
    }
}
