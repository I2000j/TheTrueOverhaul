using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TrueOverhaul.Items.Diff
{
	public class Martyr : ModItem 
	{
		public override void SetStaticDefaults() 
		{
			this.Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.width = 48;
			Item.height = 52;
			Item.value = 0;
			Item.rare = -11;
			Item.useStyle = 4;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
		}
		
	}
}