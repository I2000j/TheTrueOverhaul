using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace TrueOverhaul.Items.Placeables
{
	public class RTable : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 80;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 1000;
			Item.createTile = ModContent.TileType<Tiles.RTable>();
		}

		public override void AddRecipes()
        {
			if (TrueOverhaul.modConfiguration.RecSystem)
			{
           		Recipe recipe = CreateRecipe();
           		recipe.AddIngredient(ItemID.IronBar,8);
           		recipe.AddIngredient(ItemID.Wood,15);
           		recipe.AddIngredient(ItemID.IronAnvil,1);
		   		recipe.AddIngredient(ItemID.BlacksmithRack,1);
           		recipe.AddTile(TileID.Anvils);
           		recipe.Register();

           		Recipe recipe_alt = CreateRecipe();
           		recipe_alt.AddIngredient(ItemID.LeadBar,8);
           		recipe_alt.AddIngredient(ItemID.Wood,15);
           		recipe_alt.AddIngredient(ItemID.LeadAnvil,1);
		   		recipe_alt.AddIngredient(ItemID.BlacksmithRack,1);
           		recipe_alt.AddTile(TileID.Anvils);
           		recipe_alt.Register();
			}
        }	
	}
}