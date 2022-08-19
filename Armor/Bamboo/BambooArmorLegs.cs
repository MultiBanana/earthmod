using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Armor.Bamboo
{
    [AutoloadEquip(EquipType.Legs)]
    public class BambooArmorLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bamboo Boots");
            Tooltip.SetDefault("4% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.04f;
            base.UpdateEquip(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BambooBlock, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
