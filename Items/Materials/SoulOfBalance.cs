using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TrueOverhaul.Items.Materials
{
	public class SoulOfBalance : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 100;

			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;

			ItemID.Sets.ItemIconPulse[Item.type] = true; 
			ItemID.Sets.ItemNoGravity[Item.type] = true; 
        }    
		
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 2500;
			Item.rare = 4;
		}
		
		public override void AddRecipes()
		{
			if (TrueOverhaul.modConfiguration.QoL)
			{
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.SoulofLight, 1);
				recipe.AddIngredient(ItemID.SoulofNight, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.Register();
			}
		}
	}
}
