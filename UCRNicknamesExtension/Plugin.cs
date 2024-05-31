using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;

namespace UCRNicknamesExtension
{
    internal class Plugin : Plugin<Config>
    {
        public override string Name => "UCRNicknamesExtension";

        public override string Prefix => "UCRNE";

        public override string Author => "FoxWorn3365";

        public override Version Version => new(1, 0, 0);

        public override Version RequiredExiledVersion => new(8, 8, 1);

        public override PluginPriority Priority => PluginPriority.Lower;

        internal static Plugin Instance;

        internal Handler Handler;

        internal static List<int> Players;

        public override void OnEnabled()
        {
            Instance = this;

            Handler = new();
            Players = new();

            Exiled.Events.Handlers.Player.Spawned += Handler.OnSpawned;
            Exiled.Events.Handlers.Player.Died += Handler.OnDied;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Spawned += Handler.OnSpawned;
            Exiled.Events.Handlers.Player.Died += Handler.OnDied;

            Handler = null;

            Instance = null;
            base.OnDisabled();
        }
    }
}
