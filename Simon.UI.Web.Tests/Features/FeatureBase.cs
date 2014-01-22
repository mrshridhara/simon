namespace Simon.UI.Web.Tests.Features
{
	public abstract class FeatureBase<TSteps>
		where TSteps : class, new()
	{
		private readonly TSteps steps;

		protected FeatureBase()
		{
			steps = new TSteps();
		}

		protected TSteps Given
		{
			get { return steps; }
		}

		protected TSteps When
		{
			get { return steps; }
		}

		protected TSteps Then
		{
			get { return steps; }
		}

		protected TSteps And
		{
			get { return steps; }
		}

		protected TSteps Or
		{
			get { return steps; }
		}
	}
}