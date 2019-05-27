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
		[RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/")]
		public IHttpContext HelloWorld(IHttpContext context)
		{
			context.Response.ContentType = ContentType.JSON;
			Dictionary<string, string> payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(context.Request.Payload);
			context.Response.SendResponse("Hello World");
			/*try
			{
				context.Response.ContentType = ContentType.JSON;
				Dictionary<string, string> payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(context.Request.Payload);
				context.Response.SendResponse(payload["test"]);

			}
			catch (Exception e)
			{
				throw e;
			}*/
			return context; 
		}
	}
}
