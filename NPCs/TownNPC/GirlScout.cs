using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System.Linq;
using Terraria.Chat;
using Terraria.Utilities;
using TrueOverhaul.Common;

namespace TrueOverhaul.NPCs.TownNPC
{
    [AutoloadHead]
    public class GirlScout : ModNPC
    {
        private static int ChatNumber;
        public static string BaseShop = "BaseShop";
        public static string ExploringShop = "ExploringShop";
        public static int IMTIRED = 0;
        public override string Texture
        {
            get
            {
                return "TrueOverhaul/NPCs/TownNPC/GirlScout";
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Guide, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate);
        }
		
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.TrueOverhaul.Bestiary.GirlScout")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 10;
            NPC.lifeMax = 100;
            if (TrueOverhaulWorld.ScoutCrystal)
    		{
            	NPC.life = NPC.lifeMax = 400;
				NPC.lifeMax = 400;
            }
            if (TrueOverhaulWorld.ScoutFruit)
            {
                NPC.life = NPC.lifeMax = 500;
			    NPC.lifeMax = 500;
            }	
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Angler;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (TrueOverhaul.modConfiguration.GirlScoutSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Elise = Language.GetTextValue("Mods.TrueOverhaul.Elise");
            string Lina = Language.GetTextValue("Mods.TrueOverhaul.Lina");
            string Xaranna = Language.GetTextValue("Mods.TrueOverhaul.Xaranna");
            string Lilith = Language.GetTextValue("Mods.TrueOverhaul.Lilith");
            string Conalin = Language.GetTextValue("Mods.TrueOverhaul.Conalin");
            string Sonda = Language.GetTextValue("Mods.TrueOverhaul.Sonda");
            string Evanaina = Language.GetTextValue("Mods.TrueOverhaul.Evanaina");

            return new List<string>() {
				Elise,
				Lina,
				Xaranna,
				Lilith,
                Conalin,
                Sonda,
                Evanaina
			};
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 10;
            }
            if (!NPC.downedMoonlord && Main.hardMode)
            {
                damage = 90;
            }
            if (NPC.downedMoonlord)
            {
                damage = 180;
            }
            knockback = 8f;

            if (TrueOverhaulWorld.ScoutCrystal)
            {
				NPC.lifeMax = 400;
            }
            if (TrueOverhaulWorld.ScoutFruit)
            {
				NPC.lifeMax = 500;
            }
			NPC.lifeMax = 100;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public int randProj(ref int projType)
        {

            if (NPC.downedMoonlord)
			{
                return projType = 503;
			} 
            else
            {
                if (NPC.downedGolemBoss)
                {
                    switch (Main.rand.Next(3))
                    {
                    case 0:
                        return projType = 182;
                    case 1:
                        return projType = 195;
                    default:
                        return projType = 267;
                    }
                } 
                else 
                {
                    if (NPC.downedPlantBoss)
                    {
                        switch (Main.rand.Next(3))
                        {
                        case 0:
                            return projType = 33;
                        case 1:
                            return projType = 93;
                        default:
                            return projType = 54;
                        }
                    } 
                    else 
                    {
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                        {
                            return projType = 54;
                        } 
                        else 
                        {
                            if (NPC.downedMechBossAny)
                            {
                                switch (Main.rand.Next(3))
                                {
                                case 0:
                                    return projType = 196;
                                case 1:
                                    return projType = 93;
                                default:
                                    return projType = 54;
                                }
                            } 
                            else 
                            {
                                if (Main.hardMode)
                                {
                                    switch (Main.rand.Next(3))
                                    {
                                    case 0:
                                        return projType = 196;
                                    case 1:
                                        return projType = 93;
                                    default:
                                        return projType = 21;
                                    }
                                }
                                else
                                {
                                    if (NPC.downedBoss3)
                                    {
                                        switch (Main.rand.Next(3))
                                        {
                                        case 0:
                                            return projType = 196;
                                        case 1:
                                            return projType = 183;
                                        default:
                                            return projType = 21;
                                        }
                                    }
                                    else
                                    {
                                        if (NPC.downedQueenBee)
                                        {
                                            switch (Main.rand.Next(3))
                                            {
                                            case 0:
                                                return projType = 196;
                                            case 1:
                                                return projType = 183;
                                            default:
                                                return projType = 6;
                                            }
                                        }
                                        else
                                        {
                                            if (NPC.downedBoss2)
                                            {
                                                switch (Main.rand.Next(3))
                                                {
                                                case 0:
                                                    return projType = 196;
                                                case 1:
                                                    return projType = 30;
                                                default:
                                                    return projType = 6;
                                                }
                                            }
                                            else
                                            {
                                                if (NPC.downedBoss1)
                                                {
                                                    switch (Main.rand.Next(4))
                                                    {
                                                    case 0:
                                                        return projType = 196;
                                                    case 1:
                                                        return projType = 48;
                                                    case 2:
                                                        return projType = 3;
                                                    default:
                                                        return projType = 6;
                                                    }
                                                }
                                                else
                                                {
                                                    if (NPC.downedSlimeKing)
                                                    {
                                                        switch (Main.rand.Next(3))
                                                        {
                                                        case 0:
                                                            return projType = 196;
                                                        case 1:
                                                            return projType = 48;
                                                        default:
                                                            return projType = 3;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return projType = 196;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            randProj(ref projType);
            
            attackDelay = 5;
            
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }


        public override string GetChat()
        {                                           //npc chat
            string Entry1 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry1");
            string Entry2 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry2");
            string Entry3 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry3");
            string Entry4 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry4");
            string Entry5 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry5");
            string Entry6 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry6");
            string Entry7 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry7");
            string Entry8 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry8");
            string Entry9 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry9");
            string Entry10 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry10");

            string LifeCrystal = Language.GetTextValue("Mods.TrueOverhaul.GSLifeCrystal");
            string LifeFruit = Language.GetTextValue("Mods.TrueOverhaul.GSLifeFruit");

            NPC.FindFirstNPC(ModContent.NPCType<GirlScout>());

            if (NPC.lifeMax == 100 && Main.hardMode && !TrueOverhaulWorld.ScoutCrystal)
            {
                NPC.lifeMax = 400;
                TrueOverhaulWorld.ScoutCrystal = true;
                return LifeCrystal;
            }
            if (NPC.lifeMax == 400 && NPC.downedPlantBoss && !TrueOverhaulWorld.ScoutFruit)
            {
                NPC.lifeMax = 500;
                TrueOverhaulWorld.ScoutFruit = true;
                return LifeFruit;
            }
            if (TrueOverhaul.modConfiguration.SSystem && TrueOverhaulWorld.season == 3 && Main.rand.Next(2) == 0)
            {
                return Entry3;
            }
            if (TrueOverhaul.modConfiguration.RecSystem && Main.rand.Next(6) == 0)
            {
                return Entry6;
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return Entry1;
                case 1:
                    return Entry2;
                case 2:
                    return Entry8;
                case 3:
                    return Entry4;
                case 4:
                    return Entry5;
                case 5:
                    return Entry8;
                case 6:
                    return Entry10;
                default:
                    return Entry7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Swap = Language.GetTextValue("Mods.TrueOverhaul.GSSwap");

            string Shop1 = Language.GetTextValue("Mods.TrueOverhaul.GSShop1");
            string Shop2 = Language.GetTextValue("Mods.TrueOverhaul.GSShop2");

            string Help1 = Language.GetTextValue("Mods.TrueOverhaul.GSHelp1");
            string Help2 = Language.GetTextValue("Mods.TrueOverhaul.GSHelp2");

            button2 = Swap;

            switch (ChatNumber)
            {
                case 0:
                    button = Shop1;
                    break;
                case 1:
                    button = Shop2;
                    break;
                case 2:
                    button = Help1;
                    break;
                case 3:
                    button = Help2;
                    break;
                case 4:
                    button = Shop1;
                    ChatNumber = 0;
                    break;
                default:
                    ChatNumber = 0;
                    break;
            }
        
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            //Bandages
            string Entry11 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry11");
            string Entry12 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry12");
            string Entry14 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry14");

            //Researches
            string Entry13 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry13");
            string Entry15 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry15");
            string Entry16 = Language.GetTextValue("Mods.TrueOverhaul.GSEntry16");

            string DIMTIRED = Language.GetTextValue("Mods.TrueOverhaul.GSIMTIRED");

            string Death1 = Language.GetTextValue("Mods.TrueOverhaul.BNDeath1");
            string Death2 = Language.GetTextValue("Mods.TrueOverhaul.BNDeath2");

            if (firstButton)
            {
                if (ChatNumber <= 1)
                {
                    if (ChatNumber == 0)
                    {
                        shopName = "BaseShop";
                    }
                    if (ChatNumber == 1)
                    {
                        shopName = "ExploringShop";
                    }
                }
                else
                {
                    if (ChatNumber == 2)
                    {
                        Player player = Main.player[Main.myPlayer];
                        if (IMTIRED < 6)
                        {
                            if (player.HasBuff(ModContent.BuffType<Buffs.Bandaged>()))
			                {
                                IMTIRED++;

                                int rebint = Main.rand.Next(30);
                                if (Main.hardMode)
                                {
                                    rebint = Main.rand.Next(15);
                                }
                                int index = player.FindBuffIndex(ModContent.BuffType<Buffs.Bandaged>());
                                if (rebint < 4)
                                {
                                    Main.npcChatText = Entry14;
                                    if (index >= 0)
			                        {
			                            player.DelBuff(index);
                                    }
                                }

                                if (rebint > 3 && rebint != 14)
                                {
                                    Main.npcChatText = Entry11;
                                    player.AddBuff(BuffID.PotionSickness, 600);
                                    player.AddBuff(BuffID.Bleeding, 600);
                                    if (index >= 0)
			                        {
			                            player.DelBuff(index);
                                    }
                                }

                                if (rebint == 14)
                                {
                                    if (index >= 0)
			                        {
			                            player.DelBuff(index);
                                    }
                                    player.KillMe(PlayerDeathReason.ByCustomReason(Death1.ToString() + player.name + Death2.ToString()), 9999.0, 0, false);
                                }
                                
                            }
                            else
                            {
                                Main.npcChatText = Entry12;
                            }
                        }
                        else
                        {
                            Main.npcChatText = DIMTIRED;
                        }
                    }
                    else
                    {
                        Main.npcChatText = Entry13;
                        if (TrueOverhaulWorld.research == false)
                        {
                            int unlucky = 0;
                            Player player = Main.player[Main.myPlayer];
					        var source = player.GetSource_FromAI();
                            if (TrueOverhaulWorld.forestR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.ForestS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (Main.halloween)
                                {
                                    player.QuickSpawnItem(source, 1725, Main.rand.Next(0,30));
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 4366);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 832);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 933);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 216);
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,35));
                                    player.QuickSpawnItem(source, 1110, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 63, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 1111, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.ForestS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,25));
                                    player.QuickSpawnItem(source, 1110, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 63, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 1111, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 1110, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 63, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 1111, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Leaf>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 40, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 5, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 313, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 9, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Leaf>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.desertR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.DesertS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0)
                                {
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,80));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,24));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.DesertS>());
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,25));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,7));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Spike>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 169, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 323, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 317, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 276, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Spike>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.snowR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.SnowS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0)
                                {
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,80));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,24));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.SnowS>());
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,25));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 216);
                                    }
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,7));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Fur>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 593, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 949, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 2358, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 2503, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Fur>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.jungleR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.JungleS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 251);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 3360);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 3361);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 5097);
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 1109, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 208, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.JungleS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 1109, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 208, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 1109, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.PoisonedCapsule>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 4564, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 314, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 620, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.PoisonedCapsule>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.oceanR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.OceanS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 4425);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 186);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 4404);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 277);
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 319, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 4287, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.OceanS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 277);
                                    }
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 319, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 4287, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 277);
                                    }
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 319, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 277);
                                    }
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.PieceOfShell>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 4090, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 275, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 2504, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.PieceOfShell>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.skyR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.SkyS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 65);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 4978);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 158);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 159);
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 4016, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.SkyS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 4016, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 4016, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 5097);
                                    }
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.CloudPiece>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 824, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 320, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 751, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.CloudPiece>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.undergroundR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.UndergroundS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 54);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 975);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 49);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 997);
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 1108, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.UndergroundS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 997);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 1108, Main.rand.Next(0,4));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,18));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 997);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 1108, Main.rand.Next(0,2));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,200));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 997);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,150));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,6));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 282, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }
                            if (TrueOverhaulWorld.cavernsR)
                            {
                                unlucky = Main.rand.Next(0,50);
                                if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.CavernsS>()))
                                {
                                    if (!TrueOverhaulWorld.rLuckCrash)
                                    {
                                        unlucky -= 10;
                                    }
                                }
                                if (unlucky < 0) 
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 158);
                                    }
                                    if (Main.rand.Next(0,4) == 0)
                                    {
                                        if (Main.rand.Next(0,2) == 1)
                                        {
                                            player.QuickSpawnItem(source, 50);
                                        }
                                        else
                                        {
                                            player.QuickSpawnItem(source, 5011);
                                        }
                                    }
                                    player.QuickSpawnItem(source, 53);
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,90));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,75));
                                    player.QuickSpawnItem(source, 14, Main.rand.Next(0,60));
                                    player.QuickSpawnItem(source, 13, Main.rand.Next(0,40));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,300));
                                }
                                if (unlucky == 0)
                                {
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Souls.CavernsS>());
                                    if (Main.rand.Next(0,2) == 0)
                                    {
                                        player.QuickSpawnItem(source, 53);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,65));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,60));
                                    player.QuickSpawnItem(source, 14, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 13, Main.rand.Next(0,20));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,255));
                                }
                                if (unlucky > 0 && unlucky < 6)
                                {
                                    if (Main.rand.Next(0,3) == 0)
                                    {
                                        player.QuickSpawnItem(source, 53);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,45));
                                    player.QuickSpawnItem(source, 14, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 13, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,200));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,5));
                                }
                                if (unlucky > 5 && unlucky < 16)
                                {
                                    if (Main.rand.Next(0,8) == 0)
                                    {
                                        player.QuickSpawnItem(source, 53);
                                    }
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,30));
                                    player.QuickSpawnItem(source, 14, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 13, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,20));
                                }
                                if (unlucky > 15 && unlucky < 31)
                                {
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,15));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,10));
                                    player.QuickSpawnItem(source, 14, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,150));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,35));
                                }
                                if (unlucky > 30)
                                {
                                    player.QuickSpawnItem(source, 12, Main.rand.Next(0,5));
                                    player.QuickSpawnItem(source, 11, Main.rand.Next(0,3));
                                    player.QuickSpawnItem(source, 3, Main.rand.Next(0,50));
                                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Trash.Pebble>(), Main.rand.Next(0,90));
                                }
                                Main.npcChatText = Entry16;
                            }


                            endAllResearches();
                        }
                        else
                        {
                            Main.npcChatText = Entry15;
                        }
                    }
                }
                
            }
            else
            {
                ++ChatNumber;
            }
        }

        public override void AddShops()
        {
            Player player = Main.player[Main.myPlayer];

            NPCShop shop = new NPCShop(Type, "BaseShop");
            shop.addModItemToShop<Items.Lore.SPhone.ScoutPhoneDummy>(10526);
            shop.Add(new Item(ModContent.ItemType<Items.Summons.Invasion.BloodedSpore>()) { shopCustomPrice = 12105 },
                new Condition("", () => WorldGen.crimson));
            shop.Add(new Item(ModContent.ItemType<Items.Summons.Invasion.InfectedSpore>()) { shopCustomPrice = 12105 },
                new Condition("", () => !WorldGen.crimson));
            shop.addModItemToShop<Items.Materials.UPK1>(5000);
            shop.Add(new Item(ModContent.ItemType<Items.Materials.UPK2>()) { shopCustomPrice = 10526 },
                new Condition("", () => NPC.downedBoss2));
            shop.Add(new Item(ModContent.ItemType<Items.Materials.UPK3>()) { shopCustomPrice = 105263 },
                new Condition("", () => NPC.downedBoss3));
            shop.Add(new Item(ModContent.ItemType<Items.Materials.UPK4>()) { shopCustomPrice = 526316 },
                new Condition("", () => NPC.downedMechBossAny));
            shop.Add(new Item(ModContent.ItemType<Items.Materials.UPK5>()) { shopCustomPrice = 1052632 },
                new Condition("", () => NPC.downedPlantBoss));
            shop.Add(new Item(ModContent.ItemType<Items.Materials.UPK6>()) { shopCustomPrice = 5263158 },
                new Condition("", () => NPC.downedMoonlord));
            shop.Add(new Item(ModContent.ItemType<Items.Consumables.Food.GSS>()) { shopCustomPrice = 0 },
                new Condition("", () => !Main.hardMode && TrueOverhaul.modConfiguration.SSystem && TrueOverhaulWorld.season == 0));
            shop.Add(new Item(ModContent.ItemType<Items.Consumables.Food.GSS>()) { shopCustomPrice = 0 },
                new Condition("", () => !Main.hardMode && !TrueOverhaul.modConfiguration.SSystem && !NPC.downedBoss2));
            shop.Add(new Item(ModContent.ItemType<Items.Consumables.Food.SugaredCookie>()) { shopCustomPrice = 0 },
                new Condition("", () => Main.xMas));
            shop.Add(new Item(ModContent.ItemType<Items.Consumables.Heals.OldBandage>()) { shopCustomPrice = 0 },
                new Condition("", () => !Main.hardMode));
            shop.Add(new Item(ModContent.ItemType<Items.Consumables.Heals.HealBandage>()) { shopCustomPrice = 0 },
                new Condition("", () => Main.hardMode));
            shop.Register();

            // NPCShop shop2 = new NPCShop(Type, "ExploringShop");
            // shop2.addModItemToShop<Items.Consumables.Researches.Forest>(5000)
            //     .addModItemToShop<Items.Consumables.Researches.Desert>(10000, TrueOverhaulWorld.desert || player.HasItem(ModContent.ItemType<Items.Souls.DesertS>()) || player.HasItem(276) || player.ZoneDesert)
            //     .addModItemToShop<Items.Consumables.Researches.Snow>(20000, TrueOverhaulWorld.snow || player.HasItem(ModContent.ItemType<Items.Souls.SnowS>()) || player.HasItem(949) || player.ZoneSnow)
            //     .addModItemToShop<Items.Consumables.Researches.Jungle>(20000, TrueOverhaulWorld.jungle || player.HasItem(ModContent.ItemType<Items.Souls.JungleS>()) || player.HasItem(209) || player.ZoneJungle)
            //     .addModItemToShop<Items.Consumables.Researches.Ocean>(25000, TrueOverhaulWorld.ocean || player.HasItem(ModContent.ItemType<Items.Souls.OceanS>()) || player.HasItem(319) || player.ZoneBeach)
            //     .addModItemToShop<Items.Consumables.Researches.Sky>(28000, TrueOverhaulWorld.sky || player.HasItem(ModContent.ItemType<Items.Souls.SkyS>()) || player.HasItem(320) || player.ZoneSkyHeight);
            // shop2.Register();

            NPCShop shop2 = new NPCShop(Type, "ExploringShop");
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Forest>()) { shopCustomPrice = 5000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneForest || TrueOverhaulWorld.forest));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Desert>()) { shopCustomPrice = 10000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneDesert || TrueOverhaulWorld.desert));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Snow>()) { shopCustomPrice = 20000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneSnow || TrueOverhaulWorld.snow));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Jungle>()) { shopCustomPrice = 20000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneJungle || TrueOverhaulWorld.jungle));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Ocean>()) { shopCustomPrice = 25000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneBeach || TrueOverhaulWorld.ocean));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Sky>()) { shopCustomPrice = 28000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneSkyHeight || TrueOverhaulWorld.sky));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Underground>()) { shopCustomPrice = 30000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneDirtLayerHeight || TrueOverhaulWorld.underground));
            shop2.Add(new Item(ModContent.ItemType<Items.Consumables.Researches.Caverns>()) { shopCustomPrice = 35000 },
                new Condition("", () => Main.player[Main.myPlayer].ZoneRockLayerHeight || TrueOverhaulWorld.caverns));
            shop2.Register();

            
        }

        private void endAllResearches()
        {
            TrueOverhaulWorld.rLuckCrash = false;
            TrueOverhaulWorld.forestR = false;
            TrueOverhaulWorld.desertR = false;
            TrueOverhaulWorld.snowR = false;
            TrueOverhaulWorld.jungleR = false;
            TrueOverhaulWorld.oceanR = false;
            TrueOverhaulWorld.skyR = false;
            TrueOverhaulWorld.undergroundR = false;
            TrueOverhaulWorld.cavernsR = false;
            TrueOverhaulWorld.research = false;
            TrueOverhaulNetcode.SyncWorld();
        }
    }
}
