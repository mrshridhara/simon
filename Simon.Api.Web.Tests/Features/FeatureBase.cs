using System.Diagnostics;

namespace Simon.Api.Web.Tests.Features
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
            get 
            {
                Debug.Write("Given that ");
                return steps;
            }
        }

        protected TSteps When
        {
            get
            {
                Debug.Write("When ");
                return steps;
            }
        }

        protected TSteps Then
        {
            get
            {
                Debug.Write("Then ");
                return steps;
            }
        }

        protected TSteps And
        {
            get
            {
                Debug.Write("and ");
                return steps;
            }
        }

        protected TSteps Or
        {
            get
            {
                Debug.Write("or ");
                return steps;
            }
        }
    }
}