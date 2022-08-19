using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.DataStructures;

namespace earthmod.Items.Armor.Granite
{
    [AutoloadEquip(EquipType.Head)]
    public class GraniteSenpaiHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Hair Bulb");
            Tooltip.SetDefault("Provides light when worn\n'How cute!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
            Item.value = 3500;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GraniteSenpaiBody>() & legs.type == ModContent.ItemType<GraniteSenpaiLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "25% increased mining speed";
            player.pickSpeed *= 1.25f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GraniteBulb", 1);
            recipe.AddIngredient(ItemID.GraniteBlock, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void UpdateEquip(Player player)
        {
            Lighting.AddLight(player.position, .72f, .96f, 1f);
            base.UpdateEquip(player);
        }
    }
}
