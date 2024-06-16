using Terraria.ModLoader;
using Terraria.Localization;
using TrueOverhaul.Events;

namespace TrueOverhaul
{
	public class TrueOverhaul : Mod
	{

        internal static ModConfiguration modConfiguration;


        public override void Unload()
        {
            modConfiguration = null;
        }

        public bool CheckActive()
        {
            if (TrueOverhaulWorld.forestR || TrueOverhaulWorld.desertR || TrueOverhaulWorld.snowR || TrueOverhaulWorld.research)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

	}
}