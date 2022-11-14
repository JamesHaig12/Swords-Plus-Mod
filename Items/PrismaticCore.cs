using System;
using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace SwordsPlus.Items
{
    public class PrismaticCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Core"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("The Glistening Light Of The Stars Above");

            ItemID.Sets.ItemIconPulse[Item.type] = true;          
        }

        public override void SetDefaults()
        {
            Item.width = 20; // The item texture's width
            Item.height = 20; // The item texture's height

            Item.maxStack = 1; // The item's max stack value
            Item.value = Item.buyPrice(gold: 25);

            Item.rare = ItemRarityID.Expert;
        }
    }
}
