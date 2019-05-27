using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CraftMine
{
	[RestResource]
	public class REST
	{
		string[] names;

		[RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/load_headers")]
		public IHttpContext LoadHeaders(IHttpContext context)
		{
			try
			{
				context.Response.ContentType = ContentType.JSON;
				Dictionary<string, string> payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(context.Request.Payload);
				foreach (KeyValuePair<string, string> value in payload)
				{
					string header = value.Value;
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return context;
		}

		[RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/load_file")]
		public IHttpContext LoadFile(IHttpContext context)
		{
			try
			{
				context.Response.ContentType = ContentType.JSON;
				Dictionary<string, string> payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(context.Request.Payload);

			}
			catch (Exception e)
			{
				throw e;
			}
			return context; 
		}
	}
}
