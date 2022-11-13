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
            Tooltip.SetDefault("'I warn you... If i lose my temper, You lose your head!'");
        }

        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.crit = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CardProjectile>();
            Item.shootSpeed = 11f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddIngredient<Items.DeckOfCards>(1);
            recipe.AddIngredient<Items.AdvSwordSoul>(10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            for(int i = 0; i < 4; i++)
            {
                Vector2 pertubedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(source, position.X, position.Y, pertubedSpeed.X, pertubedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
        
        
    }
}
