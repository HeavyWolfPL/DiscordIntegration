using System.Collections.Generic;

namespace DiscordIntegration_Bot
{
	public class Config
	{
		public string BotPrefix { get; set; }
		public string BotToken { get; set; }
		public int Port { get; set; }
		public ulong PermLevel1Id { get; set; }
		public ulong Permlevel2Id { get; set; }
		public ulong Permlevel3Id { get; set; }
		public ulong Permlevel4Id { get; set; }
		public ulong CommandLogChannelId { get; set; }
		public ulong GameLogChannelId { get; set; }
		public List<string> AllowedCommands { get; set; }
		
		public static readonly Config Default = new Config
		{
			BotPrefix = "!",
			BotToken = "",
			Port = 0,
			PermLevel1Id = 0,
			Permlevel2Id = 0,
			Permlevel3Id = 0,
			Permlevel4Id = 0,
			CommandLogChannelId = 0,
			GameLogChannelId = 0,
			AllowedCommands = new List<string>()
		};
	}
}