namespace Stripe
{
	public class StripeTokenService : StripeService
	{
		public StripeTokenService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeTokenService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeToken Create(StripeTokenCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Tokens);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeToken>(response);
		}

		public virtual StripeToken Get(string tokenId)
		{
			var url = string.Format("{0}/{1}", Urls.Tokens, tokenId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeToken>(response);
		}
	}
}