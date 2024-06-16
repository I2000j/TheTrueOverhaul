using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TrueOverhaul.Items.Lore.SPhone
{
	public class RemadedPhoneDummy : ModItem 
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.WorksInVoidBag[Type] = true;
			ItemID.Sets.CanBeQuickusedOnGamepad[Type] = true;

			this.Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() {
			//Item.width = 28;
			//Item.height = 32;
			Item.value = 0;
			Item.rare = 1;
			Item.useStyle = 4;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false;
		}
		public override void UpdateInventory(Player player) 
		{
			bool originalFavorited = Item.favorited;
			Item.SetDefaults(ModContent.ItemType<RemadedPhone0>());
			Item.favorited = originalFavorited;
		}
	}
}