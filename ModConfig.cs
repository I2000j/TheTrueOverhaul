using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Terraria.Localization;

namespace TrueOverhaul
{

  	[BackgroundColor(15, 102, 54, 216)]

	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("$Mods.TrueOverhaul.Header1")]

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.SSystem")]
		[Tooltip("$Mods.TrueOverhaul.SSystem")]
		[ReloadRequired]
		public bool SSystem;

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.RecSystem")]
		[Tooltip("$Mods.TrueOverhaul.RecSystem")]
		[ReloadRequired]
		public bool RecSystem;

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.Relocating")]
		[Tooltip("$Mods.TrueOverhaul.Relocating")]
		public bool Relocating;

		[Range(1, 30)]
		[DefaultValue(10)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.ResearchChanse")]
		[Tooltip("$Mods.TrueOverhaul.ResearchChanse")]
		public int ResearchChanse;

		[Header("$Mods.TrueOverhaul.Header2")]

		[DefaultValue(false)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.FriendlyM")]
		[Tooltip("$Mods.TrueOverhaul.FriendlyM")]
		[ReloadRequired]
		public bool FriendlyM;

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.QoL")]
		[Tooltip("$Mods.TrueOverhaul.QoL")]
		[ReloadRequired]
		public bool QoL;

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.MHelper")]
		[Tooltip("$Mods.TrueOverhaul.MHelper")]
		public bool MHelper;

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.AnDay")]
		[Tooltip("$Mods.TrueOverhaul.AnDay")]
		public bool AnDay;

		[Header("$Mods.TrueOverhaul.Header3")]

		[DefaultValue(true)]
		[BackgroundColor(20, 92, 52, 192)]
		[Label("$Mods.TrueOverhaul.GirlScoutSpawn")]
		[Tooltip("$Mods.TrueOverhaul.GirlScoutSpawn")]
		public bool GirlScoutSpawn;

		

		

		

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			TrueOverhaul.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (whoAmI == 0) {
				message = Language.GetTextValue("Mods.TrueOverhaul.ConfigC");
				return true;
			}
			if (whoAmI != 0)
			{
				message = Language.GetTextValue("Mods.TrueOverhaul.ConfigS");
				return false;
			}
			return false;
		}
	}
}
