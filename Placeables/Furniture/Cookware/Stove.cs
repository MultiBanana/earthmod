using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.DataStructures;
using System;

namespace earthmod.Placeables.Furniture.Cookware
{
    public class Stove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electric Stove");
            Tooltip.SetDefault("Used for advanced cooking");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<Stove_Tile>();
            base.SetDefaults();
        }
    }
    public class Stove_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Electric Stove");
            AddMapEntry(new Color(136, 136, 160), name);
            DustType = DustID.Titanium;
            base.SetStaticDefaults();
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(255) == 1)
            {
                Dust.NewDustPerfect(new Vector2(i * 16, j * 16), DustID.Smoke, new Vector2(Main.rand.NextFloat(-1.5f, 1.5f), Main.rand.NextFloat(-1.5f, 1.5f)), 0, default, 0.8f).noGravity = true;
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<Stove>());
        }
    }
}