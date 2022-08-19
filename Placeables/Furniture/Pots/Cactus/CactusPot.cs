using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.DataStructures;
using System;


namespace earthmod.Placeables.Furniture.Pots.Cactus
{
    public class CactusPot1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Pot");
            Tooltip.SetDefault("'Doesn't need water!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<CactusPot1_Tile>();
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            Recipe recipe2 = CreateRecipe();
            Recipe recipe3 = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.EmptyPot>(), 1);
            recipe.AddIngredient(ItemID.Cactus, 1);
            recipe.Register();
            CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CactusPot2>(), 1);
            recipe2.Register();
            CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<CactusPot3>(), 1);
            recipe3.Register();
        }
    }
    public class CactusPot1_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Decorative Pot");
            AddMapEntry(new Color(90, 47, 47), name);
            DustType = DustID.Pot;
            base.SetStaticDefaults();
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<CactusPot1>());
        }
    }
    //
    public class CactusPot2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Pot");
            Tooltip.SetDefault("'Doesn't need water!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<CactusPot2_Tile>();
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            Recipe recipe2 = CreateRecipe();
            Recipe recipe3 = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.EmptyPot>(), 1);
            recipe.AddIngredient(ItemID.Cactus, 1);
            recipe.Register();
            CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CactusPot1>(), 1);
            recipe2.Register();
            CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<CactusPot3>(), 1);
            recipe3.Register();
        }
    }
    public class CactusPot2_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Decorative Pot");
            AddMapEntry(new Color(90, 47, 47), name);
            DustType = DustID.Pot;
            base.SetStaticDefaults();
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<CactusPot2>());
        }
    }
    public class CactusPot3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Pot");
            Tooltip.SetDefault("'Doesn't need water!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<CactusPot3_Tile>();
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            Recipe recipe2 = CreateRecipe();
            Recipe recipe3 = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.EmptyPot>(), 1);
            recipe.AddIngredient(ItemID.Cactus, 1);
            recipe.Register();
            CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CactusPot1>(), 1);
            recipe2.Register();
            CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<CactusPot3>(), 1);
            recipe3.Register();
        }
    }
    public class CactusPot3_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Decorative Pot");
            AddMapEntry(new Color(90, 47, 47), name);
            DustType = DustID.Pot;
            base.SetStaticDefaults();
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<CactusPot3>());
        }
    }
}