using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stripe
{
	public class StripeSubscriptionService : StripeService
	{
		public StripeSubscriptionService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeSubscriptionService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeSubscription Get(string customerId, string subscriptionId)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeSubscription>(response);
		}

		public virtual StripeSubscription Create(string customerId, string planId, StripeSubscriptionCreateOptions createOptions)
		{
			var url = string.Format(Urls.Subscriptions, customerId);
			url = ParameterBuilder.ApplyParameterToUrl(url, "plan", planId);
			url = ParameterBuilder.ApplyAllParameters(createOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeSubscription>(response);
		}

		public virtual StripeSubscription Update(string customerId, string subscriptionId, StripeSubscriptionUpdateOptions updateOptions)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeSubscription>(response);
		}

		public virtual StripeSubscription Cancel(string customerId, string subscriptionId, bool cancelAtPeriodEnd = false)
		{
			var url = string.Format(Urls.Subscriptions + "/{1}", customerId, subscriptionId);
			url = ParameterBuilder.ApplyParameterToUrl(url, "at_period_end", cancelAtPeriodEnd.ToString());

			var response = Requestor.Delete(url, ApiKey);

			return Mapper.MapFromJson<StripeSubscription>(response);
		}

		public virtual IEnumerable<StripeSubscription> List(string customerId, StripeListOptions listOptions = null)
		{
			var url = string.Format(Urls.Subscriptions, customerId);

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeSubscription>(response);
		}
	}
}