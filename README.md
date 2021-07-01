# DiscordIntegration

***Requires EXILED_Events to be installed***
A bot and server plugin to allow server logs to be sent to Discord channels, and for server commands to be run via the discord bot.

## Installation:
1. Extract the `DiscordIntegration_Plugin.dll` and the bot.zip archive from the initial archive.
2. Place the plugin dll inside the EXILED "Plugins" folder like any other plugin.
3. Place the included "SerializedData.dll" file in "Plugins/dependenciies".
4. Extract the included bot.zip archive, then edit the `IntegrationBotConfig.json` file.
5. In this file, you will need to enter your preferred Prefix, the token for the Discord bot to use, the ID of the channel you want RA commands to be logged to, and the channel to log everything else to. If you want to allow people to run commands via the bot, you need to add the command to the "AllowedCommands" list, and assign it a required permission level to be used, **check bot config section**... Note that only the command name needs to be present, not it's arguments. IE: "bc" would allow people to run "bc 10 hello".

---

## Bot Config
Default values and explination:

| Config | Value | Notes |
| --- | --- | --- |
| Debug | false | - |
| BotPrefix | ! | - |
| BotToken | "DISCORD_BOT_TOKEN_GOES_HERE" | don't be an idiot and don't publish the token pls |
| Port | 7777 | Server port |
| PermLevel1Id | ROLE_ID | Role that has level 1 of permissions |
| PermLevel2Id | ROLE_ID | Role that has level 2 of permissions |
| PermLevel3Id | ROLE_ID | Role that has level 3 of permissions |
| PermLevel4Id | ROLE_ID | Role that has level 4 of permissions |
| CommandLogChannelId | CHANNEL_ID | Where command logs should be sent
| GameLogChannelId | CHANNEL_ID | Where command logs should be sent
| PunishmentsLogChannelId | CHANNEL_ID | Where command logs should be sent
| AllowedCommands | SEE BELOW | SEE BELOW |
| StaffRoleId | ROLE_ID | Role that all staff members have, e.g. "Staff" |
| EggMode | false | Untested, may not work. Switch to VPS please. |
| GuildID | DISCORD_SERVER_ID | Bot will only respond in this guild. Do not use commands on 2 different servers. |

AllowedCommands: {} - the dictionary of "command":PermissionLevelRequired commands that you want the bot to be able to run on the SCP server. Multiple permission levels do not work. Specify a command only once.
In the example, anyone can run the command "list", people with permission level of 1 or higher can run "command", and people with permission level 3 or higher can run "anothercommand".

To setup permission levels, simply enter the ID of the role you want to receive a specific permission level in the appropriate config field for the desired permission level. Note, that currently each permission level supports a single RoleID only, if a user has more than one role granting them a permission level, the highest level will be used. A user with no roles that grant permission level, will have a permission level of 0.
```json
AllowedCommands: { 
  "list": 1,
	"kick": 2,
	"ban": 3,
	"config": 4,
	},
```

---

## Plugin Config
All values go in EXILED/ServerPort-config.yml and are specific to the server to which the config file belongs to.
To disable logging for any particular event, simply change it's value to false, and it will be ignored.

```yaml
  #Settings
  is_enabled: true
  debug: false
  show_ip_addresses: false | IP will be replaced with "IP Hidden" if false
  # Gameplay Log Channel
  waiting_for_players: true
  round_start: true
  round_end: true
  cheater_report: true
  player_join: true
  player_reload: true
  player_leave: true
  player_hurt: true
  player_death: true
  respawn: true
  set_class: true
  cuffed: true
  freed: true
  scp914_activation: false
  scp914_knob_change: false
  scp914_upgrade: false
  scp079_tesla: false
  scp079_exp: false
  scp079_lvl: false
  scp106_tele: false
  scp106_contain: true
  scp106_portal: false
  pocket_enter: false
  pocket_escape: false
  decon: true
  drop_item: false
  item_changed: false
  pickup_item: false
  medical_item: false
  grenade_thrown: true
  door_interact: false
  elevator: false
  locker: false
  intercom: true
  trigger_tesla: false
  warhead_access: false
  warhead_start: true
  warhead_cancel: true
  warhead_detonate: true
  gen_unlock: false
  gen_open: false
  gen_insert: false
  gen_eject: false
  gen_close: false
  gen_finish: true
  # Command Log Channel
  ra_commands: true
  console_command: true
  set_group: true
  # Punishments Log Channel + Command Log Channel
  kicked: true
  banned: true
  # Wether or not it should use the EggAddress IP for connecting to the Discord Bot. Note that while this option exists, it's use it not supported, or recommended.
  egg: false
  # The IP address to connect to the bot, if EggMode is enabled.
  egg_address: ''
  # Only log friendly fire kills.
  only_friendly_fire: false
  # Only log friendly fire damage?
  only_friendly_fire_d_m_g: true
  # Wether or not the plugin should try adn set player's roles when they join based on the Discord Bot's discord sync feature.
  role_sync: false
  role_sync2:
  - DiscordRoleID:IngameRoleName
```

---
**Made by Exiled Team**
Modified by me
[Original version](https://github.com/Exiled-Team/DiscordIntegration/tree/2.3.0)
