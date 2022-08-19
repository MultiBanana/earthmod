using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System;

namespace earthmod.Items.Accessories
{
    public class LuckCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearl Beads");
            Tooltip.SetDefault("Increases luck");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 20;
            Item.height = 20;
            Item.value = 500;
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.luck += .03f;
        }
    }
}
