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
    public class DeckOfCards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deck Of Cards"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("There Seems To Be 52 Of Them");
        }

        public override void SetDefaults()
        {
            Item.width = 20; // The item texture's width
            Item.height = 20; // The item texture's height

            Item.maxStack = 999; // The item's max stack value
            Item.value = Item.buyPrice(silver: 1);

            Item.rare = ItemRarityID.Green;
        }
    }
}
