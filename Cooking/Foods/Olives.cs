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
    public class Olives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olives");
            Tooltip.SetDefault("Medium improvements to all stats\n'...You're sure this is a fruit?'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
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
            Item.buffType = BuffID.WellFed2;
            Item.buffTime = 36000;
        }
    }
}
