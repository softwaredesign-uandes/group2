using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraftMine
{
    class Program
    {
        static void Main(string[] args)
        {
			//FileManager fileManager = new FileManager();
			//fileManager.MainMenu();

			using (var server = new RestServer())
			{
				server.LogToConsole().Start();
				Console.ReadLine();
				server.Stop();
			}
		}

        

        
    }
}
