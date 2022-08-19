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
    public class SpecialSpice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spice of Life");
            Tooltip.SetDefault("Bring the world of Terraria to life with cuisine!\n[c/B75754:Items with culinary potential will have a special tooltip]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 1000;
            Item.maxStack = 99;
        }
    }
}
