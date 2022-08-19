using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ObjectData;
using Terraria.Enums;
using System;

namespace earthmod.Placeables.Furniture.Earthen
{
    public class EarthenChalice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Chalice");
            Tooltip.SetDefault("'Comes pre-filled'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.Quest;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<EarthenChalice_Tile>();
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.EarthenCrystal>(), 10);
            recipe.AddTile(ModContent.TileType<EarthenAnvil_Tile>());
            recipe.Register();
        }
    }
    public class EarthenChalice_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileLighted[Type] = true;
            ItemDrop = ModContent.ItemType<EarthenChalice>();
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Earthen Chalice");
            AddMapEntry(new Color(204, 132, 55), name);
            DustType = DustID.WoodFurniture;
            base.SetStaticDefaults();
        }
    }
}