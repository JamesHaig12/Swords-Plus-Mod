using Microsoft.Xna.Framework;
using SwordsPlus.Buffs;
using SwordsPlus.Items.Projectiles;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SwordsPlus.Items.Weapons
{
	public class ShieldSword : ModItem
	{

        public int Timer;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Of Protection"); // By default, capitalization in classnames will add spaces to the display name.
			Tooltip.SetDefault("<right> To Create A Ring Of Endurance At The Players Position"); // <right> calls the game to display whatever key is boud to user right click function
		}

		public override void SetDefaults()
		{
			Item.damage = 50; 
			Item.DamageType = DamageClass.Melee;
			Item.width = 40; 
			Item.height = 40;
            Item.useTime = 20; 
			Item.useAnimation = 20;  
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 87);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            // When user right clicks, altfunctionuse flips to true / 2
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            // Defaults for the sword
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shoot = ProjectileID.None;

            // If player right clicks and also doesnt have encumbered debuff, do this
            if (player.altFunctionUse == 2 && !player.HasBuff(ModContent.BuffType<Encumbered>()))
            {
                Item.useStyle = ItemUseStyleID.HoldUp;
                Item.useTime = 20;
                Item.useAnimation = 20;
                player.AddBuff(ModContent.BuffType<Encumbered>(), 1800);
                Item.shoot = ModContent.ProjectileType<ProtectionBubble>();                             
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            velocity.X = 0;
            velocity.Y = 0;
            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, velocity.X, velocity.Y, type, damage * 2, knockback, player.whoAmI);
            return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(); // Creates new recipe for Item
			recipe.AddIngredient(ItemID.DirtBlock, 100000); // Adds dirt blocks to recipe
			recipe.AddRecipeGroup("Wood", 1000000); // Special method to call all types of certain Item. E.g this calls all wood types rather than just oak wood
			recipe.AddTile(TileID.WorkBenches); // What tile the player needs to be near in order to craft Item
			recipe.Register(); // Initialises the recipe for actual use
		}
	}
}
