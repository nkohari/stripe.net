using System.Collections.Generic;

namespace Stripe
{
	public class StripeInvoiceItemService : StripeService
	{
		public StripeInvoiceItemService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeInvoiceItemService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeInvoiceItem Create(StripeInvoiceItemCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.InvoiceItems);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoiceItem>(response);
		}

		public virtual StripeInvoiceItem Get(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoiceItem>(response);
		}

		public virtual StripeInvoiceItem Update(string invoiceItemId, StripeInvoiceItemUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoiceItem>(response);
		}

		public virtual void Delete(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);

			Requestor.Delete(url, ApiKey);
		}

		public virtual IEnumerable<StripeInvoiceItem> List(StripeInvoiceItemListOptions listOptions = null)
		{
			var url = Urls.InvoiceItems;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeInvoiceItem>(response);
		}
	}
}