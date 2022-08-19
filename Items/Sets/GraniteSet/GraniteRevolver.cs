using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.DataStructures;

namespace earthmod.Items.Sets.GraniteSet
{
    public class GraniteRevolver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Revolver");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            HeldItemLayer.RegisterDrawMethod(Type, GlowMagic.DrawSimpleItemGlowmaskOnPlayer);
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item41;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 18;
            Item.knockBack = 4f;
            Item.crit = 5;

            Item.shoot = AmmoID.Bullet;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 16f;

            base.SetDefaults();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 2);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GraniteBulb", 1);
            recipe.AddIngredient(ItemID.Granite, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {      
            spriteBatch.DrawSimpleItemGlowmaskInWorld(Item, Color.White, rotation, scale);
        }
    }
}