using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items
{
	public class RoseSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bleeding Vines"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("The bite of a rose's thorn will sting for some time");
		}

		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Melee;
			Item.width = 260;
			Item.height = 260;
			Item.scale = 0.7f;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 2500;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.UseSound = SoundID.Grass;
			Item.autoReuse = true;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			// Add the Bleed buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.Bleeding, 60);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 3);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.SilverBar, 15);
			recipe.AddIngredient(ItemID.JungleRose, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
