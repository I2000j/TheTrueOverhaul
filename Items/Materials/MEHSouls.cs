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
	public class MEHSouls : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 100;

			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(9, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;

			ItemID.Sets.ItemIconPulse[Item.type] = true; 
			ItemID.Sets.ItemNoGravity[Item.type] = true; 
        }    
		
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 40;
			Item.maxStack = 999;
			Item.value = 25000;
			Item.rare = 5;
		}

		public override void AddRecipes()
		{
			if (TrueOverhaul.modConfiguration.RecSystem || TrueOverhaul.modConfiguration.QoL)
			{
				Recipe recipe = CreateRecipe(1);
				recipe.AddIngredient(ItemID.SoulofFright, 1);
				recipe.AddIngredient(ItemID.SoulofMight, 1);
				recipe.AddIngredient(ItemID.SoulofSight, 1);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
		}
	}
}
