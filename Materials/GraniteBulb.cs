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
    public class GraniteBulb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Bulb");
            Tooltip.SetDefault("'Leaking with energizing juices'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
            Item.maxStack = 99;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.CornflowerBlue.ToVector3() * 0.55f * Main.essScale);
        }
    }
}