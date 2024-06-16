using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TrueOverhaul;

namespace TrueOverhaul.Items.AntiSummon
{
  public class PWC : ModItem
  {
    public override void SetStaticDefaults()
    {
      this.Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
      ((Entity) this.Item).width = 32;
      ((Entity) this.Item).height = 34;
      this.Item.value = 15000;
      this.Item.rare = 1;
    }

    public override void UpdateInventory(Player player)
    {
      if (!this.Item.favorited)
        return;
      player.GetModPlayer<TrueOverhaulPlayer>().noStupidNaturalERSpawns = true;
    }

    public override void AddRecipes()
    {
      if (TrueOverhaul.modConfiguration.Relocating)
      {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.LunarBar, 5);
        recipe.AddIngredient(ItemID.EaterOfWorldsPetItem, 1);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
      }
    }	
  }
}
