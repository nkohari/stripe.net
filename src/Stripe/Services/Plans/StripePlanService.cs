using System.Collections.Generic;

namespace Stripe
{
	public class StripePlanService : StripeService
	{
		public StripePlanService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripePlanService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripePlan Create(StripePlanCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Plans);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripePlan>(response);
		}

		public virtual StripePlan Get(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripePlan>(response);
		}

		public virtual void Delete(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			Requestor.Delete(url, ApiKey);
		}

		public virtual StripePlan Update(string planId, StripePlanUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripePlan>(response);
		}

		public virtual IEnumerable<StripePlan> List(StripeListOptions listOptions = null)
		{
			var url = Urls.Plans;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripePlan>(response);
		}
	}
}