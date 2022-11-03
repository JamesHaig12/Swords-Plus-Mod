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
            DisplayName.SetDefault("Great StormBlade"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("Strike Your Enemies With The Wrath Of Zeus\nInspired By AgentB90");
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
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.Obsidian, 30);
            recipe.AddIngredient<Items.AdvSwordSoul>(20);
            recipe.AddIngredient<Weapons.WhiteStormBlade>(1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            
            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe2.AddIngredient(ItemID.Obsidian, 30);
            recipe2.AddIngredient<Items.AdvSwordSoul>(20);
            recipe2.AddIngredient<Weapons.WhiteStormBlade>(1);
            recipe2.AddTile(TileID.MythrilAnvil);
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