using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System;
using UncomplicatedCustomRoles.Extensions;
using UncomplicatedCustomRoles.Interfaces;

namespace UCRNicknamesExtension
{
    internal class Handler
    {
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player.Role == RoleTypeId.Spectator && ev.OldRole is not null && ev.OldRole.Type is not RoleTypeId.None && Plugin.Players.Contains(ev.Player.Id))
            {
                ev.Player.DisplayNickname = null;
                Plugin.Players.Remove(ev.Player.Id);
            }

            Timing.CallDelayed(1f, () =>
            {
                if (ev.Player.TryGetCustomRole(out ICustomRole Role))
                {
                    if (Plugin.Instance.Config.Nicknames.ContainsKey(Role.Id))
                    {
                        // Let's assign the nickname!
                        if (Plugin.Instance.Config.Nicknames[Role.Id].Contains(", "))
                        {
                            ev.Player.DisplayNickname = Plugin.Instance.Config.Nicknames[Role.Id].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).RandomItem().Replace("%nickname%", ev.Player.Nickname).Replace("%dnumber", new Random().Next(1000, 9999).ToString());
                        }
                        else
                        {
                            ev.Player.DisplayNickname = Plugin.Instance.Config.Nicknames[Role.Id].Replace("%nickname%", ev.Player.Nickname).Replace("%dnumber", new Random().Next(1000, 9999).ToString());
                        }

                        Plugin.Players.Add(ev.Player.Id);
                    }
                }
            });
        }

        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Player.Role == RoleTypeId.Spectator && Plugin.Players.Contains(ev.Player.Id))
            {
                ev.Player.DisplayNickname = null;
                Plugin.Players.Remove(ev.Player.Id);
            }
        }
    }
}
