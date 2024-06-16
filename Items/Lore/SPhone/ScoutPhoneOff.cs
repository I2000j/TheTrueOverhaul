using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Chat;

namespace TrueOverhaul.Items.Lore.SPhone 
{
	public class ScoutPhoneOff : ModItem 
	{
		public override void SetStaticDefaults() 
		{
			ItemID.Sets.CanBeQuickusedOnGamepad[Type] = true;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ModContent.ItemType<ScoutPhoneDummy>());
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool? UseItem(Player player) 
		{
			if (player.altFunctionUse == 2)
			{	
				bool originalFavorited = Item.favorited;
				Item.SetDefaults(ModContent.ItemType<ScoutPhoneOn>());
				Item.favorited = originalFavorited;
			}
			else
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.ScoutPhoneInspect")), new Color(255,255,255));
			}
			return true;
			
		}
	}
}