using System.Collections.Generic;

namespace Stripe
{
	public class StripeBalanceService : StripeService
	{
		public StripeBalanceService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeBalanceService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeBalance Get()
		{
			var response = Requestor.GetString(Urls.Balance, ApiKey);
			
			return Mapper.MapFromJson<StripeBalance>(response);
		}

		public virtual StripeBalanceTransaction Get(string id)
		{
			var response = Requestor.GetString(string.Format(Urls.SpecificBalanceTransaction, id));

			return Mapper.MapFromJson<StripeBalanceTransaction>(response);
		}

		public virtual IEnumerable<StripeBalanceTransaction> List(StripeBalanceTransactionListOptions options = null)
		{
			var url = Urls.BalanceTransactions;

			if (options != null)
				url = ParameterBuilder.ApplyAllParameters(options, url);

			var response = Requestor.GetString(url);

			return Mapper.MapCollectionFromJson<StripeBalanceTransaction>(response);
		}
	}
}
