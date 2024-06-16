using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Chat;

namespace TrueOverhaul.Items.Lore.SPhone 
{
	public class ScoutPhoneOn : ModItem 
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.WorksInVoidBag[Type] = true;
			ItemID.Sets.CanBeQuickusedOnGamepad[Type] = true;	
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ModContent.ItemType<ScoutPhoneDummy>());
		}

		public override bool ConsumeItem(Player player) {
			return false;
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
				Item.SetDefaults(ModContent.ItemType<ScoutPhoneOff>());
				Item.favorited = originalFavorited;
			}
			else
			{
				switch (Main.rand.Next(4))
            	{
            	    case 0:
            	        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.PinkP1")), new Color(255, 255, 255));
						break;
            	    case 1:
            	        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.PinkP2")), new Color(255, 255, 255));
						break;
            	    case 2:
            	        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.PinkP3")), new Color(255, 255, 255));
						break;
            	    default:
            	        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.PinkP4")), new Color(255, 255, 255));
						break;
            	}
			}
			return true;
		}

		public override void UpdateInventory(Player player) 
		{
			player.accWatch = 1;
		}
	}
}