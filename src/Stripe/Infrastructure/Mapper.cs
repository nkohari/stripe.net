using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Stripe
{
	public class Mapper : IMapper
	{
		public List<T> MapCollectionFromJson<T>(string json, string token = "data")
		{
			var list = new List<T>();

			var jObject = JObject.Parse(json);

			var allTokens = jObject.SelectToken(token);
			foreach (var tkn in allTokens)
				list.Add(MapFromJson<T>(tkn.ToString()));

			return list;
		}

		public T MapFromJson<T>(string json, string parentToken = null)
		{
			var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

			return JsonConvert.DeserializeObject<T>(jsonToParse);
		}
	}
}