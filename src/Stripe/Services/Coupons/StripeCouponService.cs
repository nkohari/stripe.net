using System.Collections.Generic;

namespace Stripe
{
	public class StripeCouponService : StripeService
	{
		public StripeCouponService(string apiKey = null)
			: base(apiKey)
		{
		}

		public StripeCouponService(string apiKey, IMapper mapper, IRequestor requestor, IParameterBuilder parameterBuilder)
			: base(apiKey, mapper, requestor, parameterBuilder)
		{
		}

		public virtual StripeCoupon Create(StripeCouponCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Coupons);

			var response = Requestor.PostString(url, ApiKey);

			return Mapper.MapFromJson<StripeCoupon>(response);
		}

		public virtual StripeCoupon Get(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapFromJson<StripeCoupon>(response);
		}

		public virtual void Delete(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);

			Requestor.Delete(url, ApiKey);
		}

		public virtual IEnumerable<StripeCoupon> List(StripeListOptions listOptions = null)
		{
			var url = Urls.Coupons;

			if (listOptions != null)
				url = ParameterBuilder.ApplyAllParameters(listOptions, url);

			var response = Requestor.GetString(url, ApiKey);

			return Mapper.MapCollectionFromJson<StripeCoupon>(response);
		}
	}
}