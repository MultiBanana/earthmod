using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Sets.GraniteSet
{
    public class GraniteHatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Energy Hatchet");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.rare = ItemRarityID.Blue;

            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.damage = 25;
            Item.knockBack = 3f;

            Item.UseSound = SoundID.Item15;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.shoot = ModContent.ProjectileType<GraniteHatchet_Projectile>();
            Item.shootSpeed = 4f;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GraniteBulb", 5);
            recipe.AddIngredient(ItemID.Granite, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[Item.shoot] > 0)
            {
                return false;
            }
            return base.CanUseItem(player);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            spriteBatch.DrawSimpleItemGlowmaskInWorld(Item, Color.White, rotation, scale);
        }
    }
    public class GraniteHatchet_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Hatchet");
        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 36;
            Projectile.aiStyle = ProjAIStyleID.Boomerang;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 526000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void PostDraw(Color lightColor)
        {
            Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * .5f * Main.essScale);
            Texture2D texture = ModContent.Request<Texture2D>("earthmod/Items/Sets/GraniteSet/GraniteHatchet_Projectile_Glowmask").Value;
            GlowMagic.DrawProjectileGlowmask(Projectile, Main.spriteBatch, texture, Color.White);
        }
    }
}