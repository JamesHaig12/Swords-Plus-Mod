using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SwordsPlus.Items
{
    internal class MegaIronSkinPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Ironskin Potion");
            Tooltip.SetDefault("Grants The User +12 Defense");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(silver: 25);
            Item.buffType = ModContent.BuffType<Buffs.MegaIronSkinBuff>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 14400; // The amount of time the buff declared in Item.buffType will last in ticks. 14400 / 60 is 240, so this buff will last 240 seconds.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.IronskinPotion, 1);
            recipe.AddIngredient(ItemID.UnicornHorn, 5);
            recipe.AddIngredient(ItemID.PixieDust, 5);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.IronskinPotion, 1);
            recipe2.AddIngredient(ItemID.UnicornHorn, 5);
            recipe2.AddIngredient(ItemID.PixieDust, 5);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();
        }
    }
}
