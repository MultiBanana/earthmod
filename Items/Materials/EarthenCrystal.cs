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
    public class EarthenCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geobotride");
            Tooltip.SetDefault("'The source of that earthy smell'");
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Quest;
            Item.value = 500;
            Item.maxStack = 999;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.Goldenrod.ToVector3() * 0.55f * Main.essScale);
        }
    }
}