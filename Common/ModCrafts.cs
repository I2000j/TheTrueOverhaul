using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueOverhaul.Common
{
	public class ModCrafts : ModSystem
	{
		public override void AddRecipes()
		{

			Recipe Souls1 = Recipe.Create(ItemID.SoulofFright);
			Souls1.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 1);
			Souls1.AddTile(TileID.LunarCraftingStation);
			Souls1.Register();

			Recipe Souls2 = Recipe.Create(ItemID.SoulofMight);
			Souls2.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 1);
			Souls2.AddTile(TileID.LunarCraftingStation);
			Souls2.Register();

			Recipe Souls3 = Recipe.Create(ItemID.SoulofSight);
			Souls3.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 1);
			Souls3.AddTile(TileID.LunarCraftingStation);
			Souls3.Register();

			Recipe Fragment1 = Recipe.Create(ItemID.FragmentVortex,2);
			Fragment1.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
			Fragment1.AddTile(TileID.LunarCraftingStation);
			Fragment1.Register();

			Recipe Fragment2 = Recipe.Create(ItemID.FragmentNebula,2);
			Fragment2.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
			Fragment2.AddTile(TileID.LunarCraftingStation);
			Fragment2.Register();

			Recipe Fragment3 = Recipe.Create(ItemID.FragmentSolar,2);
			Fragment3.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
			Fragment3.AddTile(TileID.LunarCraftingStation);
			Fragment3.Register(); 

			Recipe Fragment4 = Recipe.Create(ItemID.FragmentStardust,2);
			Fragment4.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
			Fragment4.AddTile(TileID.LunarCraftingStation);
			Fragment4.Register();

			Recipe SoulofLight = Recipe.Create(ItemID.SoulofLight);
			SoulofLight.AddIngredient(ModContent.ItemType<Items.Materials.SoulOfBalance>(), 1);
			SoulofLight.AddTile(TileID.DemonAltar);
			SoulofLight.Register();

			Recipe SoulofNight = Recipe.Create(ItemID.SoulofNight);
			SoulofNight.AddIngredient(ModContent.ItemType<Items.Materials.SoulOfBalance>(), 1);
			SoulofNight.AddTile(TileID.DemonAltar);
			SoulofNight.Register();

		}
	}
}