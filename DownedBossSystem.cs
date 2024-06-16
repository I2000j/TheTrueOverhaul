using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TrueOverhaul
{
  public class DownedBossSystem : ModSystem
  {
    internal static bool _downedEatersRelocate;
    internal static bool _downedMonstersRelocate;

    public static bool downedEatersRelocate
    {
      get => DownedBossSystem._downedEatersRelocate;
      set
      {
        if (!value)
          DownedBossSystem._downedEatersRelocate = false;
        else
          NPC.SetEventFlagCleared(ref DownedBossSystem._downedEatersRelocate, -1);
      }
    }

    public static bool downedMonstersRelocate
    {
      get => DownedBossSystem._downedMonstersRelocate;
      set
      {
        if (!value)
          DownedBossSystem._downedMonstersRelocate = false;
        else
          NPC.SetEventFlagCleared(ref DownedBossSystem._downedMonstersRelocate, -1);
      }
    }

    internal static void ResetAllFlags()
    {
      DownedBossSystem.downedEatersRelocate = false;
      DownedBossSystem.downedMonstersRelocate = false;
    }

    public virtual void OnWorldLoad() => DownedBossSystem.ResetAllFlags();

    public virtual void OnWorldUnload() => DownedBossSystem.ResetAllFlags();

    public virtual void SaveWorldData(TagCompound tag)
    {
      List<string> stringList = new List<string>();
      if (DownedBossSystem.downedEatersRelocate)
        stringList.Add("eatersRelocate");
      if (DownedBossSystem.downedMonstersRelocate)
        stringList.Add("monstersRelocate");
      tag["downedFlags"] = (object) stringList;
    }

    public virtual void LoadWorldData(TagCompound tag)
    {
      IList<string> list = tag.GetList<string>("downedFlags");
      DownedBossSystem.downedEatersRelocate = list.Contains("eatersRelocate");
      DownedBossSystem.downedMonstersRelocate = list.Contains("monstersRelocate");
    }
  }
}
