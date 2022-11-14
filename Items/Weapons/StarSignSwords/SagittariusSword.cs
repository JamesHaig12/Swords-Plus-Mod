using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace SwordsPlus.Items.Weapons.StarSignSwords
{
    public class SagittariusSword : ModItem
    {
        public Vector2 hover;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sagittarius"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault(""); // Devs can change this at will to test features before commiting code to new classes
        }

        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PrismaticSwordBolt>();
            Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 20);
            recipe.AddIngredient(ItemID.Obsidian, 25);
            recipe.AddIngredient(ItemID.FallenStar, 35);
            recipe.AddIngredient<Items.AdvSwordSoul>(20);
            recipe.AddIngredient<Items.PrismaticCore>(1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            velocity.X = 0;
            velocity.Y = 0;
            SoundEngine.PlaySound(SoundID.Item78);
            Projectile.NewProjectile(source, position.X, position.Y - 80f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X - 30f, position.Y - 80f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X - 60f, position.Y - 60f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X + 30f, position.Y - 60f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            return false;
        }
    }
}
