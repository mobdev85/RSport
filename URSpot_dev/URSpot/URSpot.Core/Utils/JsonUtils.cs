using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace URSpot.Core.Utils
{
	public static class JsonUtils
	{
		public static T GetValue<T>(this JToken jToken, string key, T defaultValue = default(T))
		{
			dynamic ret = jToken[key];
			if (ret == null) return defaultValue;
			if (ret is JObject) return JsonConvert.DeserializeObject<T>(ret.ToString());
			return (T)ret;
		}

		public static List<JToken> FindTokens(this JToken containerToken, string name)
		{
			List<JToken> matches = new List<JToken>();
			FindTokens(containerToken, name, matches);
			return matches;
		}

		private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
		{
			if (containerToken.Type == JTokenType.Object)
			{
				foreach (JProperty child in containerToken.Children<JProperty>())
				{
					if (child.Name == name)
					{
						matches.Add(child.Value);
					}
					FindTokens(child.Value, name, matches);
				}
			}
			else if (containerToken.Type == JTokenType.Array)
			{
				foreach (JToken child in containerToken.Children())
				{
					FindTokens(child, name, matches);
				}
			}
		}
	}
}
