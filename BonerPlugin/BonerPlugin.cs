using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using System.Threading.Tasks;

namespace BonerPlugin
{
    public class BonerPlugin : Plugin<Config>
    {
        public static BonerPlugin Instance { get; } = new BonerPlugin();
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public static System.Random rndgengoodname = new System.Random();
        public int plays = 0;
        public bool comoveride = false;
        public int counter = 29;
        public int classdnum = 0;
        public int scpfind = 0;
        public int IDnum = 0;
        public int tempi = 0;
        public int tempi2EB = 0;
        public int computerfind = 0;
        public void CheckClassD()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.ClassD)
                {
                    tempi++;
                }
            }
            classdnum = rndgengoodname.Next(1, tempi);
            FindPlayerID();
        }
        public void FindPlayerID()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (tempi2EB < classdnum)
                {

                    if (_player.Role == RoleTypeId.ClassD)
                    {
                        tempi2EB++;
                        if (tempi2EB == classdnum)
                        {
                            IDnum = _player.Id;
                        }
                    }
                }
            }
        }
        public void CheckForSCP()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Scp3114)
                {
                    scpfind = 1;
                }
            }
            ComputerLookFor();
        }
        public void FinalRun3114()
        {
            if (plays > counter)
            {
                if (scpfind < 1)
                {
                    if (computerfind < 1)
                    {
                        foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
                        {
                            if (_player.Id == IDnum)
                            {
                                _player.Teleport(new UnityEngine.Vector3(0, 10, 0));
                                _player.Vaporize();
                                _player.Broadcast(10, "You Have Been Selected To Be 3114", Broadcast.BroadcastFlags.Normal);
                                Task.Delay(100);
                                _player.Role.Set(RoleTypeId.Scp3114);
                            }
                        }
                    }
                }
            }
        }
        public void VarReset3114()
        {
            plays = Exiled.API.Features.Server.PlayerCount;
            comoveride = BonerPlugin.Instance.Config.NoComputerOveride;
            counter = 29;
            classdnum = 0;
            scpfind = 0;
            IDnum = 0;
            tempi = 0;
            tempi2EB = 0;
            computerfind = 0;
        }
        public void Logging1()
        {
            Task.Delay(300);
        }
        public void ComputerLookFor()
        {
            foreach (Exiled.API.Features.Player _player in Exiled.API.Features.Player.List)
            {
                if (_player.Role == RoleTypeId.Scp079)
                {
                    computerfind = 1;
                }
            }
        }
        public void VarOverideCheck()
        {
            if (comoveride)
            {
                computerfind = 0;
            }
        }
        public void KronkPullTheLever()
        {
            Logging1();
            VarReset3114();
            CheckClassD();
            CheckForSCP();
            VarOverideCheck();
            FinalRun3114();
        }
        public override void OnEnabled() => Exiled.Events.Handlers.Server.RoundStarted += KronkPullTheLever;
        private BonerPlugin()
        {

        }
    }
}
