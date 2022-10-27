using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;

namespace SwordsPlus.Items
{
    public class SwordSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword Soul");
            Tooltip.SetDefault("Melee Energy Radiates From Within");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4)); // Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the item have an animation while in world (not held.). Use in combination with RegisterItemAnimation

            ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory
            ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this item that's needed to research it in Journey mode.
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 999;
            Item.value = 1000; // Makes the item worth 1 gold.
            Item.rare = ItemRarityID.Orange;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale); // Makes this item glow when thrown out of inventory.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.CopperOre, 2);
            recipe.AddIngredient(ItemID.GoldOre, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(4);
            recipe2.AddIngredient(ItemID.CopperOre, 2);
            recipe2.AddIngredient(ItemID.SilverOre, 2);
            recipe2.AddTile(TileID.Furnaces);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe(4);
            recipe3.AddIngredient(ItemID.TinOre, 2);
            recipe3.AddIngredient(ItemID.GoldOre, 2);
            recipe3.AddTile(TileID.Furnaces);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe(4);
            recipe4.AddIngredient(ItemID.TinOre, 2);
            recipe4.AddIngredient(ItemID.SilverOre, 2);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.Register();
        }

    }
}
