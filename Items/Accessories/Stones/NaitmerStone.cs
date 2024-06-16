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
	public class NaitmerStone : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Expert;
			//Item.accessory = true;
			// Ниже делают из акса юзалку
			Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false;
            Item.noMelee = true;
			//Item.UseSound = SoundID.Item44;
			Item.makeNPC = (short)ModContent.NPCType<NPCs.Critters.SpiderCritterNPC>();
		}

		// public override void UpdateAccessory(Player player, bool hideVisual) {
			
		// }

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!Collision.SolidCollision(vector2, player.width, player.height));
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer) {

				int type = ModContent.NPCType<NPCs.Critters.SpiderCritterNPC>();

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
			}
			return true;
		}

		public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddCondition(new Condition("Mods.TrueOverhaul.Conditions.NaitmerName", () => Main.player[Main.myPlayer].name == "Naitmer"));
            recipe.Register();
        }	
		
	}
}