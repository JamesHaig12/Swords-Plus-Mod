using IL.Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SwordsPlus.Items.Weapons
{
	public class TeleportSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenon-54"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("Really messes with your head\nInspired By Az");
		}

		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 70;
			Item.useAnimation = 70;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = ItemRarityID.Orange;
            Item.crit = 8;
            Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TeleportProjectile>();
			Item.shootSpeed = 10f;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Wood", 20);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.MagicMirror, 1);
            recipe.AddTile(TileID.Anvils); 
			recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddRecipeGroup("Wood", 20);
            recipe2.AddIngredient(ItemID.GoldBar, 10);
            recipe2.AddIngredient(ItemID.Diamond, 10);
            recipe2.AddIngredient(ItemID.MagicMirror, 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
	}
}
