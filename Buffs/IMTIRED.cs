using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace TrueOverhaul.Buffs
{
  public class IMTIRED : ModBuff
  {
    public override void SetStaticDefaults()
    {
      Main.debuff[this.Type] = true;
      Main.buffNoTimeDisplay[this.Type] = true;
      BuffID.Sets.NurseCannotRemoveDebuff[this.Type] = true;
    }
  }
}
