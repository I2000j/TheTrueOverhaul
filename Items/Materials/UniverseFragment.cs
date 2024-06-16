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
	public class UniverseFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 100;

			ItemID.Sets.ItemIconPulse[Item.type] = true; 
			ItemID.Sets.ItemNoGravity[Item.type] = true; 
        }    
		
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 50000;
			Item.rare = 9;
		}
		
		public override void AddRecipes()
		{
			if (TrueOverhaul.modConfiguration.RecSystem || TrueOverhaul.modConfiguration.QoL)
			{
				Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.FragmentSolar, 1);
				recipe.AddIngredient(ItemID.FragmentNebula, 1);
				recipe.AddIngredient(ItemID.FragmentVortex, 1);
				recipe.AddIngredient(ItemID.FragmentStardust, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
		}
	}
}
