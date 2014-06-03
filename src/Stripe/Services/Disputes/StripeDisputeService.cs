namespace Stripe
{
	public class StripeDisputeService : StripeService
	{
		public StripeDisputeService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeDisputeService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeDispute Update(string chargeId, string evidence = null)
		{
			var url = string.Format("{0}/dispute", chargeId);

			if (!string.IsNullOrEmpty(evidence))
				url = ParameterBuilder.ApplyParameterToUrl(url, "evidence", evidence);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeDispute>(response);
		}
	}
}