using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Armor.Antlion
{
    [AutoloadEquip(EquipType.Legs)]
    public class AntlionArmorLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Boots");
            Tooltip.SetDefault("3% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 1;
            Item.value = 400;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.03f;
    }

     

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
