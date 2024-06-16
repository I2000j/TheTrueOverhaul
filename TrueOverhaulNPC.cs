using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TrueOverhaul.Events;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameContent.ItemDropRules;

namespace TrueOverhaul
{
    public class TrueOverhaulNPC : GlobalNPC
    {
		
		public override void SetDefaults(NPC npc)
    	{
    	    if(npc.type == ModContent.NPCType<NPCs.TownNPC.GirlScout>())
    	    { 
				if (TrueOverhaulWorld.ScoutCrystal)
            	{
					npc.life = npc.lifeMax = 400;
					npc.life = 400;
            	}
            	if (TrueOverhaulWorld.ScoutFruit)
            	{
					npc.life = npc.lifeMax = 500;
					npc.life = 500;
            	}
				npc.life = npc.lifeMax = 100;
			}
    	}


        public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
			if(TrueOverhaulWorld.EatersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				//Clear pool so that only the stuff you want spawns
				pool.Clear();
				if(NPC.downedPlantBoss)
				{
					//key = NPC ID | value = spawn weight
					//pool.add(key, value)
					if(Main.rand.Next(5) > 0)
					{
						foreach(int i in EatersRelocate.HardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
					else
					{
						foreach(int i in EatersRelocate.PreHardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
				}
				else
				{
					foreach(int i in EatersRelocate.PreHardmodeInvaders)
					{
						pool.Add(i, 1f);
					}
				}
			}

			if(TrueOverhaulWorld.MonstersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				//Clear pool so that only the stuff you want spawns
				pool.Clear();
				if(NPC.downedPlantBoss)
				{
					//key = NPC ID | value = spawn weight
					//pool.add(key, value)
					if(Main.rand.Next(5) > 0)
					{
						foreach(int i in MonstersRelocate.HardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
					else
					{
						foreach(int i in MonstersRelocate.PreHardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
				}
				else
				{
					foreach(int i in MonstersRelocate.PreHardmodeInvaders)
					{
						pool.Add(i, 1f);
					}
				}
			}
		}
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			//Change spawn stuff if invasion up and invasion at spawn
			if(TrueOverhaulWorld.EatersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				spawnRate = 50;
				maxSpawns = 100;
			}

			if(TrueOverhaulWorld.MonstersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				spawnRate = 50;
				maxSpawns = 100;
			}
		}
		
		public override void PostAI(NPC npc)
		{
			if(npc.type == ModContent.NPCType<NPCs.TownNPC.GirlScout>())
    	    { 
				if (TrueOverhaulWorld.ScoutCrystal)
            	{
					npc.lifeMax = 400;
            	}
            	if (TrueOverhaulWorld.ScoutFruit)
            	{
					npc.lifeMax = 500;
            	}
			}
			//Changes NPCs so they do not despawn when invasion up and invasion at spawn
			if(TrueOverhaulWorld.EatersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				npc.timeLeft = 1000;
			}
			if(TrueOverhaulWorld.MonstersRelocateUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				npc.timeLeft = 1000;
			}
		}
		
		public override void OnKill(NPC npc)
		{
			//When an NPC (from the invasion list) dies, add progress by decreasing size
			if(TrueOverhaulWorld.EatersRelocateUp)
			{
				int[] FullList = EatersRelocate.GetFullInvaderList();
				foreach(int invader in FullList)
				{
					if(npc.type == invader)
					{
						Main.invasionSize -= 1;
					}
				}
			}

			if(TrueOverhaulWorld.MonstersRelocateUp)
			{
				int[] FullList = MonstersRelocate.GetFullInvaderList();
				foreach(int invader in FullList)
				{
					if(npc.type == invader)
					{
						Main.invasionSize -= 1;
					}
				}
			}
		}

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npc, npcLoot);
		}

    }
}