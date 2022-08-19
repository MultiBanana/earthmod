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
    public class LunarScissors : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Scissors");
            Tooltip.SetDefault("Hold to increase running speed\n'Cutting edge technology'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Red;
            base.SetDefaults();
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<LunarScissorsBuff>(), 1);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EclipseScissors>(), 1);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            recipe.AddIngredient(ModContent.ItemType<Materials.BlazarFragment>(), 5);
            recipe.AddTile(TileID.BloomingHerbs);
            recipe.Register();
        }
    }
}