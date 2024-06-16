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
 
namespace TrueOverhaul.Items.Souls
{
    public class DesertS : ModItem
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
            player.lifeRegen += 2;
            player.moveSpeed += 0.2f;
			player.statLifeMax2 += 10;
			player.GetCritChance(DamageClass.Generic) += 3f;
			player.GetDamage(DamageClass.Generic) += 0.3f;
            int index = player.FindBuffIndex(194);
            if (index >= 0)
		    {
		        player.DelBuff(index);
            }
        }
    }
}
