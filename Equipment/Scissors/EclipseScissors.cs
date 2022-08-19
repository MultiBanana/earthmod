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
    public class EclipseScissors : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipse Scissors");
            Tooltip.SetDefault("Hold to increase running speed\nHolding sharp objects increases damage taken\n'Snip and tear'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Yellow;
            base.SetDefaults();
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<EclipseScissorsBuff>(), 1);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SharpScissors>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.Patchwork>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}