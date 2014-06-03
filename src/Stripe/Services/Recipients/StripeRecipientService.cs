using System.Collections.Generic;

namespace Stripe
{
	public class StripeRecipientService : StripeService
	{
		public StripeRecipientService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeRecipientService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeRecipient Create(StripeRecipientCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Recipients);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeRecipient>(response);
		}

		public virtual StripeRecipient Get(string recipientId)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeRecipient>(response);
		}

		public virtual StripeRecipient Update(string recipientId, StripeRecipientUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeRecipient>(response);
		}

		public virtual void Delete(string recipientId)
		{
			var url = string.Format("{0}/{1}", Urls.Recipients, recipientId);

			Requestor.Delete(url, ApiKey);
		}

		public virtual IEnumerable<StripeRecipient> List(StripeRecipientListOptions listOptions = null)
		{
			var url = Urls.Recipients;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeRecipient>(response);
		}
	}
}
