using System;
using Microsoft.Xna.Framework;
using SwordsPlus.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace SwordsPlus.Items.Weapons
{
    public class GreatswordOfTheRabbitKing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Greatsword Of The Rabbit King"); // By default, capitalization in classnames will add spaces to the display name.
            Tooltip.SetDefault("'The field... it's covered with blood!'\nCredits To AgentB90");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3;
            Item.value = 2500;
            Item.rare = ItemRarityID.Green;
            Item.crit = 12;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bunny, 30);
            recipe.AddIngredient<Items.SwordSoul>(5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
