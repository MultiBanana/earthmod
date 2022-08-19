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
    public class InfantrySupplies : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infantry Supplies");
            Tooltip.SetDefault("'Full of various materials, tools, and... lunch!?'\n[c/B75754:Smells like potential.. it just needs a little spice]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = 1000;
            Item.maxStack = 99;
        }
    }
    
}
