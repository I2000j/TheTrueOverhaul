using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TrueOverhaul.NPCs.Critters
{
	/// <summary>
	/// This file shows off a critter npc. The unique thing about critters is how you can catch them with a bug net.
	/// The important bits are: Main.npcCatchable, NPC.catchItem, and Item.makeNPC.
	/// We will also show off adding an item to an existing RecipeGroup (see ExampleRecipes.AddRecipeGroups).
	/// Additionally, this example shows an involved IL edit.
	/// </summary>
	public class SpiderCritterNPC : ModNPC
	{
		private const int ClonedNPCID = NPCID.Frog; // Easy to change type for your modder convenience


		/// <summary>
		/// Change the following code sequence in Wiring.HitWireSingle
		/// <code>
		///case 61:
		///num115 = 361;
		/// </code>
		/// to
		/// <code>
		///case 61:
		///num115 = Main.rand.NextBool() ? 361 : NPC.type
		/// </code>
		/// This causes the frog statue to spawn this NPC 50% of the time
		/// </summary>
		/// <param name="ilContext"> </param>
		

		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = Main.npcFrameCount[ClonedNPCID]; // Copy animation frames
			Main.npcCatchable[Type] = true; // This is for certain release situations

			// These three are typical critter values
			NPCID.Sets.CountsAsCritter[Type] = true;
			NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
			NPCID.Sets.TownCritter[Type] = true;

			// The frog is immune to confused
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

			// This is so it appears between the frog and the gold frog
			NPCID.Sets.NormalGoldCritterBestiaryPriority.Insert(NPCID.Sets.NormalGoldCritterBestiaryPriority.IndexOf(ClonedNPCID) + 1, Type);
		}

		public override void SetDefaults() {
			// width = 12;
			// height = 10;
			// aiStyle = 7;
			// damage = 0;
			// defense = 0;
			// lifeMax = 5;
			// HitSound = SoundID.NPCHit1;
			// DeathSound = SoundID.NPCDeath1;
			// catchItem = 2121;
			// Sets the above
			NPC.CloneDefaults(ClonedNPCID);

			NPC.catchItem = ModContent.ItemType<SpiderCritterItem>();
			NPC.lavaImmune = true;
			AIType = ClonedNPCID;
			AnimationType = ClonedNPCID;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.AddTags(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("The most adorable goodest spicy child. Do not dare be mean to him!"));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Underworld.Chance * 0.1f;
		}

		public override void HitEffect(NPC.HitInfo hit) {
			if (NPC.life <= 0) {
				for (int i = 0; i < 6; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Worm, 2 * hit.HitDirection, -2f);
					if (Main.rand.NextBool(2)) {
						dust.noGravity = true;
						dust.scale = 1.2f * NPC.scale;
					}
					else {
						dust.scale = 0.7f * NPC.scale;
					}
				}
				// Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Head").Type, NPC.scale);
				// Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Leg").Type, NPC.scale);
			}
		}

		public override Color? GetAlpha(Color drawColor) {
			// GetAlpha gives our Lava Frog a red glow.
			return drawColor with {
				R = 255,
				// Both these do the same in this situation, using these methods is useful.
				G = Utils.Clamp<byte>(drawColor.G, 175, 255),
				B = Math.Min(drawColor.B, (byte)75),
				A = 255
			};
		}

		public override bool PreAI() {
			// Kills the NPC if it hits water, honey or shimmer
			if (NPC.wet && !Collision.LavaCollision(NPC.position, NPC.width, NPC.height)) { // NPC.lavawet not 100% accurate for the frog
				// These 3 lines instantly kill the npc without showing damage numbers, dropping loot, or playing DeathSound. Use this for instant deaths
				NPC.life = 0;
				NPC.HitEffect();
				NPC.active = false;
				SoundEngine.PlaySound(SoundID.NPCDeath16, NPC.position); // plays a fizzle sound
			}

			return true;
		}

		public override void OnCaughtBy(Player player, Item item, bool failed) {
			if (failed) {
				return;
			}

			Point npcTile = NPC.Center.ToTileCoordinates();

			if (!WorldGen.SolidTile(npcTile.X, npcTile.Y)) { // Check if the tile the npc resides the most in is non solid
				Tile tile = Main.tile[npcTile];
				tile.LiquidAmount = tile.LiquidType == LiquidID.Lava ? // Check if the tile has lava in it
					Math.Max((byte)Main.rand.Next(50, 150), tile.LiquidAmount) // If it does, then top up the amount
					: (byte)Main.rand.Next(50, 150); // If it doesn't, then overwrite the amount. Technically this distinction should never be needed bc it will burn but to be safe it's here
				tile.LiquidType = LiquidID.Lava; // Set the liquid type to lava
				WorldGen.SquareTileFrame(npcTile.X, npcTile.Y, true); // Update the surrounding area in the tilemap
			}
		}
	}

	public class SpiderCritterItem : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.IsLavaBait[Type] = true; // While this item is not bait, this will require a lava bug net to catch.
		}

		public override void SetDefaults() {
			// useStyle = 1;
			// autoReuse = true;
			// useTurn = true;
			// useAnimation = 15;
			// useTime = 10;
			// maxStack = CommonMaxStack;
			// consumable = true;
			// width = 12;
			// height = 12;
			// makeNPC = 361;
			// noUseGraphic = true;

			// Cloning ItemID.Frog sets the preceding values
			Item.CloneDefaults(ItemID.Frog);
			Item.makeNPC = ModContent.NPCType<SpiderCritterNPC>();
			Item.value += Item.buyPrice(0, 0, 1, 0); // Make this critter worth slightly more than the frog
			Item.rare = ItemRarityID.Blue;
		}
	}
}