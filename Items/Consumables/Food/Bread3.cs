using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TrueOverhaul.Items.Consumables.Food
{
	public class Bread3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			this.Item.ResearchUnlockCount = 30;
        }    
		
		public override void SetDefaults()
		{
			Item.width = 33;
			Item.height = 30;
			Item.maxStack = 999;
			Item.healLife = 25;
			Item.value = 0;
			Item.rare = ItemRarityID.Expert;
			Item.value = 0;
			Item.noUseGraphic = false;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useTime = Item.useAnimation = 20;
			Item.noMelee = true;
			Item.consumable = true;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item2;
			Item.buffTime = 5 * 60 * 60;
			Item.buffType = BuffID.WellFed;
		}

		public override bool? UseItem(Player player)
		{
			player.AddBuff(BuffID.Honey, 1800);
			return true;
		}
	}
}
