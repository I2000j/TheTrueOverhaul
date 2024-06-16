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
using TrueOverhaul;
 
namespace TrueOverhaul.Items.Consumables.Researches
{
    public class TheCrimson : ModItem
    {
        public override void SetStaticDefaults()
		{
            this.Item.ResearchUnlockCount = 30;
        }    

		public override void SetDefaults()
        {
            Item.maxStack = 15;
			Item.value = 0;
			Item.rare = -11;
			Item.useStyle = 4;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
            Item.noMelee = true;
        }

		public override bool CanUseItem(Player player)
		{
			TrueOverhaul overhaul = new TrueOverhaul();
			return overhaul.CheckActive();
		}
		
		public override bool? UseItem(Player player)
		{
			TrueOverhaulWorld.research = true;
			//TrueOverhaulWorld.crimsonR = true;
			//TrueOverhaulWorld.crimson = true;
			return true;
		}
    }
}
