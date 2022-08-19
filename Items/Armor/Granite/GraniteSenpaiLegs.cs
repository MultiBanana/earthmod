using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Armor.Granite
{
    [AutoloadEquip(EquipType.Legs)]
    public class GraniteSenpaiLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Pants");
            Tooltip.SetDefault("'Proper, yet comfortable'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 5;
            Item.value = 2100;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GraniteBulb", 3);
            recipe.AddIngredient(ItemID.GraniteBlock, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void PostUpdate()
        {
            Color GraniteColor = new Color(184, 247, 255);
            Lighting.AddLight(Item.Center, GraniteColor.ToVector3() * .20f * Main.essScale);
            base.PostUpdate();
        }
    }
}
