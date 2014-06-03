using System.Net;
using Machine.Specifications;
using System;

namespace Stripe.Tests
{
	public class when_requesting_a_mismatched_certificate
	{
        protected static IRequestor _requestor = new Requestor();
        private static WebException ex;

		Because of = () =>
			ex = (WebException) Catch.Exception(() => _requestor.GetString("https://mismatched.stripe.com/", ""));

		It should_raise_a_trust_exception = () =>
			ex.Status.ShouldEqual(WebExceptionStatus.TrustFailure);
	}
}
