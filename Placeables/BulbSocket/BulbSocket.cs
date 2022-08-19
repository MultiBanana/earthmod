using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.DataStructures;
using earthmod.Items.Materials;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace earthmod.Placeables.BulbSocket
{
    public class BulbSocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bulb Socket");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<BulbSocket_Tile>();
            base.SetDefaults();
        }
    }
	public class BulbSocket_Tile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Bulb Socket");
			AddMapEntry(new Color(0, 193, 255), name);
			DustType = 240;
			base.SetStaticDefaults();
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.155f * 1.8f;
			g = 0.215f * 1.8f;
			b = .4375f * 1.8f;
		}     

	public override void NearbyEffects(int i, int j, bool closer)
		{
			if (Main.rand.Next(255) == 1)
			{
				Dust.NewDustPerfect(new Vector2(i * 16, j * 16), 226, new Vector2(Main.rand.NextFloat(-1.5f, 1.5f), Main.rand.NextFloat(-1.5f, 1.5f)), 0, default, 0.8f).noGravity = true;
			}
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<GraniteBulb>());
		}
	}
}