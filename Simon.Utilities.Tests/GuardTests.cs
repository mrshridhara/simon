using System;
using NUnit.Framework;

namespace Simon.Utilities.Tests
{
	[TestFixture]
	public class GuardTests
	{
		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentNullException))]
		public void Shrould_ThrowException_For_NullArgument()
		{
			Guard.NotNullArgument<object>("test", null);
		}

		[Test]
		public void ShrouldNot_ThrowException_For_NotNullArgument()
		{
			Guard.NotNullArgument("test", "sample text");
			Guard.NotNullArgument("test", new object());
		}

		[Test]
		[TestCase("")]
		[TestCase("       ")]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void Shrould_ThrowException_For_EmptyStringArgument(string argumentValue)
		{
			Guard.NotNullOrEmptyStringArgument("test", argumentValue);
		}

		[Test]
		[TestCase("sample text")]
		[TestCase("another sample text")]
		public void ShrouldNot_ThrowException_For_NonEmptyStringArgument(string argumentValue)
		{
			Guard.NotNullOrEmptyStringArgument("test", argumentValue);
		}

		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void Shrould_ThrowException_For_DefaultGuidArgument()
		{
			Guard.NotDefaultValueArgument("test", Guid.Empty);
		}

		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void Shrould_ThrowException_For_DefaultIntArgument()
		{
			Guard.NotDefaultValueArgument("test", 0);
		}

		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void Shrould_ThrowException_For_DefaultDoubleArgument()
		{
			Guard.NotDefaultValueArgument("test", 0.0);
		}

		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void Shrould_ThrowException_For_DefaultDeclimalArgument()
		{
			Guard.NotDefaultValueArgument("test", 0.0M);
		}

		[Test]
		public void ShrouldNot_ThrowException_For_NonNonDefaultArgument()
		{
			Guard.NotDefaultValueArgument("test", Guid.NewGuid());
			Guard.NotDefaultValueArgument("test", 1);
			Guard.NotDefaultValueArgument("test", 3.5);
			Guard.NotDefaultValueArgument("test", 6.5M);
		}
	}
}
