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
    [AutoloadEquip(EquipType.Body)]
    public class BlazarArmorBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazar Blazer");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.defense = 32;
            Item.rare = ItemRarityID.Red;
            Item.value = 140000;
            Color BlazarColor = new Color(200, 226, 52);
            Lighting.AddLight(Item.position, BlazarColor.ToVector3() * .55f * Main.essScale);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.BlazarFragment>(), 20);
            recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D Texture = ModContent.Request<Texture2D>("earthmod/Golfer/Armor/Blazar/BlazarArmorBody_Glowmask").Value;
            spriteBatch.Draw
            (
                Texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - Texture.Height * 0.5f
                ),
                new Rectangle(0, 0, Texture.Width, Texture.Height),
                Color.White,
                rotation,
                Texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );

            base.PostDrawInWorld(spriteBatch, lightColor, alphaColor, rotation, scale, whoAmI);
        }
        public override void PostUpdate()
        {
            Color BlazarColor = new Color(200, 226, 52);
            Lighting.AddLight(Item.Center, BlazarColor.ToVector3() * .55f * Main.essScale);
            base.PostUpdate();
        }
    }

    public class BlazarArmorBodyGlow : ModPlayer
    {
        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            var BlazarArmorBody = ModContent.GetInstance<BlazarArmorBody>();
            if (drawInfo.drawPlayer.body == EquipLoader.GetEquipSlot(Mod, BlazarArmorBody.Name, EquipType.Body))
            {
                Color color = Color.White;
                drawInfo.bodyGlowColor = color;
                drawInfo.armGlowColor = color;

                Color BlazarColor = new Color(200, 226, 52);
                Lighting.AddLight(Player.Center, BlazarColor.ToVector3() * .55f * Main.essScale);
            }
        }
    }
}