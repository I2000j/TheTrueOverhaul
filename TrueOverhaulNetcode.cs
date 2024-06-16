//using TrueOverhaul.Events;
//using TrueOverhaul.Items;
//using TrueOverhaul.NPCs;
//using TrueOverhaul.NPCs.NormalNPCs;
//using TrueOverhaul.NPCs.TownNPCs;
//using TrueOverhaul.TileEntities;
//using TrueOverhaul.World;
using log4net;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TrueOverhaul
{
  public class TrueOverhaulNetcode
  {
    //public static void HandlePacket(Mod mod, BinaryReader reader, int whoAmI)
    //{
      //try
      //{
        //TrueOverhaulMessageType TrueOverhaulMessageType = (TrueOverhaulMessageType) reader.ReadByte();
        // switch (TrueOverhaulMessageType)
        // {
        //   case TrueOverhaulMessageType.DefenseDamageSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleDefenseDamage(reader);
        //     break;
        //   case TrueOverhaulMessageType.RageSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleRage(reader);
        //     break;
        //   case TrueOverhaulMessageType.AdrenalineSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleAdrenaline(reader);
        //     break;
        //   case TrueOverhaulMessageType.CooldownAddition:
        //     Main.player[reader.ReadInt32()].Calamity().HandleCooldownAddition(reader);
        //     break;
        //   case TrueOverhaulMessageType.CooldownRemoval:
        //     Main.player[reader.ReadInt32()].Calamity().HandleCooldownRemoval(reader);
        //     break;
        //   case TrueOverhaulMessageType.SyncCooldownDictionary:
        //     Main.player[reader.ReadInt32()].Calamity().HandleCooldownDictionary(reader);
        //     break;
        //   case TrueOverhaulMessageType.DeathCountSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleDeathCount(reader);
        //     break;
        //   case TrueOverhaulMessageType.SyncCalamityNPCAIArray:
        //     byte index1 = reader.ReadByte();
        //     float num1 = reader.ReadSingle();
        //     float num2 = reader.ReadSingle();
        //     float num3 = reader.ReadSingle();
        //     float num4 = reader.ReadSingle();
        //     NPC npc = Main.npc[(int) index1];
        //     if (!((Entity) npc).active)
        //       break;
        //     CalamityGlobalNPC calamityGlobalNpc = npc.Calamity();
        //     calamityGlobalNpc.newAI[0] = num1;
        //     calamityGlobalNpc.newAI[1] = num2;
        //     calamityGlobalNpc.newAI[2] = num3;
        //     calamityGlobalNpc.newAI[3] = num4;
        //     break;
        //   case TrueOverhaulMessageType.SpawnSuperDummy:
        //     int num5 = reader.ReadInt32();
        //     int num6 = reader.ReadInt32();
        //     if (Main.netMode == 1)
        //       break;
        //     NPC.NewNPC((IEntitySource) new EntitySource_WorldEvent((string) null), num5, num6, ModContent.NPCType<SuperDummyNPC>(), 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
        //     break;
        //   case TrueOverhaulMessageType.DeleteAllSuperDummies:
        //     if (Main.netMode == 1)
        //       break;
        //     SuperDummy.DeleteDummies();
        //     break;
        //   case TrueOverhaulMessageType.SyncAndroombaSolution:
        //     int index2 = reader.ReadInt32();
        //     int solutionType = reader.ReadInt32();
        //     if (Main.netMode == 1)
        //       break;
        //     AndroombaFriendly.SwapSolution(index2, solutionType);
        //     break;
        //   case TrueOverhaulMessageType.SyncAndroombaAI:
        //     int index3 = reader.ReadInt32();
        //     int phase = reader.ReadInt32();
        //     if (Main.netMode == 1)
        //       break;
        //     AndroombaFriendly.ChangeAI(index3, phase);
        //     break;
        //   case TrueOverhaulMessageType.ServersideSpawnOldDuke:
        //     CalamityUtils.SpawnOldDuke((int) reader.ReadByte());
        //     break;
        //   case TrueOverhaulMessageType.ArmoredDiggerCountdownSync:
        //     CalamityWorld.ArmoredDiggerSpawnCooldown = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.ProvidenceDyeConditionSync:
        //     byte index4 = reader.ReadByte();
        //     (Main.npc[(int) index4].ModNPC as TrueOverhaul.NPCs.Providence.Providence).hasTakenDaytimeDamage = reader.ReadBoolean();
        //     break;
        //   case TrueOverhaulMessageType.PSCChallengeSync:
        //     byte index5 = reader.ReadByte();
        //     (Main.npc[(int) index5].ModNPC as TrueOverhaul.NPCs.Providence.Providence).challenge = reader.ReadBoolean();
        //     break;
        //   case TrueOverhaulMessageType.SpawnNPCOnPlayer:
        //     int num7 = reader.ReadInt32();
        //     int num8 = reader.ReadInt32();
        //     int num9 = reader.ReadInt32();
        //     int num10 = reader.ReadInt32();
        //     Utils.ReadVector2(reader);
        //     if (Main.netMode == 1)
        //       break;
        //     int num11 = NPC.NewNPC((IEntitySource) new EntitySource_WorldEvent((string) null), num7, num8, num9, 0, 0.0f, 0.0f, 0.0f, 0.0f, num10);
        //     NetMessage.SendData(23, -1, num10, (NetworkText) null, num11, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        //     break;
        //   case TrueOverhaulMessageType.SyncNPCMotionDataToServer:
        //     int index6 = reader.ReadInt32();
        //     Vector2 vector2_1 = Utils.ReadVector2(reader);
        //     Vector2 vector2_2 = Utils.ReadVector2(reader);
        //     if (Main.netMode == 1)
        //       break;
        //     ((Entity) Main.npc[index6]).Center = vector2_1;
        //     ((Entity) Main.npc[index6]).velocity = vector2_2;
        //     NetMessage.SendData(23, -1, -1, (NetworkText) null, index6, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        //     break;
        //   case TrueOverhaulMessageType.PowerCellFactory:
        //     TEPowerCellFactory.ReadSyncPacket(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.ChargingStationStandard:
        //     TEChargingStation.ReadSyncPacket(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.ChargingStationItemChange:
        //     TEChargingStation.ReadItemSyncPacket(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.Turret:
        //     TEBaseTurret.ReadSyncPacket(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.LabHologramProjector:
        //     TELabHologramProjector.ReadSyncPacket(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.UpdateCodebreakerConstituents:
        //     TECodebreaker.ReadConstituentsUpdateSync(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.UpdateCodebreakerContainedStuff:
        //     TECodebreaker.ReadContainmentSync(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.UpdateCodebreakerDecryptCountdown:
        //     TECodebreaker.ReadDecryptCountdownSync(mod, reader);
        //     break;
        //   case TrueOverhaulMessageType.CodebreakerSummonStuff:
        //     CalamityWorld.DraedonSummonCountdown = reader.ReadInt32();
        //     CalamityWorld.DraedonSummonPosition = Utils.ReadVector2(reader);
        //     CalamityWorld.DraedonMechdusa = reader.ReadBoolean();
        //     break;
        //   case TrueOverhaulMessageType.ExoMechSelection:
        //     CalamityWorld.DraedonMechToSummon = (ExoMech) reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.BossRushStage:
        //     BossRushEvent.BossRushStage = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.BossRushStartTimer:
        //     BossRushEvent.StartTimer = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.BossRushEndTimer:
        //     BossRushEvent.EndTimer = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.EndBossRush:
        //     BossRushEvent.EndEffects();
        //     break;
        //   case TrueOverhaulMessageType.BRHostileProjKillSync:
        //     BossRushEvent.HostileProjectileKillCounter = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.AcidRainSync:
        //     AcidRainEvent.AcidRainEventIsOngoing = reader.ReadBoolean();
        //     AcidRainEvent.AccumulatedKillPoints = reader.ReadInt32();
        //     AcidRainEvent.TimeSinceLastAcidRainKill = reader.ReadInt32();
        //     break;
        //   case TrueOverhaulMessageType.AcidRainOldDukeSummonSync:
        //     AcidRainEvent.HasTriedToSummonOldDuke = reader.ReadBoolean();
        //     break;
        //   case TrueOverhaulMessageType.EncounteredOldDukeSync:
        //     AcidRainEvent.OldDukeHasBeenEncountered = reader.ReadBoolean();
        //     break;
        //   case TrueOverhaulMessageType.RightClickSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleRightClick(reader);
        //     break;
        //   case TrueOverhaulMessageType.MousePositionSync:
        //     Main.player[reader.ReadInt32()].Calamity().HandleMousePosition(reader);
        //     break;
        //   case TrueOverhaulMessageType.SyncDifficulties:
        //     int sender = reader.ReadInt32();
        //     CalamityWorld.revenge = reader.ReadBoolean();
        //     CalamityWorld.death = reader.ReadBoolean();
        //     if (Main.netMode != 2)
        //       break;
        //     CalamityNetcode.SyncCalamityWorldDifficulties(sender);
        //     break;
        //   default:
        //     ILog logger = TrueOverhaul.TrueOverhaul.Instance.Logger;
        //     DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(68, 1);
        //     interpolatedStringHandler.AppendLiteral("Failed to parse Calamity packet: No Calamity packet exists with ID ");
        //     interpolatedStringHandler.AppendFormatted<TrueOverhaulMessageType>(TrueOverhaulMessageType);
        //     interpolatedStringHandler.AppendLiteral(".");
        //     string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        //     logger.Error((object) stringAndClear);
        //     throw new Exception("Failed to parse Calamity packet: Invalid Calamity packet ID.");
        // }
      //}
      // catch (Exception ex)
      // {
      //   switch (ex)
      //   {
      //     case EndOfStreamException ofStreamException:
      //       TrueOverhaul.TrueOverhaul.Instance.Logger.Error((object) "Failed to parse Calamity packet: Packet was too short, missing data, or otherwise corrupt.", (Exception) ofStreamException);
      //       break;
      //     case ObjectDisposedException disposedException:
      //       TrueOverhaul.TrueOverhaul.Instance.Logger.Error((object) "Failed to parse Calamity packet: Packet reader disposed or destroyed.", (Exception) disposedException);
      //       break;
      //     case IOException ioException:
      //       TrueOverhaul.TrueOverhaul.Instance.Logger.Error((object) "Failed to parse Calamity packet: An unknown I/O error occurred.", (Exception) ioException);
      //       break;
      //     default:
      //       throw;
      //   }
      // }
    //}

    public static void SyncWorld()
    {
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(7, -1, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
    }

    // public static void SyncCalamityWorldDifficulties(int sender)
    // {
    //   if (Main.netMode == 0)
    //     return;
    //   ModPacket packet = TrueOverhaul.TrueOverhaul.Instance.GetPacket(256);
    //   ((BinaryWriter) packet).Write((byte) 38);
    //   ((BinaryWriter) packet).Write(sender);
    //   ((BinaryWriter) packet).Write(CalamityWorld.revenge);
    //   ((BinaryWriter) packet).Write(CalamityWorld.death);
    //   packet.Send(-1, sender);
    // }
  }
}
