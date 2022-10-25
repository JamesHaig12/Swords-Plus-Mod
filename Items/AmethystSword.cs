using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items
{
	public class AmethystSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AmethystSword"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("A Blade Forged With Shiny Purple Gems");
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 2500;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.AmethystBolt;
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
