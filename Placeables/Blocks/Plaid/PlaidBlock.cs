using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace earthmod.Placeables.Blocks.Plaid
{
    public class PlaidBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaid Block");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = TileType<PlaidBlock_Tile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(Mod, "Plaid", 1);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

            var resultItem = ModContent.GetInstance<PlaidBlock>();

            resultItem.CreateRecipe()
            .AddIngredient(Mod, "PlaidWall", 4)
            .Register();
            base.AddRecipes();
        }
    }
    public class PlaidBlock_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            ItemDrop = ModContent.ItemType<PlaidBlock>();

            AddMapEntry(new Color(175, 10, 16));
            DustType = DustID.WoodFurniture;
        }
    }
}
