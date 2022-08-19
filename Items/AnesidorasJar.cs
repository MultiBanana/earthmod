using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items
{
    public class AnesidorasJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anesidora's Jar");
            Tooltip.SetDefault("Contains anything and everything");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Quest;
            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.shoot = ModContent.ProjectileType<Items.AnesidorasJar_Projectile>();
            Item.shootSpeed = 6.5f;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "EarthenGlass", 5);
            recipe.AddTile(ModContent.TileType<Placeables.Furniture.Earthen.EarthenAnvil_Tile>());
            recipe.Register();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            for (int d = 0; d < 2; d++)
            {
                Dust.NewDust(Item.position, Item.width, Item.height, DustID.GoldCoin, 0f, -1f, 150, Color.Gold, .5f);
            }
            base.PostDrawInWorld(spriteBatch, lightColor, alphaColor, rotation, scale, whoAmI);
        }    
    }
    public class AnesidorasJar_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anesidora's Jar");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = ProjAIStyleID.ThrownProjectile;
            Projectile.timeLeft = 5000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void PostDraw(Color lightColor)
        {
            Lighting.AddLight(Projectile.Center, Color.Goldenrod.ToVector3() * 1.5f * Main.essScale);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            if (Main.rand.Next(10) == 1)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath10, Projectile.position);
                for (int d = 0; d < 100; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeStainedGlass, 0f, -1f, 150, Color.Crimson, 1f);
                }
            }
            else
            {
                for (int d = 0; d < 100; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeStainedGlass, 0f, -1f, 150, Color.Goldenrod, 1f);
                }
            }
            return base.OnTileCollide(oldVelocity);
        }
    }
}