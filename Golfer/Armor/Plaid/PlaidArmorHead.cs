using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Golfer.Armor.Plaid
{
    [AutoloadEquip(EquipType.Head)]
    public class PlaidArmorHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caddie Visor");
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
            Item.value = 500;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PlaidArmorBody>() & legs.type == ModContent.ItemType<PlaidArmorLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases golfing damage by 2";
            player.GetDamage<GolferDamage.GolferDamage>().Flat += 2;
        }
        public override void UpdateEquip(Player player)
        {
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.Plaid>(), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
