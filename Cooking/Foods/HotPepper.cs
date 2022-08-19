using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.GameContent.ItemDropRules;

namespace earthmod.Cooking.Foods
{
    public class HotPepper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hot Pepper");
            Tooltip.SetDefault("Minor improvements to all stats\n'That's the spice'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Orange;
            Item.value = 3500;
            Item.maxStack = 30;

            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.UseSound = SoundID.Item2;

            Item.consumable = true;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 36000;
        }
    }
}
