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
    [AutoloadEquip(EquipType.Body)]
    public class BambooArmorBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bamboo Breastplate");
            Tooltip.SetDefault("Damage increased by 2");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic).Flat += 2;
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BambooBlock, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
