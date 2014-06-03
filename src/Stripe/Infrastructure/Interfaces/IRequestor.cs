using System.Net;

namespace Stripe
{
	public interface IRequestor
	{
		string GetString(string url, string apiKey = null);

		string PostString(string url, string apiKey = null);

		string PostStringBearer(string url, string apiKey = null);

		string Delete(string url, string apiKey = null);

		WebRequest GetWebRequest(string url, string method, string apiKey = null, bool useBearer = false);
	}
}

