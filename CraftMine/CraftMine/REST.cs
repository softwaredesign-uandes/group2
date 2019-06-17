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
                BlockModel blockModel = new BlockModel(blocks, names);
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
                json.block_model = new JArray();
                json.block_model.Add(JObject.Parse("{ \"id\" : " + blockmodel.id + " }"));
                string jsonParse = json.ToString();
                context.Response.SendResponse(jsonParse);
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

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/mineral_deposits")]
        public IHttpContext CreateMineralDeposit(IHttpContext context)
        {
            try
            {
                context.Response.ContentType = ContentType.JSON;
                dynamic payload = JsonConvert.DeserializeObject(context.Request.Payload);
                string name = payload.mineral_deposit.name.ToObject<string>();
                MineralDeposit mineralDeposit = new MineralDeposit(name);

                context.Response.SendResponse("Ok");
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/mineral_deposits/[id]")]
        public IHttpContext GetMineralDeposit(IHttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.PathParameters["id"]);
                MineralDeposit mineralDeposit = MineralContainer.getMineralDepositByID(id);
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.mineral_deposit = new JArray();
                string jsonName = mineralDeposit.name;
                json.mineral_deposit.Add(JObject.Parse("{ \"id\" : " + mineralDeposit.id + ", \"name\" : \"" + jsonName + "\" }"));
                string jsonParse = json.ToString();
                context.Response.SendResponse(jsonParse);
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/mineral_deposits")]
        public IHttpContext GetMineralDeposits(IHttpContext context)
        {
            try
            {
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.mineral_deposit = new JArray();
                List<MineralDeposit> mineralDeposits = MineralContainer.getMineralDeposits();
                foreach (MineralDeposit mineralDeposit in mineralDeposits)
                {
                    string jsonName = mineralDeposit.name;
                    json.mineral_deposit.Add(JObject.Parse("{ \"id\":" + mineralDeposit.id + ", \"name\" : \"" + jsonName + "\" }"));
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

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/block_models/[modelID]/blocks/[id]")]
        public IHttpContext GetBlock(IHttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.PathParameters["id"]);
                int modelID = int.Parse(context.Request.PathParameters["modelID"]);
                BlockModel blockModel = MineralContainer.getBlockModelByID(modelID);
                Block chosenBlock = blockModel.blocks[id];
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.block = new JArray();
                string x = chosenBlock.x.ToString();
                string y = chosenBlock.y.ToString();
                string z = chosenBlock.z.ToString();
                json.block.Add(JObject.Parse("{ \"x_index\" : \"" + x + "\", \"y_index\" : \"" + y + "\", \"z_index\" : \"" + z + "\" }"));
                string jsonParse = json.ToString();
                context.Response.SendResponse(jsonParse);
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.GET, PathInfo = "/block_models/[modelID]/blocks")]
        public IHttpContext GetBlocks(IHttpContext context)
        {
            try
            {
                int modelID = int.Parse(context.Request.PathParameters["modelID"]);
                BlockModel blockModel = MineralContainer.getBlockModelByID(modelID);
                context.Response.ContentType = ContentType.JSON;
                dynamic json = new JObject();
                json.block = new JArray();
                foreach (Block block in blockModel.blocks)
                {
                    string id = block.id.ToString();
                    string x = block.x.ToString();
                    string y = block.y.ToString();
                    string z = block.z.ToString();
                    json.block.Add(JObject.Parse("{ \"id\" : \"" + id + "\", \"x_index\" : \"" + x + "\", \"y_index\" : \"" + y + "\", \"z_index\" : \"" + z + "\" }"));
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

        [RestRoute(HttpMethod = Grapevine.Shared.HttpMethod.POST, PathInfo = "/block_models/[modelID]/blocks/[id]")]
        public IHttpContext UpdateBlock(IHttpContext context)
        {
            try
            {
                int modelID = int.Parse(context.Request.PathParameters["modelID"]);
                int id = int.Parse(context.Request.PathParameters["id"]);
                BlockModel blockModel = MineralContainer.getBlockModelByID(modelID);
                context.Response.ContentType = ContentType.JSON;
                dynamic payload = JsonConvert.DeserializeObject(context.Request.Payload);
                int xCoordinates = payload.block.x_indices.ToObject<int>();
                int yCoordinates = payload.block.y_indices.ToObject<int>();
                int zCoordinates = payload.block.z_indices.ToObject<int>();
                Dictionary<string, double> grades = payload.block.grades.ToObject<Dictionary<string, double>>();

                Block block = new Block(id, xCoordinates, yCoordinates, zCoordinates, grades);
                Block blockOld = blockModel.blocks.First(B => B.getID() == id);
                int index = blockModel.blocks.IndexOf(blockOld);
                blockModel.blocks[index] = block;

                context.Response.SendResponse("Ok");
            }
            catch (Exception e)
            {
                context.Response.SendResponse(e.ToString());
            }
            return context;
        }
    }
}
