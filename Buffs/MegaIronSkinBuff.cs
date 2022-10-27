using System;
using Terraria;
using Terraria.ModLoader;

namespace SwordsPlus.Buffs
{
    internal class MegaIronSkinBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Ironskin");
            Description.SetDefault("Grants +12 defense.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 12; // Grant a +12 defense boost to the player while the buff is active
        }
    }
}
