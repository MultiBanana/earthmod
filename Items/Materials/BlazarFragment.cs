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
    public class BlazarFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazar Fragment");
            Tooltip.SetDefault("'Dynamic particles ricochet throughout this fragment'");
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Cyan;
            Item.value = 2000;
            Item.maxStack = 999;
        }
        public override void PostUpdate()
        {
            Color BlazarColor = new Color(200, 226, 52);
            Lighting.AddLight(Item.Center, BlazarColor.ToVector3() * .55f * Main.essScale);
            base.PostUpdate();
        }
        public override Color? GetAlpha(Color lightColor) => Color.White;
    }
}