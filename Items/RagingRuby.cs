using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items
{
	public class RagingRuby : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raging Ruby"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("A Blade Forged With Shiny Red Gems And The Flaming Wrath Of Hell");
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 90;
			Item.height = 90;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 2500;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
