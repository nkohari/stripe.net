﻿using System.Collections.Generic;

namespace Stripe
{
	public class StripeCardService : StripeService
	{
		public StripeCardService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeCardService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeCard Create(string customerId, StripeCardCreateOptions createOptions)
		{
			var url = string.Format(Urls.Cards, customerId);
			url = ParameterBuilder.ApplyAllParameters(createOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeCard>(response);
		}

		public virtual StripeCard Get(string customerId, string cardId)
		{
			var customerUrl = string.Format(Urls.Cards, customerId);
			var url = string.Format("{0}/{1}", customerUrl, cardId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeCard>(response);
		}

		public virtual StripeCard Update(string customerId, string cardId, StripeCardUpdateOptions updateOptions)
		{
			var customerUrl = string.Format(Urls.Cards, customerId);
			var url = string.Format("{0}/{1}", customerUrl, cardId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeCard>(response);
		}

		public virtual void Delete(string customerId, string cardId)
		{
			var customerUrl = string.Format(Urls.Cards, customerId);
			var url = string.Format("{0}/{1}", customerUrl, cardId);

			Requestor.Delete(url, ApiKey);
		}

		public virtual IEnumerable<StripeCard> List(string customerId, StripeListOptions listOptions = null)
		{
			var url = string.Format(Urls.Cards, customerId);

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeCard>(response);
		}
	}
}