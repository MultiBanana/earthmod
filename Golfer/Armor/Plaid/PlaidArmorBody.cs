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
    [AutoloadEquip(EquipType.Body)]
    public class PlaidArmorBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caddie Vest");
            Tooltip.SetDefault("Golfing damage increased by 2");
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
            Item.value = 400;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage<GolferDamage.GolferDamage>().Flat += 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.Plaid>(), 16);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
