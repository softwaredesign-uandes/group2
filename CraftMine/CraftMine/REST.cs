using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
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

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/block_models")]
        public IHttpContext CreateBlockModel(IHttpContext context)
        {
            try
            {
                context.Response.ContentType = ContentType.JSON;
                dynamic payload = JsonConvert.DeserializeObject(context.Request.Payload);
                int[] xCoordinates = payload.block_model.x_indices.ToObject<int[]>();
                int[] yCoordinates = payload.block_model.y_indices.ToObject<int[]>();
                int[] zCoordinates = payload.block_model.z_indices.ToObject<int[]>();
                int[] weights = payload.block_model.weights.ToObject<int[]>();
                Dictionary<string, double[]> grades = payload.block_model.grades.ToObject<Dictionary<string, double[]>>();
                int xMax = xCoordinates.Max();
                int yMax = yCoordinates.Max();
                int zMax = zCoordinates.Max();
                int blockAmount = xCoordinates.Length;
                List<Block> blocks = new List<Block>();
                Dictionary<int, string> names = new Dictionary<int, string>();
                int nameId = 0;
                foreach (string key in grades.Keys)
                {
                    names[nameId] = key;
                    nameId++;
                }
                for (int i = 0; i < blockAmount; i++)
                {
                    Dictionary<string, double> stats = new Dictionary<string, double>();
                    foreach(string key in grades.Keys)
                    {
                        stats[key] = grades[key][i];
                    }
                    Block block = new Block(xMax, yMax, zMax, xCoordinates[i], yCoordinates[i], zCoordinates[i], stats);
                    blocks.Add(block);
                }
                BlockModel blockModel = new BlockModel(MineralContainer.getNextBlockModelID(), blocks, names);
                context.Response.SendResponse("Ok");
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/block_models/[id]")]
        public IHttpContext GetBlockModel(IHttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.PathParameters["id"]);
                BlockModel blockmodel = MineralContainer.getBlockModelByID(id);
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.block_model = new JObject();
                
                context.Response.SendResponse("Ok");
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/block_models")]
        public IHttpContext GetBlockModels(IHttpContext context)
        {
            try
            {
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.block_model = new JArray();
                List<BlockModel> blockModels = MineralContainer.getBlockModels();
                foreach(BlockModel blockModel in blockModels)
                {
                    json.block_model.Add(JObject.Parse("{ \"id\":" + blockModel.id + "}"));
                }
            string jsonParse = json.ToString();
                context.Response.SendResponse(jsonParse);
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }
    }
}
