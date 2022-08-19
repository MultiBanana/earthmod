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


namespace earthmod.Items.Weapons
{
    public class EclipseBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of Haunting");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 18;
            Item.width = 24;
            Item.height = 26;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 1500;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item20;

            Item.noMelee = true;
            Item.shoot = ProjectileID.DD2FlameBurstTowerT2Shot;
            Item.shootSpeed = 10f;
            Item.knockBack = 7f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 4;
            float rotation = MathHelper.ToRadians(15 - Main.rand.Next(10));
            position += Vector2.Normalize(velocity) * 15f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1.25f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}

