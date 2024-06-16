﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace TrueOverhaul.Items.Materials
{
    internal class UPK3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            this.Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.value = 375000;
            Item.maxStack = 999;
            Item.rare = 3;
        }	
    }
}
