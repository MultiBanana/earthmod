using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Cooking.Ingredients
{
    public class Sugar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A versatile ingredient'\nCan be consumed on its own");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.value = 550;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.UseSound = SoundID.Item2;

            Item.consumable = true;
            Item.buffType = BuffID.SugarRush;
            Item.buffTime = 900;
        }

        public override void AddRecipes()
        {
            Recipe recipe =
            CreateRecipe();
            recipe.AddRecipeGroup("Fruit", 2);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
            base.AddRecipes();

            var resultItem = ModContent.GetInstance<Cooking.Ingredients.Sugar>();

            resultItem.CreateRecipe()
            .AddIngredient(ItemID.HoneyBlock, 2)
            .AddTile(TileID.CookingPots)
            .Register();
            base.AddRecipes();

            resultItem.CreateRecipe()
            .AddIngredient(ItemID.BottledHoney, 1)
            .AddTile(TileID.CookingPots)
            .Register();
            base.AddRecipes();
        }
    }
}
