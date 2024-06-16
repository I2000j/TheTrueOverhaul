using System;
using System.Collections.Generic;
using TrueOverhaul.Events;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using TrueOverhaul.NPCs.TownNPC;

namespace TrueOverhaul
{
    public class TrueOverhaulWorld : ModSystem
    {
        //Setting up variables for invasion
        public static bool EatersRelocateUp = false;
        public static bool MonstersRelocateUp = false;
        public static bool downedEatersRelocate = false;
        public static bool downedMonstersRelocate = false;

        //Season system
        public static int dayCounter = 0;
        public static int dayToSeason = 0;
        public static int season = 0;
        private static int rainSpringChance = 0;
        private static int beeSummerChance = 0;
        private static int stormAutumnChance = 0;
        private static int deerWinterChance = 0;

        //Girl Scout stats
        public static bool ScoutCrystal = false;
        public static bool ScoutFruit = false;

        //Researches
        public static bool research = false;
        public static bool rLuckCrash = false;

        public static bool forestR = false;
        public static bool desertR = false;
        public static bool snowR = false;
        public static bool jungleR = false;
        public static bool oceanR = false;
        public static bool skyR = false;
        public static bool undergroundR = false;
        public static bool cavernsR = false;

        // Researches BloodMoon

        //Researched
        public static bool forest = false;
        public static bool desert = false;
        public static bool snow = false;
        public static bool jungle = false;
        public static bool ocean = false;
        public static bool sky = false;
        public static bool underground = false;
        public static bool caverns = false;

        // Researched BloodMoon

        //Initialize all variables to their default values
        public override void LoadWorldData(TagCompound tag)
        {
            //Invasion
            Main.invasionSize = 0;
            EatersRelocateUp = false;
            downedEatersRelocate = false;
            MonstersRelocateUp = false;
            downedMonstersRelocate = false;

            //Season
            dayCounter = 0;
            dayToSeason = 0;
            season = 0;

            //Girl Scout stats
            ScoutCrystal = false;
            ScoutFruit = false;

            //Researches
            research = false;
            rLuckCrash = false;

            forestR = false;
            desertR = false;
            snowR = false;
            jungleR = false;
            oceanR = false;
            skyR = false;
            undergroundR = false;
            cavernsR = false;

            //Researched
            forest = false;
            desert = false;
            snow = false;
            jungle = false;
            ocean = false;
            sky = false;
            underground = false;
            caverns = false;

            var downed = tag.GetList<string>("downed");
            downedEatersRelocate = downed.Contains("downedEatersRelocate");
            downedMonstersRelocate = downed.Contains("downedMonstersRelocate");

            var scout = tag.GetList<string>("scout");
            ScoutCrystal = scout.Contains("ScoutCrystal");
            ScoutFruit = scout.Contains("ScoutFruit");

            var researches = tag.GetList<string>("researches");
            research = researches.Contains("research");
            rLuckCrash = researches.Contains("rLuckCrash");
            forestR = researches.Contains("forestR");
            desertR = researches.Contains("desertR");
            snowR = researches.Contains("snowR");
            jungleR = researches.Contains("jungleR");
            oceanR = researches.Contains("oceanR");
            skyR = researches.Contains("skyR");
            undergroundR = researches.Contains("undergroundR");
            cavernsR = researches.Contains("cavernsR");

            var researched = tag.GetList<string>("researched");
            forest = researched.Contains("forest");
            desert = researched.Contains("desert");
            snow = researched.Contains("snow");
            jungle = researched.Contains("jungle");
            ocean = researched.Contains("ocean");
            sky = researched.Contains("sky");
            underground = researched.Contains("underground");
            caverns = researched.Contains("caverns");

            var events = tag.GetList<string>("events");
            EatersRelocateUp = downed.Contains("EatersRelocateUp");
            MonstersRelocateUp = downed.Contains("MonstersRelocateUp");

            var counter = tag.GetList<string>("counter");
            for (int i = 0; i < 999; i++)
            {
                if(counter.Contains(i.ToString()))
                {
                    dayCounter = i;
                }
            }
            
            var DTScounter = tag.GetList<string>("DTScounter");
            for (int i = 0; i < 15; i++)
            {
                if(DTScounter.Contains(i.ToString()))
                {
                    dayToSeason = i;
                }
            }

            var Scounter = tag.GetList<string>("Scounter");
            if(Scounter.Contains("0"))
            {
                season = 0;
            }
            if(Scounter.Contains("1"))
            {
                season = 1;
            }
            if(Scounter.Contains("2"))
            {
                season = 2;
            }  
            if(Scounter.Contains("3"))
            {
                season = 3;
            }   

            var TIRED = tag.GetList<string>("TIRED");
            for (int i = 0; i < 7; i++)
            {
                if(TIRED.Contains(i.ToString()))
                {
                    GirlScout.IMTIRED = i;
                }
            }
        }

        //Save downed data
        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedEatersRelocate) {
                downed.Add("downedEatersRelocate");
            }
            if (downedMonstersRelocate) {
                downed.Add("downedMonstersRelocate");
            }

            tag ["downed"] = downed;

            var scout = new List<string>();
            if (ScoutCrystal) {
                scout.Add("ScoutCrystal");
            }
            if (ScoutFruit) {
                scout.Add("ScoutFruit");
            }
            
            tag ["scout"] = scout;

            var researches = new List<string>();
            if (research) {
                researches.Add("research");
            }
            if (rLuckCrash) {
                researches.Add("rLuckCrash");
            }
            if (forestR) {
                researches.Add("forestR");
            }
            if (desertR) {
                researches.Add("desertR");
            }
            if (snowR) {
                researches.Add("snowR");
            }
            if (jungleR) {
                researches.Add("jungleR");
            }
            if (oceanR) {
                researches.Add("oceanR");
            }
            if (skyR) {
                researches.Add("skyR");
            }
            if (undergroundR) {
                researches.Add("undergroundR");
            }
            if (cavernsR) {
                researches.Add("cavernsR");
            }

            tag ["researches"] = researches;

            var researched = new List<string>();
            if (forest) {
                researched.Add("forest");
            }
            if (desert) {
                researched.Add("desert");
            }
            if (snow) {
                researched.Add("snow");
            }
            if (jungle) {
                researched.Add("jungle");
            }
            if (ocean) {
                researched.Add("ocean");
            }
            if (sky) {
                researched.Add("sky");
            }
            if (underground) {
                researched.Add("underground");
            }
            if (caverns) {
                researched.Add("caverns");
            }
            
            tag ["researched"] = researched;

            var events = new List<string>();
            if (EatersRelocateUp) {
                events.Add("EatersRelocateUp");
            }
            if (MonstersRelocateUp) {
                events.Add("MonstersRelocateUp");
            }

            tag ["events"] = events;

            var counter = new List<string>();
            counter.Add(dayCounter.ToString());

            tag ["counter"] = counter;

            var DTScounter = new List<string>();
            DTScounter.Add(dayToSeason.ToString());

            tag ["DTScounter"] = DTScounter;

            var Scounter = new List<string>();
            Scounter.Add(season.ToString());

            tag ["Scounter"] = Scounter;

            var TIRED = new List<string>();
            TIRED.Add((GirlScout.IMTIRED).ToString());

            tag ["TIRED"] = TIRED;

        }

        public override void NetSend(BinaryWriter writer)
        {
           BitsByte flags = new BitsByte();
           //Events
           flags[0] = downedEatersRelocate;
           flags[1] = downedMonstersRelocate;
           //Girl Scout stats
           flags[2] = ScoutCrystal;
           flags[3] = ScoutFruit;
           //Researches
           flags[4] = research;
           flags[5] = rLuckCrash;
           flags[6] = forestR;
           flags[7] = desertR;
           flags[8] = snowR;
           flags[9] = jungleR;
           flags[10] = oceanR;
           flags[11] = skyR;
           flags[12] = undergroundR;
           flags[13] = cavernsR;
           writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
           BitsByte flags = reader.ReadByte();
           //Events
           downedEatersRelocate = flags[0];
           downedMonstersRelocate = flags[1];
           //Girl Scout stats
           ScoutCrystal = flags[2];
           ScoutFruit = flags[3];
           //Researches
           research = flags[4];
           rLuckCrash = flags[5];
           forestR = flags[6];
           desertR = flags[7];
           snowR = flags[8];
           jungleR = flags[9];
           oceanR = flags[10];
           skyR = flags[11];
           undergroundR = flags[12];
           cavernsR = flags[12];
        }


        public override void PostUpdateWorld()
		{
            if (TrueOverhaul.modConfiguration.GirlScoutSpawn)
            {
                if (!rLuckCrash && research)
                {
                    if (TrueOverhaulWorld.forestR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.ForestS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.desertR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.DesertS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.snowR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.SnowS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.jungleR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.JungleS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.oceanR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.OceanS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.skyR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.SkyS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.undergroundR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.UndergroundS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    if (TrueOverhaulWorld.cavernsR)
                    {
                        if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Souls.CavernsS>()))
                        {
                            rLuckCrash = false;
                        }
                        else
                        {
                            rLuckCrash = true;
                        }
                    }
                    TrueOverhaulNetcode.SyncWorld();
                }
            }
            
            if (TrueOverhaul.modConfiguration.SSystem)
            {
                if (season == 2)
                {
                    Main.halloween = true;
                } else {
                    Main.halloween = false;
                }

                if (season == 3)
                {
                    if (Main.IsItRaining || Main.IsItStorming){
                        Main.rainTime = 0;
                        Main.raining = false;
                    }
                    Main.xMas = true;
                } else {
                    Main.xMas = false;
                }

                if(Main.time == 0)
                {
                    if (TrueOverhaul.modConfiguration.GirlScoutSpawn && research)
                    {
                        if (Main.rand.Next(0, TrueOverhaul.modConfiguration.ResearchChanse) == 0)
                        {
                            Player player = Main.player[Main.myPlayer];

                            if (player.GetModPlayer<TrueOverhaulPlayer>().EnabledPhone) 
                            {
                                SoundStyle soundStyle = new SoundStyle("TrueOverhaul/Assets/Sounds/ResearchOver", (SoundType) 0);
				                SoundEngine.PlaySound(soundStyle, new Vector2?(((Entity) player).Center));
                                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.ResearchOver")), new Color(96, 122, 163));
                            }

                            research = false;
                            TrueOverhaulNetcode.SyncWorld();
                        }
                    }

                    if(!Main.dayTime)
                    {
                        deerWinterChance = Main.rand.Next(0,20);
                        if (season == 3 && deerWinterChance == 1)
                        {
                            SoundEngine.PlaySound(SoundID.Roar, new Vector2?());
                            int num = NPCID.Deerclops;
                            Player player = Main.player[Main.myPlayer];
                            if (Main.netMode != 1)
                              NPC.SpawnOnPlayer(((Entity) player).whoAmI, num);
                            else
                              NetMessage.SendData(61, -1, -1, (NetworkText) null, ((Entity) player).whoAmI, (float) num, 0.0f, 0.0f, 0, 0, 0);
                        }

                        if (TrueOverhaul.modConfiguration.Relocating)
                        {
                            if (season == 2)
                            {
                                if (Main.rand.Next(15) == 0)
                                {
                                    if (WorldGen.crimson)
                                    {
                                        TrueOverhaulNetcode.SyncWorld();
                                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.MonstersRelocateSummoned")), new Color(175, 75, 255));
                                        MonstersRelocate.StartMonstersRelocate();
                                    }
                                    else
                                    {
                                        TrueOverhaulNetcode.SyncWorld();
                                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.EatersRelocateSummoned")), new Color(175, 75, 255));
                                        EatersRelocate.StartEatersRelocate();
                                    }
                                }
                            }
                        }
                    }
                    stormAutumnChance = Main.rand.Next(0,2);
                    if (season == 2)
                    {
                        if (!Main.IsItRaining && !Main.IsItStorming && (double) Main.windSpeedTarget <= 0.40000000596046448 && stormAutumnChance == 1)
                        {
                            LanternNight.GenuineLanterns = false;
                            LanternNight.ManualLanterns = false;
                            Main.rainTime = (double) (86400 / 24 * 12);
                            Main.raining = true;
                            Main.maxRaining = Main.cloudAlpha = 0.9f;
                            if (Main.netMode == 2)
                            {
                              NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                              Main.SyncRain();
                            }
                            Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;
                            if (Main.netMode == 2)
                                NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.StormStarts")), new Color(44, 4, 97));

                            return;
                        }

                        if (!Main.IsItRaining && !Main.IsItStorming && (double) Main.windSpeedTarget > 0.40000000596046448 && stormAutumnChance == 1)
                        {
                            LanternNight.GenuineLanterns = false;
                            LanternNight.ManualLanterns = false;
                            Main.rainTime = (double) (86400 / 24 * 12);
                            Main.raining = true;
                            Main.maxRaining = Main.cloudAlpha = 0.9f;
                            if (Main.netMode == 2)
                            {
                              NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                              Main.SyncRain();
                            }
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.StormRStarts")), new Color(44, 4, 97));

                            return;
                        }

                        if (Main.IsItRaining || Main.IsItStorming && (double) Main.windSpeedTarget <= 0.40000000596046448 && stormAutumnChance == 1)
                        {
                            Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;
                            if (Main.netMode == 2)
                                NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.StormWStarts")), new Color(44, 4, 97));

                            return;
                        }
                    }
                }
            }
            
            if(Main.dayTime && Main.time == 0)
            {
                
                if (TrueOverhaul.modConfiguration.AnDay)
                {
                    dayCounter++;
                    TrueOverhaulNetcode.SyncWorld();
                }
                if (TrueOverhaul.modConfiguration.SSystem)
                {
                    dayToSeason++;
                    rainSpringChance = Main.rand.Next(0,3);
                    beeSummerChance = Main.rand.Next(0,20);
                    if (season == 1 && beeSummerChance == 1)
                    {
                        SoundEngine.PlaySound(SoundID.Roar, new Vector2?());
                        int num = NPCID.QueenBee;
                        Player player = Main.player[Main.myPlayer];
                        if (Main.netMode != 1)
                          NPC.SpawnOnPlayer(((Entity) player).whoAmI, num);
                        else
                          NetMessage.SendData(61, -1, -1, (NetworkText) null, ((Entity) player).whoAmI, (float) num, 0.0f, 0.0f, 0, 0, 0);
                    }
                    if (season == 0)
                    {
                        if (!Main.IsItRaining && !Main.IsItStorming && rainSpringChance == 2)
                        {
                            LanternNight.GenuineLanterns = false;
                            LanternNight.ManualLanterns = false;
                            Main.rainTime = (double) (86400 / 24 * 12);
                            Main.raining = true;
                            Main.maxRaining = Main.cloudAlpha = 0.9f;
                            if (Main.netMode == 2)
                            {
                              NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                              Main.SyncRain();
                            }
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.RainStarts")), new Color(33, 191, 219));
                        }
                    }
                    TrueOverhaulNetcode.SyncWorld();
                }
            }

            if (dayToSeason > 15 && TrueOverhaul.modConfiguration.SSystem)
            {
                dayToSeason = 0;
                season++;
                if (season > 3)
                {
                    season = 0;
                }
                if (season == 0)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.Spring")), new Color(227, 235, 123));
                }
                if (season == 1)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.Summer")), new Color(64, 214, 39));
                }
                if (season == 2)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.Autumn")), new Color(214, 162, 39));
                }
                if (season == 3)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.Winter")), new Color(237, 235, 230));
                }
            }

            if (season > 3)
            {
                season = 0;
            }

            if(Main.dayTime && Main.time == 0 && TrueOverhaul.modConfiguration.AnDay)
            {
                if (Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Russian))
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Новый день наступает! День: " + dayCounter), new Color(175, 75, 255));
                } 
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("New day arrives! Day: " + dayCounter), new Color(175, 75, 255));
                }
            }

            if (TrueOverhaul.modConfiguration.Relocating)
            {
			    if(EatersRelocateUp)
			    {
			    	if(Main.invasionX == (double)Main.spawnTileX)
			    	{
			    		EatersRelocate.CheckEatersRelocateProgress();
			    	}
			    	EatersRelocate.UpdateEatersRelocate();
                    TrueOverhaulNetcode.SyncWorld();
			    }

                if(MonstersRelocateUp)
			    {
			    	if(Main.invasionX == (double)Main.spawnTileX)
			    	{
			    		MonstersRelocate.CheckMonstersRelocateProgress();
			    	}
			    	MonstersRelocate.UpdateMonstersRelocate();
                    TrueOverhaulNetcode.SyncWorld();
			    }
            }

        }
		
    }
}