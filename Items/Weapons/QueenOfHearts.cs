using System;
using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace SwordsPlus.Items.Weapons
{
    public class QueenOfHearts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Queen Of Hearts"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.crit = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CardProjectile>();
            Item.shootSpeed = 3f;
        }
    }
}
