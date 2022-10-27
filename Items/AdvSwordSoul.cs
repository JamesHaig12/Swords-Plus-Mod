using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;

namespace SwordsPlus.Items
{
    public class AdvSwordSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Sword Soul");
            Tooltip.SetDefault("'I swear the souls just merged together!'");

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
            Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.8f * Main.essScale); // Makes this item glow when thrown out of inventory.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient<Items.SwordSoul>(2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }

    }
}
