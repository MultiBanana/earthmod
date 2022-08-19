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
    [AutoloadEquip(EquipType.Body)]
    public class AntlionArmorBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Chestplate");
            Tooltip.SetDefault("2% increased movement speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
            Item.value = 500;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.02f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionMandible, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
