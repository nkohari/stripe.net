using System.Collections.Generic;

namespace Stripe
{
	public class StripeEventService : StripeService
	{
		public StripeEventService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeEventService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeEvent Get(string eventId)
		{
			var url = string.Format("{0}/{1}", Urls.Events, eventId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeEvent>(response);
		}

		public virtual IEnumerable<StripeEvent> List(StripeEventListOptions listOptions = null)
		{
			var url = Urls.Events;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeEvent>(response);
		}
	}
}