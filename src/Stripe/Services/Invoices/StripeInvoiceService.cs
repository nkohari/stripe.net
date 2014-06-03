﻿using System;
using System.Collections.Generic;

namespace Stripe
{
	public class StripeInvoiceService : StripeService
	{
		public StripeInvoiceService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeInvoiceService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeInvoice Get(string invoiceId)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, invoiceId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoice>(response);
		}

		public virtual StripeInvoice Upcoming(string customerId, string subscriptionId = null)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, "upcoming");

			url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			if (!String.IsNullOrEmpty(subscriptionId))
				url = ParameterBuilder.ApplyParameterToUrl(url, "subscription", subscriptionId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoice>(response);
		}

		public virtual StripeInvoice Update(string invoiceId, StripeInvoiceUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, invoiceId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoice>(response);
		}

		public virtual StripeInvoice Pay(string invoiceId)
		{
			var url = string.Format("{0}/{1}/pay", Urls.Invoices, invoiceId);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoice>(response);
		}

		public virtual IEnumerable<StripeInvoice> List(StripeInvoiceListOptions listOptions = null)
		{
			var url = Urls.Invoices;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeInvoice>(response);
		}

		public virtual StripeInvoice Create(string customerId)
		{
			var url = Urls.Invoices;
			url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeInvoice>(response);
		}
	}
}