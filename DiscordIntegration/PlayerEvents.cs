using System;
using System.Linq;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using Scp914;
using TimeFormatter = DiscordIntegration_Plugin.Integration.TimeFormat;

namespace DiscordIntegration_Plugin
{
    public class PlayerEvents
    {
        public Plugin plugin;
        public PlayerEvents(Plugin plugin) => this.plugin = plugin;
        
	    public void OnGenInsert(InsertingGeneratorTabletEventArgs ev)
		{
			if (Plugin.Singleton.Config.GenInsert)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GenInserted}.", HandleQueue.GameLogChannelId);
		}

		public void OnGenOpen(OpeningGeneratorEventArgs ev)
		{
			if (Plugin.Singleton.Config.GenOpen)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GenOpened}.", HandleQueue.GameLogChannelId);
		}

		public void OnGenUnlock(UnlockingGeneratorEventArgs ev)
		{
			if (Plugin.Singleton.Config.GenUnlock)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GenUnlocked}.", HandleQueue.GameLogChannelId);
		}

		public void On106Contain(ContainingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp106Contain)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.WasContained}.", HandleQueue.GameLogChannelId);
		}

		public void On106CreatePortal(CreatingPortalEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp106Portal)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.CreatedPortal}.", HandleQueue.GameLogChannelId);
		}

		public void OnItemChanged(ChangingItemEventArgs ev)
		{
			if (Plugin.Singleton.Config.ItemChanged)
				if (Plugin.Singleton.Config.Scp106Portal)
					ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.ItemChanged}: {ev.OldItem.id} -> {ev.NewItem.id}.", HandleQueue.GameLogChannelId);
		}

		public void On079GainExp(GainingExperienceEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp079Exp)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GainedExp}: {ev.Amount}, {ev.GainType}.", HandleQueue.GameLogChannelId);
		}

		public void On079GainLvl(GainingLevelEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp079Lvl)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GainedLevel} {ev.OldLevel} -> {ev.NewLevel}.", HandleQueue.GameLogChannelId);
		}

		public void OnPlayerDestroyed(DestroyingEventArgs ev)
		{
			if (Plugin.Singleton.Config.PlayerLeave)
				ProcessSTT.SendData($":arrow_left: **{ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.LeftServer}.**", HandleQueue.GameLogChannelId);
		}

		public void OnPlayerReload(ReloadingWeaponEventArgs ev)
		{
			if (Plugin.Singleton.Config.PlayerReload)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.Reloaded}: {ev.Player.CurrentItem.id}.", HandleQueue.GameLogChannelId);
		}

		public void OnWarheadAccess(ActivatingWarheadPanelEventArgs ev)
		{
			if (Plugin.Singleton.Config.WarheadAccess)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.AccessedWarhead}.", HandleQueue.GameLogChannelId);
		}

		public void OnElevatorInteraction(InteractingElevatorEventArgs ev)
		{
			if (Plugin.Singleton.Config.Elevator)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.CalledElevator}.", HandleQueue.GameLogChannelId);
		}

		public void OnLockerInteraction(InteractingLockerEventArgs ev)
		{
			if (Plugin.Singleton.Config.Locker)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.UsedLocker}.", HandleQueue.GameLogChannelId);
		}

		public void OnTriggerTesla(TriggeringTeslaEventArgs ev)
		{
			if (Plugin.Singleton.Config.TriggerTesla)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.TriggeredTesla}.", HandleQueue.GameLogChannelId);
		}

		public void OnGenClosed(ClosingGeneratorEventArgs ev)
		{
			if (Plugin.Singleton.Config.GenClose)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GenClosed}.", HandleQueue.GameLogChannelId);
		}

		public void OnGenEject(EjectingGeneratorTabletEventArgs ev)
		{
			if (Plugin.Singleton.Config.GenEject)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GenEjected}.", HandleQueue.GameLogChannelId);
		}
		
		//public void OnDoorInteract(InteractingDoorEventArgs ev)
		//{
		//	if (Plugin.Singleton.Config.DoorInteract)
		//		ProcessSTT.SendData(ev.Door.NetworkTargetState
		//				? $"{ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasClosedADoor}: {ev.Door.GetComponent<DoorNametagExtension>().GetName}."
		//				: $"{ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasOpenedADoor}: {ev.Door.GetComponent<DoorNametagExtension>().GetName}.",
		//			HandleQueue.GameLogChannelId);
		//}

		public void On914Activation(ActivatingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp914Activation)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.Scp914HasBeenActivated} {Scp914Machine.singleton.knobState}.", HandleQueue.GameLogChannelId);
		}

		public void On914KnobChange(ChangingKnobSettingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp914KnobChange)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.Scp914Knobchange} {ev.KnobSetting}.", HandleQueue.GameLogChannelId);
		}

		public void OnPocketEnter(EnteringPocketDimensionEventArgs ev)
		{
			if (Plugin.Singleton.Config.PocketEnter)
				ProcessSTT.SendData(
					$":door: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.Role} ({ev.Player.Role}) {Plugin.Translation.HasEnteredPocketDimension}.",
					HandleQueue.GameLogChannelId);
		}

		public void OnPocketEscape(EscapingPocketDimensionEventArgs ev)
		{
			if (Plugin.Singleton.Config.PocketEscape)
				ProcessSTT.SendData(
					$":high_brightness: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.Role} ({ev.Player.Role}) {Plugin.Translation.HasEscapedPocketDimension}.",
					HandleQueue.GameLogChannelId);		}

		public void On106Teleport(TeleportingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp106Tele)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.HasEscapedPocketDimension}.", HandleQueue.GameLogChannelId);
		}

		public void On079Tesla(InteractingTeslaEventArgs ev)
		{
			if (Plugin.Singleton.Config.Scp079Tesla)
				ProcessSTT.SendData($":zap: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasTriggeredATeslaGate}.", HandleQueue.GameLogChannelId);
		}

		public void OnPlayerHurt(HurtingEventArgs ev)
		{
			if (Plugin.Singleton.Config.PlayerHurt)
			{
				try
				{
					string scp = "SCP-207";
					if (DamageTypes.FromIndex(ev.Tool).name == scp)
					{
						//
					}
					else
					{
						if (ev.Attacker != null && ev.Target != ev.Attacker)
						{
							if (ev.Target.Role.GetTeam() == ev.Attacker.Role.GetTeam() || ev.Attacker.Role.GetSide() == ev.Target.Role.GetSide())
							{
								ProcessSTT.SendData($":crossed_swords: **({ev.Attacker.Id}) {ev.Attacker.Nickname} - `{ev.Attacker.UserId}` ({ev.Attacker.Role}) {Plugin.Translation.Damaged} ({ev.Target.Id}) {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation._For} {ev.Amount} {Plugin.Translation.With} {DamageTypes.FromIndex(ev.Tool).name}.**", HandleQueue.GameLogChannelId);
							}
							else if (!Plugin.Singleton.Config.OnlyFriendlyFireDMG)
							{
								if (ev.Attacker != null && ev.Target != ev.Attacker && ev.Target.Role.GetTeam() == ev.Attacker.Role.GetTeam() || ev.Attacker.Role.GetSide() == ev.Target.Role.GetSide())
								{
									ProcessSTT.SendData($":crossed_swords: **({ev.Attacker.Id}) {ev.Attacker.Nickname} - `{ev.Attacker.UserId}` ({ev.Attacker.Role}) {Plugin.Translation.Damaged} ({ev.Target.Id}) {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation._For} {ev.Amount} {Plugin.Translation.With} {DamageTypes.FromIndex(ev.Tool).name}.**", HandleQueue.GameLogChannelId);
								}
								else
								{
									//ProcessSTT.SendData($"{ev.HitInformations.Attacker}  {Plugin.Translation.Damaged} {ev.Target.Nickname} - {ev.Target.UserId} ({ev.Target.Role}) {Plugin.Translation._For} {ev.Amount} {Plugin.Translation.With} {DamageTypes.FromIndex(ev.Tool).name}.", HandleQueue.GameLogChannelId);
									ProcessSTT.SendData($"{ev.Attacker.Nickname} - `{ev.Attacker.UserId}` ({ev.Attacker.Role}) {Plugin.Translation.Damaged} {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation._For} {ev.Amount} {Plugin.Translation.With} {DamageTypes.FromIndex(ev.Tool).name}.", HandleQueue.GameLogChannelId);
								}
							}
						}
						else
						{
							//
						}
					}
				}
				catch (Exception e)
				{
					Log.Error($"Player Hurt error: {e}");
				}
			}
		}
		
		public void OnPlayerDeath(DyingEventArgs ev)
		{
			if (Plugin.Singleton.Config.PlayerDeath)
			{
				try
				{
					if (ev.Killer != null && ev.Target.Role.GetTeam() == ev.Killer.Role.GetTeam() || ev.Killer.Role.GetSide() == ev.Target.Role.GetSide())
						ProcessSTT.SendData($":o: **({ev.Killer.Id}) {ev.Killer.Nickname} - `{ev.Killer.UserId}` ({ev.Killer.Role}) {Plugin.Translation.Killed} ({ev.Target.Id}) {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation.With} {DamageTypes.FromIndex(ev.HitInformation.Tool).name}.**",
							HandleQueue.GameLogChannelId);
					else if (!Plugin.Singleton.Config.OnlyFriendlyFire)
					{
						if (ev.Killer != null && ev.Killer != ev.Target && ev.Target.Role.GetTeam() == ev.Killer.Role.GetTeam() || ev.Killer.Role.GetSide() == ev.Target.Role.GetSide())
						{
							ProcessSTT.SendData($":o: **({ev.Killer.Id}) {ev.Killer.Nickname} - `{ev.Killer.UserId}` ({ev.Killer.Role}) {Plugin.Translation.Killed} ({ev.Target.Id}) {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation.With} {DamageTypes.FromIndex(ev.HitInformation.Tool).name}.**",
								HandleQueue.GameLogChannelId);
						}
						else
						{
							ProcessSTT.SendData($":skull_crossbones: **({ev.Killer.Id}) {ev.Killer.Nickname} - `{ev.Killer.UserId}` ({ev.Killer.Role}) {Plugin.Translation.Killed} ({ev.Target.Id}) {ev.Target.Nickname} - `{ev.Target.UserId}` ({ev.Target.Role}) {Plugin.Translation.With} {DamageTypes.FromIndex(ev.HitInformation.Tool).name}.**",
								HandleQueue.GameLogChannelId);
						}
					}
				}
				catch (Exception e)
				{
					Log.Error($"Player Hurt error: {e}");
				}
			}
		}

		public void OnGrenadeThrown(ThrowingGrenadeEventArgs ev)
		{
			if (Plugin.Singleton.Config.GrenadeThrown)
			{
				if (ev.Player == null)
					return;
				ProcessSTT.SendData($":bomb: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.ThrewAGrenade} **{ev.Type}**.", HandleQueue.GameLogChannelId);
			}
		}

		public void OnMedicalItem(UsedMedicalItemEventArgs ev)
		{
			if (Plugin.Singleton.Config.MedicalItem)
			{
				if (ev.Player == null)
					return;
				ProcessSTT.SendData($":medical_symbol: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.UsedA} {ev.Item}", HandleQueue.GameLogChannelId);
			}
		}

		public void OnSetClass(ChangingRoleEventArgs ev)
		{
			if (Plugin.Singleton.Config.SetClass)
			{
				if (ev.Player == null)
					return;
				ProcessSTT.SendData($":mens: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.HasBenChangedToA} {ev.NewRole}.", HandleQueue.GameLogChannelId);
			}
		}

		public void OnPlayerVerified(VerifiedEventArgs ev)
		{
            if (Plugin.Singleton.Config.RoleSync)
				Methods.CheckForSyncRole(ev.Player);
			if (Plugin.Singleton.Config.PlayerJoin && ev.Player.Nickname != "Dedicated Server")
				if (!ev.Player.ReferenceHub.serverRoles.DoNotTrack && plugin.Config.ShowIpAddresses)
					ProcessSTT.SendData($":arrow_right: **({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ||({ev.Player.IPAddress})|| {Plugin.Translation.HasJoinedTheGame}.**", HandleQueue.GameLogChannelId);
				else if (!ev.Player.ReferenceHub.serverRoles.DoNotTrack)
					ProcessSTT.SendData($":arrow_right: **({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.HasJoinedTheGame}.**", HandleQueue.GameLogChannelId);
		}

		public void OnPlayerFreed(RemovingHandcuffsEventArgs ev)
		{
			if (Plugin.Singleton.Config.Freed)
				ProcessSTT.SendData(
					$":unlock: ({ev.Target.Id}) {ev.Target.Nickname} - {ev.Target.UserId} ({ev.Target.Role}) {Plugin.Translation.HasBeenFreedBy} ({ev.Cuffer.Id}) {ev.Cuffer.Nickname} - `{ev.Cuffer.UserId}` ({ev.Cuffer.Role})",
						HandleQueue.GameLogChannelId);
		}

		public void OnPlayerHandcuffed(HandcuffingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Cuffed)
				ProcessSTT.SendData(
					$":lock: ({ev.Target.Id}) {ev.Target.Nickname} - {ev.Target.UserId} ({ev.Target.Role}) {Plugin.Translation.HasBeenHandcuffedBy} ({ev.Cuffer.Id})  {ev.Cuffer.Nickname} - `{ev.Cuffer.UserId}` ({ev.Cuffer.Role})",
						HandleQueue.GameLogChannelId);
		}

		public void OnPlayerBanned(BannedEventArgs ev)
        {
            if (ev.Details.Id.ToString().Contains("."))
                if (!Plugin.Singleton.Config.ShowIpAddresses)
                {
					ProcessSTT.SendData($":no_entry: {ev.Details.OriginalName} - `IP Hidden` {Plugin.Translation.WasBannedBy} {ev.Details.Issuer} {Plugin.Translation._For} {ev.Details.Reason}. {new DateTime(ev.Details.Expires)}", HandleQueue.CommandLogChannelId);
                }
                else
                {
					ProcessSTT.SendData($":no_entry: {ev.Details.OriginalName} - `{ev.Details.Id}` {Plugin.Translation.WasBannedBy} {ev.Details.Issuer} {Plugin.Translation._For} {ev.Details.Reason}. {new DateTime(ev.Details.Expires)}", HandleQueue.CommandLogChannelId);
                }
			else
            {
				ProcessSTT.SendData($":no_entry: {ev.Details.OriginalName} - `{ev.Details.Id}` {Plugin.Translation.WasBannedBy} {ev.Details.Issuer} {Plugin.Translation._For} {ev.Details.Reason}. {new DateTime(ev.Details.Expires)}", HandleQueue.CommandLogChannelId);
				ProcessSTT.SendData($":no_entry: Nadano Now� Blokad�. \n**Gracz:** `{ ev.Details.OriginalName}` // || `{ev.Details.Id}` || \n**Czas:** `{ new DateTime(ev.Details.Expires)}` \n**Pow�d:** `{ ev.Details.Reason}` \n**Administrator:** { ev.Details.Issuer}", HandleQueue.PunishmentsLogChannelId);
			}
		}

        //public void OnBanning (BanningEventArgs ev)
        //{
        //	if (ev.Target.Id.ToString().Contains(".")) return;

        //	else
        //          {
        //		ProcessSTT.SendData($":no_entry: OnBanningEv - Nadano Now� Blokad�. \n**Gracz:** `{ev.Target.Nickname}` // || `{ev.Target.UserId}` || \n**Czas:** `{TimeFormatter.TimeFormatter(ev.Duration)}` \n**Pow�d:** `{ev.Reason}` \n**Administrator:** {ev.Issuer.Nickname}", HandleQueue.PunishmentsLogChannelId);
        //	}
        //}

        public void OnPlayerKicked(KickedEventArgs ev)
        {
            ProcessSTT.SendData($":no_entry: Player Kicked \nNick: {ev.Target.Nickname}", HandleQueue.PunishmentsLogChannelId);
        }

        public void OnIntercomSpeak(IntercomSpeakingEventArgs ev)
		{
			if (Plugin.Singleton.Config.Intercom)
				ProcessSTT.SendData($":loud_sound: ({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasStartedUsingTheIntercom}.", HandleQueue.GameLogChannelId);
		}

		public void OnPickupItem(PickingUpItemEventArgs ev)
		{
			if (Plugin.Singleton.Config.PickupItem)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasPickedUp} {ev.Pickup.ItemId}.", HandleQueue.GameLogChannelId);
		}

		public void OnDropItem(ItemDroppedEventArgs ev)
		{
			if (Plugin.Singleton.Config.DropItem)
				ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role}) {Plugin.Translation.HasDropped} {ev.Pickup.ItemId}.", HandleQueue.GameLogChannelId);
		}

		public void OnSetGroup(ChangingGroupEventArgs ev)
		{
			try
			{
				if (Plugin.Singleton.Config.SetGroup)
				{
					if (ev.NewGroup == null)
					{
						string roleMessage = "None";
						ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GroupSet}: **{roleMessage}**.",
							HandleQueue.GameLogChannelId);
					}
					else
					{
						string roleMessage = $"{ev.NewGroup.BadgeText} ({ev.NewGroup.BadgeColor})";
						ProcessSTT.SendData($"({ev.Player.Id}) {ev.Player.Nickname} - {ev.Player.UserId} {Plugin.Translation.GroupSet}: **{roleMessage}**.",
							HandleQueue.GameLogChannelId);
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
    }
}
