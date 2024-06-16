using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueOverhaul.Common
{
	public class QoLCrafts : ModSystem
	{
		public override void AddRecipes()
		{
			if (TrueOverhaul.modConfiguration.QoL)
			{
				Recipe Drax = Recipe.Create(ItemID.Drax);
				Drax.AddIngredient(ItemID.HallowedBar, 18);
				Drax.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 1);
				Drax.AddTile(TileID.MythrilAnvil);
				Drax.Register();

				Recipe PickaxeAxe = Recipe.Create(ItemID.PickaxeAxe);
				PickaxeAxe.AddIngredient(ItemID.HallowedBar, 18);
				PickaxeAxe.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 1);
				PickaxeAxe.AddTile(TileID.MythrilAnvil);
				PickaxeAxe.Register();

				Recipe TrueNightsEdge = Recipe.Create(ItemID.TrueNightsEdge);
				TrueNightsEdge.AddIngredient(ItemID.NightsEdge, 1);
				TrueNightsEdge.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 20);
				TrueNightsEdge.AddTile(TileID.MythrilAnvil);
				TrueNightsEdge.Register();

				Recipe AvengerEmblem1 = Recipe.Create(ItemID.AvengerEmblem);
				AvengerEmblem1.AddIngredient(ItemID.RangerEmblem, 1);
				AvengerEmblem1.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 5);
				AvengerEmblem1.AddTile(TileID.TinkerersWorkbench);
				AvengerEmblem1.Register();

				Recipe AvengerEmblem2 = Recipe.Create(ItemID.AvengerEmblem);
				AvengerEmblem2.AddIngredient(ItemID.SorcererEmblem, 1);
				AvengerEmblem2.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 5);
				AvengerEmblem2.AddTile(TileID.TinkerersWorkbench);
				AvengerEmblem2.Register();

				Recipe AvengerEmblem3 = Recipe.Create(ItemID.AvengerEmblem);
				AvengerEmblem3.AddIngredient(ItemID.SummonerEmblem, 1);
				AvengerEmblem3.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 5);
				AvengerEmblem3.AddTile(TileID.TinkerersWorkbench);
				AvengerEmblem3.Register();

				Recipe AvengerEmblem4 = Recipe.Create(ItemID.AvengerEmblem);
				AvengerEmblem4.AddIngredient(ItemID.WarriorEmblem, 1);
				AvengerEmblem4.AddIngredient(ModContent.ItemType<Items.Materials.MEHSouls>(), 5);
				AvengerEmblem4.AddTile(TileID.TinkerersWorkbench);
				AvengerEmblem4.Register();

				Recipe CelestialSigil = Recipe.Create(ItemID.CelestialSigil);
				CelestialSigil.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 12);
				CelestialSigil.AddTile(TileID.LunarCraftingStation);
				CelestialSigil.Register();

				Recipe SuperHealingPotion = Recipe.Create(ItemID.SuperHealingPotion, 4);
				SuperHealingPotion.AddIngredient(ItemID.GreaterHealingPotion, 4);
				SuperHealingPotion.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
				SuperHealingPotion.AddTile(TileID.Bottles);
				SuperHealingPotion.Register();

				Recipe SuperHealingPotion2 = Recipe.Create(ItemID.SuperHealingPotion, 4);
				SuperHealingPotion2.AddIngredient(ItemID.GreaterHealingPotion, 4);
				SuperHealingPotion2.AddIngredient(ModContent.ItemType<Items.Materials.UniverseFragment>(), 1);
				SuperHealingPotion2.AddTile(TileID.AlchemyTable);
				SuperHealingPotion2.Register();
			}
		}
	}
}