using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FinesseHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Finesse Hat");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 4;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return false;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.dash = 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}
