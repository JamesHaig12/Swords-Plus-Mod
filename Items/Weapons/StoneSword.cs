using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using SwordsPlus;


namespace SwordsPlus.Items.Weapons
{
	public class StoneSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Sword");
			Tooltip.SetDefault("Steve Would Be Proud");
		}

		public override void SetDefaults()
		{
			Item.damage = 8; 
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;
            Item.useTime = 20; 
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing; 
			Item.knockBack = 6; 
			Item.value = 10000; 
			Item.rare = ItemRarityID.White; 
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true; 
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.StoneBlock, 10); 
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
