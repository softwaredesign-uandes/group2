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
		List<double[]> values = new List<double[]>();

		[RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/load_headers")]
		public IHttpContext LoadHeaders(IHttpContext context)
		{
			try
			{
				context.Response.ContentType = ContentType.JSON;
				dynamic payload = JsonConvert.DeserializeObject(context.Request.Payload);
				names = payload.names.ToObject<String[]>();
				context.Response.SendResponse("OK");

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
				dynamic payload = JsonConvert.DeserializeObject(context.Request.Payload);
				double[][] valueSegment = payload.data.ToObject<double[][]>();
				foreach (double[] value in valueSegment)
				{
					values.Add(value);
				}

				context.Response.SendResponse("OK");
				if (payload.last == "true")
				{
					FileManager fileManager = new FileManager();
					fileManager.CreateBlockModelFromSheet(names, values);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return context; 
		}
	}
}
