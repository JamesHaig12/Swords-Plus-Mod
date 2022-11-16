using System;
using Terraria;
using Terraria.ModLoader;

namespace SwordsPlus.Buffs
{
    internal class Encumbered : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Encumbered");
            Description.SetDefault("You Used Too Much Energy");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
    }
}
