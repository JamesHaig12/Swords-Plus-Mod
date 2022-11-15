using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace SwordsPlus.Items.Weapons
{
	public class DirtSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Sword");
			Tooltip.SetDefault("Why Would Anyone Do This?");
		}

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Dirt, 0f, 0f, 0, default(Color), 1.5f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Wood", 10);
			recipe.AddIngredient(ItemID.DirtBlock, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
