namespace Stripe
{
	public interface IParameterBuilder
	{
		string ApplyAllParameters(object obj, string url);

		string ApplyParameterToUrl(string url, string argument, string value);
	}
}

