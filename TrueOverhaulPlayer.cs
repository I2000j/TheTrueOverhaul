using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using TrueOverhaul.NPCs.TownNPC;

#nullable enable
namespace TrueOverhaul
{
  public class TrueOverhaulPlayer : ModPlayer
  {
    //AntiSpawn
    public bool noStupidNaturalERSpawns;
    public bool noStupidNaturalMRSpawns;
    //Temperature (NOT DONE)
    public double temperature;
    //In Inventory
    public bool EnabledPhone;


    public override void ResetEffects()
    {
      //Anti Spawn
      noStupidNaturalERSpawns = false;
      noStupidNaturalMRSpawns = false;
      //Temperature (NOT DONE)
      temperature = 0;
      //In Inventory
      EnabledPhone = false;
    }

    public override void OnEnterWorld()
    {
      if (TrueOverhaul.modConfiguration.MHelper)
      {
        ModLoader.TryGetMod("Fargowiltas", out Mod Fargowiltas);
        if (Fargowiltas != null && TrueOverhaul.modConfiguration.SSystem)
        {
          ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.TrueOverhaul.ModsHelper") + Language.GetTextValue("Mods.TrueOverhaul.FTconflict")), new Color(255, 255, 255));
        }
      }
    }

    public override void PostUpdate()
    {
      //TemperatureUpdate();

      Player player = Main.player[Main.myPlayer];

      if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Lore.SPhone.ScoutPhoneOn>())) 
      {
        EnabledPhone = true;
      }
      else
      {
        EnabledPhone = false;
      }

      if(Main.time == 0)
      {
       if (GirlScout.IMTIRED != 0)
       {
         if (GirlScout.IMTIRED == 1)
         {
           GirlScout.IMTIRED--;
         } else {
           GirlScout.IMTIRED--;
           GirlScout.IMTIRED--;
         }
       }
      }

      if (TrueOverhaul.modConfiguration.GirlScoutSpawn)
      {
        if (GirlScout.IMTIRED > 5)
        {
          Player.AddBuff(ModContent.BuffType<Buffs.IMTIRED>(), 60);
        }
        else
        {
          int index = Player.FindBuffIndex(ModContent.BuffType<Buffs.IMTIRED>());
          if (index >= 0)
			    {
			    	Player.DelBuff(index);
          }
        }
      }

      if (TrueOverhaul.modConfiguration.Relocating)
      {
        if (TrueOverhaulWorld.EatersRelocateUp)
        {
          Player.ZoneCorrupt = true;
        } 

        if (TrueOverhaulWorld.MonstersRelocateUp)
        {
          Player.ZoneCrimson = true;
        }
      }

      if (TrueOverhaul.modConfiguration.SSystem)
      {
        if (TrueOverhaulWorld.season == 1)
      	{
          Player.AddBuff(124, 60);
        }

        if (TrueOverhaulWorld.season == 2)
      	{
          Player.AddBuff(BuffID.Darkness, 60);
          if(Player.HasBuff(BuffID.Sunflower))
      		{   
				    int index = Player.FindBuffIndex(BuffID.Sunflower);
            if (index >= 0)
			      {
			      	Player.DelBuff(index);
            }
      		  Player.AddBuff(ModContent.BuffType<Buffs.Depressed>(), 60);
      		}
      	}

        if (TrueOverhaulWorld.season == 3)
        { 
          Player.ZoneSnow = true;

          Player.AddBuff(BuffID.Blackout, 60);

          if(Player.HasBuff(BuffID.Sunflower))
      		{
            int index = Player.FindBuffIndex(BuffID.Sunflower);
            if (index >= 0)
			      {
			      	Player.DelBuff(index);
            }
      		  Player.AddBuff(ModContent.BuffType<Buffs.Depressed>(), 60);
      		}
        }
      }
    }

    private void TemperatureUpdate()
    {

      if (temperature > 10)
      {
        if(Player.HasBuff(BuffID.OnFire))
        {
          Player.lifeRegen -= 8;
        }
      }

      if (Player.adjLava && !((Entity) Player).lavaWet && !Player.lavaRose && !Player.lavaImmune)
      {
        if (temperature < 10)
        {
          temperature += 0.002;
        }
      }

      if(Player.HasBuff(BuffID.OnFire))
      {
        if (temperature < 9)
        {
          temperature += 0.001;
        }
      }

      if(Player.HasBuff(BuffID.Burning))
      {
        if (temperature < 9)
        {
          temperature += 0.001;
        }
      }

      if(Player.HasBuff(BuffID.Inferno))
      {
        if (temperature < 1)
        {
          temperature += 0.0001;
        }
      }

      if(Player.HasBuff(BuffID.Chilled))
      {
        if (temperature > -3)
        {
          temperature -= 0.001;
        }
      }

      if(Player.HasBuff(BuffID.Frozen))
      {
        if (temperature > -5)
        {
          temperature -= 0.002;
        }
      }

      if (!Player.ZoneUnderworldHeight)
      {

      } else {

        if(!Player.HasBuff(BuffID.ObsidianSkin))
        {
          if (temperature < 9)
          {
            temperature += 0.01;
          }
        }

      }
    }

  }
}
