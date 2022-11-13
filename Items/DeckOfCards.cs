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
            Tooltip.SetDefault("There seems to be 52 of them");
        }
    }
}
