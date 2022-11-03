using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace SwordsPlus.Items.Weapons
{
    public class PoisonIvy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Ivy"); 
            Tooltip.SetDefault("Inflicts Poison To Struck Enemies\nDont Touch That!");
        }

        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 3;
            Item.knockBack = 7;
            Item.value = 2500;
            Item.rare = 4;
            Item.crit = 17;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.JungleGrass, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = false;
            Main.dust[dust].velocity *= 0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 20);
            recipe.AddIngredient(ItemID.SilverBar, 20);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.Vine, 15);
            recipe.AddIngredient<Items.AdvSwordSoul>(10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
