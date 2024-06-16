﻿using System;
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
 
namespace TrueOverhaul.Items.Souls
{
    public class SnowS : ModItem
    {
        public override void SetStaticDefaults()
		{
            ItemID.Sets.ItemNoGravity[this.Type] = true;
            this.Item.ResearchUnlockCount = 1;
        }   

		public override void SetDefaults()
        {
            Item.maxStack = 1;
			Item.value = 1000000;
			Item.rare = -12;
            Item.accessory = true;
            Item.defense = 8;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen -= 1;
            player.moveSpeed -= 0.2f;
			player.statLifeMax2 += 75;
            int index = player.FindBuffIndex(46);
            if (index >= 0)
		    {
		        player.DelBuff(index);
            }
        }
    }
}
