using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items.Weapons.StarSignSwords
{
    public class CancerSword : ModItem
    {
        public Vector2 hover;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cancer"); // By default, capitalization in classnames will add spaces to the display name.
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
            Recipe recipe = CreateRecipe(); // Creates new recipe for item
            recipe.AddIngredient(ItemID.DirtBlock, 10); // Adds 10 dirt blocks to recipe
            recipe.AddRecipeGroup("Wood"); // Special method to call all types of certain item. E.g this calls all wood types rather than just oak wood
            recipe.AddTile(TileID.WorkBenches); // What tile the player needs to be near in order to craft item
            recipe.Register(); // Initialises the recipe for actual use
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            velocity.X = 0;
            velocity.Y = 0;
            Projectile.NewProjectile(source, position.X, position.Y - 80f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X - 30f, position.Y - 80f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X - 60f, position.Y - 60f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X + 30f, position.Y - 60f, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            return false;
        }
    }
}
