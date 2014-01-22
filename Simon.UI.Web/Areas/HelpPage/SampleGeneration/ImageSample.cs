using System;

namespace Simon.UI.Web.Areas.HelpPage
{
	/// <summary>
	/// This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
	/// </summary>
	public class ImageSample
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageSample"/> class.
		/// </summary>
		/// <param name="src">The URL of an image.</param>
		public ImageSample(string src)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			Src = src;
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		public string Src { get; private set; }

		/// <summary>
		/// Determines whether the specified <paramref name="obj"/> is equal to the current <see cref="ImageSample"/> instance.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>
		/// <c>true</c> if equal otherwise; <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			ImageSample other = obj as ImageSample;
			return other != null && Src == other.Src;
		}

		/// <summary>
		/// Serves as a hash function for <see cref="ImageSample"/>.
		/// </summary>
		/// <returns>
		/// A hash code for current <see cref="ImageSample"/> instance.
		/// </returns>
		public override int GetHashCode()
		{
			return Src.GetHashCode();
		}

		/// <summary>
		/// Returns a string that represents the current <see cref="ImageSample"/> instance.
		/// </summary>
		/// <returns>
		/// A string that represents the current <see cref="ImageSample"/> instance.
		/// </returns>
		public override string ToString()
		{
			return Src;
		}
	}
}