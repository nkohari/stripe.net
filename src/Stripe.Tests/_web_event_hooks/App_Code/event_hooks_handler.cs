using System.Web;
using System.IO;

namespace Stripe.Tests
{
	public class event_hooks_handler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return true; }
		}

		public void ProcessRequest(HttpContext context)
		{
			var mapper = new Mapper();
			var json = new StreamReader(context.Request.InputStream).ReadToEnd();
			var stripeEvent = mapper.MapFromJson<StripeEvent>(json);

			switch (stripeEvent.Type)
			{
				case "charge.refunded":
					var stripeCharge = mapper.MapFromJson<StripeCharge>(stripeEvent.Data.Object.ToString());
					break;
				case "charge.dispute.created":
					var stripeDispute = mapper.MapFromJson<StripeDispute>(stripeEvent.Data.Object.ToString());
					break;
			}
		}
	}
}