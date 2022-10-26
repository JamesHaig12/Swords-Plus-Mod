using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items.Weapons
{
	public class TestSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Test Sword"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("Test Sword For The Devs To Play About With"); // Devs can change this at will to test features before commiting code to new classes
		}

		public override void SetDefaults()
		{
			Item.damage = 50000; // Damage
			Item.DamageType = DamageClass.Melee; // What accessories and armour sets modify the damage
			Item.width = 40; // Hitbox
			Item.height = 40; // Hitbox
            Item.useTime = 10; // Speed player uses weapon
			Item.useAnimation = 10; // Must match useTime so animations and sounds are not off 
			Item.useStyle = 1; // Select swing style
			Item.knockBack = 6; // Knockback amount
			Item.value = 10000; // item's shop sell price in silver
			Item.rare = 2; // Item's rarity or name colour
			Item.UseSound = SoundID.Item1; // "Use" sound effect
			Item.autoReuse = true; // Auto swing true or false
			Item.shoot = ProjectileID.AmethystBolt; // Simple existing projectile from default game
			Item.shootSpeed = 8f; // How fast the projectile moves
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(); // Creates new recipe for item
			recipe.AddIngredient(ItemID.DirtBlock, 10); // Adds 10 dirt blocks to recipe
			recipe.AddRecipeGroup("Wood"); // Special method to call all types of certain item. E.g this calls all wood types rather than just oak wood
			recipe.AddTile(TileID.WorkBenches); // What tile the player needs to be near in order to craft item
			recipe.Register(); // Initialises the recipe for actual use
		}
	}
}
