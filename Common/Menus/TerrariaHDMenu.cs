using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria;
using System;
using Terraria;
using Terraria.DataStructures;

namespace TrueOverhaul.Common.Menus
{
  public class TerrariaHDMenu : ModMenu
  {
    public override string DisplayName => "Terraria HD";

    public override int Music => 60;

    public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("TrueOverhaul/Assets/Textures/Menu/LogoTerrariaHD", (AssetRequestMode) 2);

    public override bool PreDrawLogo(
      SpriteBatch spriteBatch,
      ref Vector2 logoDrawCenter,
      ref float logoRotation,
      ref float logoScale,
      ref Color drawColor)
    {
      logoDrawCenter = logoDrawCenter + new Vector2(0.0f, 14f);
      logoScale *= 0.95f;
      return true;
    }

    
  }
}
