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
    [AutoloadEquip(EquipType.Head)]
    public class BambooArmorHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bamboo Mask");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BambooArmorBody>() & legs.type == ModContent.ItemType<BambooArmorLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You can see the location of nearby threats";
            player.detectCreature = true;
            player.dangerSense = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BambooBlock, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}