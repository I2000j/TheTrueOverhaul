using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.Chat;

namespace TrueOverhaul.Events
{
    public class MonstersRelocate
    {
        public static int[] PreHardmodeInvaders = {
            NPCID.FaceMonster,
            NPCID.Crimera
            //mod.NPCType("ModNPCName")
        };
		
		public static int[] HardmodeInvaders = {
			NPCID.FaceMonster,
			NPCID.Crimera,
			NPCID.Herpling,
			NPCID.Crimslime,
			NPCID.BloodMummy,
			NPCID.BloodJelly
		};
		
        public static int[] GetFullInvaderList()
		{
			//Creating a list
			int[] list = new int[PreHardmodeInvaders.Length + HardmodeInvaders.Length];
			
			//CopyTo(var arrayToCopyTo, index)
			PreHardmodeInvaders.CopyTo(list, 0);
			HardmodeInvaders.CopyTo(list, PreHardmodeInvaders.Length);
			
			return list;
		}
		
		//Setup for an Invasion After setting up
		public static void StartMonstersRelocate()
		{
			//Set to no invasion
			if (Main.invasionType != 0 && Main.invasionSize == 0)
			{
				Main.invasionType = 0;
			}
			if (Main.invasionType == 0)
			{
				//Checks amount of players
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && TrueOverhaul.modConfiguration.Relocating && TrueOverhaulWorld.EatersRelocateUp == false && TrueOverhaulWorld.MonstersRelocateUp == false)
					{
						num++;
					}
				}
				if (num > 0)
				{
					//Invasion setup
					Main.invasionType = -1;
					TrueOverhaulWorld.MonstersRelocateUp = true;
					Main.invasionSize = 100 * num;
					Main.invasionSizeStart = Main.invasionSize;
					Main.invasionProgress = 0;
					Main.invasionProgressIcon = 0 + 3;
					Main.invasionProgressWave = 0;
					Main.invasionProgressMax = Main.invasionSizeStart;
					Main.invasionWarn = 360;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}

		//Text for Dungeons and syncing messages
		public static void MonstersRelocateWarning()
		{
			String text = "";
			if (Main.invasionX == (double)Main.spawnTileX)
			{
				text = Language.GetTextValue("Mods.TrueOverhaul.MonstersRelocateStart");
			}
			if(Main.invasionSize <= 0)
			{
				text = Language.GetTextValue("Mods.TrueOverhaul.MonstersRelocateEnd");
			}
			if (Main.netMode == 0)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
				return;
			}
			if (Main.netMode == 2)
			{
				//Sync with net
				NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
			}
		}
		
		public static void UpdateMonstersRelocate()
		{
			if(TrueOverhaulWorld.MonstersRelocateUp)
			{
				//End invasion if size less or equal to 0
				if(Main.invasionSize <= 0)
				{
					TrueOverhaulWorld.MonstersRelocateUp = false;
					MonstersRelocateWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 0;
				}
				
				//Do not do the rest if invasion already at spawn
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				
				//Update when the invasion gets to Spawn
				float num = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						MonstersRelocateWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							MonstersRelocateWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
				}
			}
		}
		
		public static void CheckMonstersRelocateProgress()
		{
			//Get full list of invaders
			int[] FullList = GetFullInvaderList();
			
			//Not really sure what this is
			if (Main.invasionProgressMode != 2)
			{
				Main.invasionProgressNearInvasion = false;
				return;
			}
			bool flag = false;
			Player player = Main.player[Main.myPlayer];
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			int num = 5000;
			int icon = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					icon = 0;
					int type = Main.npc[i].type;
					for(int n = 0; n < FullList.Length; n++)
					{
						if(type == FullList[n])
						{
							Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
							if (rectangle.Intersects(value))
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			Main.invasionProgressNearInvasion = flag;
			int progressMax3 = 1;
			if (TrueOverhaulWorld.MonstersRelocateUp)
			{
				progressMax3 = Main.invasionSizeStart;
			}
			if(TrueOverhaulWorld.MonstersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				//Shows the UI for the invasion
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
			}
			
			//Syncing start of invasion
			foreach(Player p in Main.player)
			{
				NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
			}
		}
    }
}
