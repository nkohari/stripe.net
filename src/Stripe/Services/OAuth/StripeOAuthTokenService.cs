namespace Stripe
{
	public class StripeOAuthTokenService : StripeService
	{
		public StripeOAuthTokenService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeOAuthTokenService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeOAuthToken Create(StripeOAuthTokenCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.OAuthToken);

			var response = Requestor.PostStringBearer(url, ApiKey);

			return Mapper.MapFromJson<StripeOAuthToken>(response);
		}
	}
}
