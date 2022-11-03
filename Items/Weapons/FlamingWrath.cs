using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace SwordsPlus.Items.Weapons
{
	public class FlamingWrath : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flaming Wrath"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("Inflicts Burning To Struck Enemies\nA Blade Forged With Shiny Red Gems And The Flaming Wrath Of Hell");
		}

		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Melee;
			Item.width = 87;
			Item.height = 87;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 2500;
			Item.rare = 3;
			Item.crit = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<FlameProjectile>();
			Item.shootSpeed = 9f;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 180);
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			// Creates a new dust particle effect on weapon swing at the hitbox, sets gravity off and velocity to 0 so it doesnt fly everywhere
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Flare, 0f, 0f, 0, default(Color),2f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
		}



		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddIngredient<Items.SwordSoul>(10);
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
