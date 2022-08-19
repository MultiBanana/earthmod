using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.DataStructures;

namespace earthmod.Golfer.Armor.Blazar
{
    [AutoloadEquip(EquipType.Head)]
    public class BlazarArmorHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazar Visage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Red;
            Item.defense = 24;
            Item.value = 70000;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BlazarArmorBody>() & legs.type == ModContent.ItemType<BlazarArmorLegs>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.BlazarFragment>(), 10);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
    public class BlazarArmorHeadGlow : ModPlayer
    {
        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            var BlazarArmorHead = ModContent.GetInstance<BlazarArmorHead>();

            if (drawInfo.drawPlayer.head == EquipLoader.GetEquipSlot(Mod, BlazarArmorHead.Name, EquipType.Head))
            {
                Color BlazarColor = new Color(200, 226, 52);
                Lighting.AddLight(Player.Center, BlazarColor.ToVector3() * .55f * Main.essScale);
            }
        }
    }
}
