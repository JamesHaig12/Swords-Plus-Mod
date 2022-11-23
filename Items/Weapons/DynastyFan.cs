using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items.Weapons
{
    public class DynastyFan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynasty Fan"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("The New Year Brings Good Fortune...\nHitting Enemies Increases Luck");
        }

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4;
            Item.value = 1000;
            Item.rare = ItemRarityID.Green;
            Item.crit = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Gold, 0f, 0f, 0, default(Color), 1.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            Main.LocalPlayer.AddBuff(BuffID.Lucky, 180);
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
