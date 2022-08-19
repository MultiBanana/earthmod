using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System;
using earthmod;


namespace earthmod.Items.Sets.GraniteSet
{
    public class GraniteTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Tablet");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            HeldItemLayer.RegisterDrawMethod(Type, GlowMagic.DrawSimpleItemGlowmaskOnPlayer);
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Magic;
            Item.width = 24;
            Item.height = 26;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 1500;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;

            Item.noMelee = true;
            Item.shoot = ProjectileID.ThunderSpearShot;
            Item.shootSpeed = 13f;
            Item.knockBack = 7f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(5 + Main.rand.Next(25));
            position += Vector2.Normalize(velocity) * 15f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1.25f;
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            spriteBatch.DrawSimpleItemGlowmaskInWorld(Item, Color.White, rotation, scale);
        }
    }
}

