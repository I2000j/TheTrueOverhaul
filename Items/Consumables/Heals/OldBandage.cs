using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TrueOverhaul.Items.Consumables.Heals
{
	public class OldBandage : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 30;
        }    
		
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 0;
			Item.rare = 0;
			Item.healLife = 25;
			Item.consumable = true;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 2;
			Item.useTime = 17;
		}

		public override bool CanUseItem(Player player)
		{
			return !player.HasBuff(ModContent.BuffType<Buffs.Bandaged>()) && !player.HasBuff(BuffID.Bleeding);
		}

		public override bool? UseItem(Player player)
		{
		 	player.AddBuff(ModContent.BuffType<Buffs.Bandaged>(), 1500);
			return true;
		}
	}
}
