using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace TrueOverhaul.Buffs
{
  public class Depressed : ModBuff
  {
    public override void SetStaticDefaults()
    {
      Main.debuff[this.Type] = true;
      Main.buffNoTimeDisplay[this.Type] = true;
      BuffID.Sets.NurseCannotRemoveDebuff[this.Type] = true;
    }


    public override void Update(Player player, ref int index) => player.maxRunSpeed *= 0.8f;
  }
}
