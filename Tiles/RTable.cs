using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace TrueOverhaul.Tiles
{
  public class RTable : ModTile
  {
    public override void SetStaticDefaults()
    {
      Main.tileFrameImportant[Type] = true;
			Main.tileSolidTop[Type] = false;
			Main.tileNoAttach[Type] = true;
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.addTile(Type);
			AddMapEntry(new Color(190, 230, 190));
      TileID.Sets.DisableSmartCursor[Type] = true;
      Main.tileLavaDeath[Type] = true;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j) ,i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeables.RTable>());
		}
  }
}
