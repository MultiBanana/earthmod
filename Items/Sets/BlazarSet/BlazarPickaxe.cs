using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace earthmod.Items.Sets.BlazarSet
{
    public class BlazarPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazar Pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SolarFlarePickaxe);
            base.SetDefaults();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D Texture = ModContent.Request<Texture2D>("earthmod/Items/Sets/BlazarSet/BlazarPickaxe_Glowmask").Value;
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
}