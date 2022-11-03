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
    public class BlackStormBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Stormblade"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("Strike Your Enemies With The Wrath Of Zues\nInspired By AgentB90");
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 2500;
            Item.rare = 3;
            Item.crit = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<BlackLightningProjectile>();
            Item.shootSpeed = 3f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 20);
            recipe.AddIngredient(ItemID.SilverBar, 20);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddIngredient<Items.AdvSwordSoul>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            // Need to think of a cool recipe for this one
            Recipe recipe2 = CreateRecipe();
            recipe2.AddRecipeGroup("Wood", 20);
            recipe2.AddIngredient(ItemID.GoldBar, 20);
            recipe2.AddIngredient(ItemID.Feather, 5);
            recipe2.AddIngredient<Items.AdvSwordSoul>(10);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 2; i++)
            {
                position = Main.MouseWorld;
                position.Y -= Main.rand.Next(-100, 200);
                velocity.X = 0;
                velocity.Y = 0;
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage * 2, knockBack, player.whoAmI, 0, ceilingLimit);                
            }
            return false;
        }
    }     
}