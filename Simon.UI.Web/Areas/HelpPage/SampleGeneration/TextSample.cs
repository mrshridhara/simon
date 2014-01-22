using System;

namespace Simon.UI.Web.Areas.HelpPage
{
    /// <summary>
    /// This represents a preformatted text sample on the help page.
	/// There's a display template named TextSample associated with this class.
    /// </summary>
    public class TextSample
    {
		/// <summary>
		/// Initializes an instance of <see cref="TextSample"/>.
		/// </summary>
		/// <param name="text">The text.</param>
        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            Text = text;
        }

		/// <summary>
		/// Get the text.
		/// </summary>
        public string Text { get; private set; }

		/// <summary>
		/// Determines whether the specified <paramref name="obj"/> is equal to the current <see cref="TextSample"/> instance.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>
		/// <c>true</c> if equal otherwise; <c>false</c>.
		/// </returns>
        public override bool Equals(object obj)
        {
            TextSample other = obj as TextSample;
            return other != null && Text == other.Text;
        }

		/// <summary>
		/// Serves as a hash function for <see cref="TextSample"/>.
		/// </summary>
		/// <returns>
		/// A hash code for current <see cref="TextSample"/> instance.
		/// </returns>
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }

		/// <summary>
		/// Returns a string that represents the current <see cref="TextSample"/> instance.
		/// </summary>
		/// <returns>
		/// A string that represents the current <see cref="TextSample"/> instance.
		/// </returns>
        public override string ToString()
        {
            return Text;
        }
    }
}