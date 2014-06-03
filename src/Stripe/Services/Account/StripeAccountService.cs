namespace Stripe
{
	public class StripeAccountService : StripeService
	{
		public StripeAccountService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeAccountService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeAccount Get()
		{
			var response = Requestor.GetString(Urls.Account, ApiKey);

			return Mapper.MapFromJson<StripeAccount>(response);
		}
	}
}