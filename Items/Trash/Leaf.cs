using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using TrueOverhaul.Common;
using Terraria.GameContent.Creative;
 
namespace TrueOverhaul.Items.Trash
{
    public class Leaf : ModItem
    {
        public override void SetStaticDefaults()
		{
            this.Item.ResearchUnlockCount = 30;
        }   

		public override void SetDefaults()
        {
            Item.maxStack = 999;
			Item.value = 0;
			Item.rare = -1;
        }
    }
}
