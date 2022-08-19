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
    [AutoloadEquip(EquipType.Head)]
    public class AntlionArmorHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Helmet");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
            Item.value = 400;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AntlionArmorBody>() & legs.type == ModContent.ItemType<AntlionArmorLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Damage increased by 3";
            player.GetDamage(DamageClass.Generic).Flat += 3;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionMandible, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
