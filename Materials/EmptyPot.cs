using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Materials
{
    [AutoloadEquip(EquipType.Head)]
    public class EmptyPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empty Pot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.White;
            Item.value = 30;
            Item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ClayBlock, 8);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}