using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
// Ниже делают из акса юзалку
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace TrueOverhaul.Items.Accessories.Stones
{
	public class BioshStone : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Expert;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (Main.dayTime && Main.time == 0) {
				var source = player.GetSource_FromAI();;
				var random = Main.rand.Next(1,5);
				if (random == 1) {
					player.QuickSpawnItem(source, ModContent.ItemType<Items.Consumables.Food.Bread>());
				}
				if (random == 2) {
					player.QuickSpawnItem(source, ModContent.ItemType<Items.Consumables.Food.Bread2>());
				}
				if (random == 3) {
					player.QuickSpawnItem(source, ModContent.ItemType<Items.Consumables.Food.Bread3>());
				}
				if (random == 4) {
					player.QuickSpawnItem(source, ModContent.ItemType<Items.Consumables.Food.Bread4>());
				}
			}	
		}

		public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddCondition(new Condition("Mods.TrueOverhaul.Conditions.BioshName", () => Main.player[Main.myPlayer].name == "Biosh"));
            recipe.Register();
        }	
	}
}