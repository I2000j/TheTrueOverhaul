using TrueOverhaul.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Terraria.Chat;

namespace TrueOverhaul.Items.Summons.Invasion
{
  public class InfectedSpore : ModItem
  {
    public override void SetStaticDefaults()
    {
      this.Item.ResearchUnlockCount = 3;
      ItemID.Sets.SortingPriorityBossSpawns[this.Type] = 3;
    }

    public override void SetDefaults()
    {
      ((Entity) this.Item).width = 28;
      ((Entity) this.Item).height = 18;
      this.Item.maxStack = 1;
      this.Item.rare = 2;
      this.Item.useAnimation = 10;
      this.Item.useTime = 10;
      this.Item.useStyle = 4;
      this.Item.maxStack = 999;
      this.Item.consumable = true;
    }

    public override bool CanUseItem(Player player) => !TrueOverhaulWorld.EatersRelocateUp && TrueOverhaul.modConfiguration.Relocating;

    public override bool? UseItem(Player player)
    {
      TrueOverhaulNetcode.SyncWorld();
      ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.EatersRelocateSummoned")), new Color(175, 75, 255));
      EatersRelocate.StartEatersRelocate();
      return new bool?(true);
    }

    public override void AddRecipes()
    {
      if (TrueOverhaul.modConfiguration.Relocating)
      {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.ShadowScale, 15);
        recipe.AddTile(TileID.DemonAltar);
        recipe.Register();
      }
    }	
  }
}
