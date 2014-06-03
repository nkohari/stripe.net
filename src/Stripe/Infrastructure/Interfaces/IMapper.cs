using System.Collections.Generic;

namespace Stripe
{
	public interface IMapper
	{
		List<T> MapCollectionFromJson<T>(string json, string token = "data");

		T MapFromJson<T>(string json, string parentToken = null);
	}
}

