using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Cooking.Equipables
{
    [AutoloadEquip(EquipType.Head)]
    public class PlaidChefHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaid Chef Hat");
            Tooltip.SetDefault("'Smells like dirt.. the most natural spice of all'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.vanity = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "Plaid", 20);
            recipe.AddIngredient(Mod, "SpecialSpice", 1);
            recipe.AddTile(TileID.Loom);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
        }
    }
}
