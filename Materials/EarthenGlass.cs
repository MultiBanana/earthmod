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
    public class EarthenGlass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mercurian Glass");
            Tooltip.SetDefault("Through this glass, the world looks much less safe");
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
    }
}