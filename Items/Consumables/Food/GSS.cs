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
 
namespace TrueOverhaul.Items.Consumables.Food
{
    public class GSS : ModItem
    {
        public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 30;
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 999;
			Item.value = 0;
			Item.rare = 1;
            Item.consumable = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.GetModPlayer<TeleportSystem>().DoHomeTeleport();
			player.AddBuff(BuffID.PotionSickness, 1800);
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(BuffID.PotionSickness) == false);
		}
    }
}
