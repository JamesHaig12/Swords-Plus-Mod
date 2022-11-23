using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items.Weapons
{
    public class AutumnSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Autumn"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("'Its getting colder out here...'\nCauses The Autumn Leaves To Fall");
        }

        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4;
            Item.value = 1000;
            Item.rare = ItemRarityID.Green;
            Item.crit = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<LeafProjectile>();
            Item.shootSpeed = 9f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Gold, 0f, 0f, 0, default(Color), 1.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(velocity.X, velocity.Y).Length();
                velocity.X = heading.X;
                velocity.Y = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.DynastyWood, 30);
            recipe.AddIngredient(ItemID.RedDye, 1);
            recipe.AddIngredient(ItemID.GoldCoin, 1);
            recipe.AddIngredient<Items.SwordSoul>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
