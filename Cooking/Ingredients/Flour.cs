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
    public class Flour : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A versatile ingredient'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Hay, 10);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
            base.AddRecipes(); 
        }
    }
}
