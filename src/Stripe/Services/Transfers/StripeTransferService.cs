using System.Collections.Generic;

namespace Stripe
{
	public class StripeTransferService : StripeService
	{
		public StripeTransferService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeTransferService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeTransfer Create(StripeTransferCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Transfers);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeTransfer>(response);
		}

		public virtual StripeTransfer Get(string transferId)
		{
			var url = string.Format("{0}/{1}", Urls.Transfers, transferId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeTransfer>(response);
		}

		public virtual StripeTransfer Cancel(string transferId)
		{
			var url = string.Format("{0}/{1}/cancel", Urls.Transfers, transferId);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeTransfer>(response);
		}

		public virtual IEnumerable<StripeTransfer> List(StripeTransferListOptions listOptions = null)
		{
			var url = Urls.Transfers;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeTransfer>(response);
		}
	}
}