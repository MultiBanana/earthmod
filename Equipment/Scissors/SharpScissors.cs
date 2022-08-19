using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Equipment.Scissors
{
    public class SharpScissors : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharp Scissors");
            Tooltip.SetDefault("Hold to increase running speed\nHolding sharp objects increases damage taken\n'Always be careful when handling sharp objects.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Blue;
            base.SetDefaults();
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<SharpScissorsBuff>(), 1);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("earthmod:SilverBar", 10);
            recipe.AddRecipeGroup("earthmod:EvilBar", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}