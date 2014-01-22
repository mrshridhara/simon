using System;

namespace Simon.UI.Web.Areas.HelpPage
{
	/// <summary>
	/// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
	/// </summary>
	public class InvalidSample
	{
		/// <summary>
		/// Initializes an instance of <see cref="InvalidSample"/> with specified <paramref name="errorMessage"/>.
		/// </summary>
		/// <param name="errorMessage">The error message.</param>
		public InvalidSample(string errorMessage)
		{
			if (errorMessage == null)
			{
				throw new ArgumentNullException("errorMessage");
			}
			ErrorMessage = errorMessage;
		}

		/// <summary>
		/// Gets the error message.
		/// </summary>
		public string ErrorMessage { get; private set; }

		/// <summary>
		/// Determines whether the specified <paramref name="obj"/> is equal to the current <see cref="InvalidSample"/> instance.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>
		/// <c>true</c> if equal otherwise; <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			InvalidSample other = obj as InvalidSample;
			return other != null && ErrorMessage == other.ErrorMessage;
		}

		/// <summary>
		/// Serves as a hash function for <see cref="InvalidSample"/>.
		/// </summary>
		/// <returns>
		/// A hash code for current <see cref="InvalidSample"/> instance.
		/// </returns>
		public override int GetHashCode()
		{
			return ErrorMessage.GetHashCode();
		}

		/// <summary>
		/// Returns a string that represents the current <see cref="InvalidSample"/> instance.
		/// </summary>
		/// <returns>
		/// A string that represents the current <see cref="InvalidSample"/> instance.
		/// </returns>
		public override string ToString()
		{
			return ErrorMessage;
		}
	}
}