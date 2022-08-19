using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.DataStructures;

namespace earthmod.Items.Weapons
{
    public class PhoenixRevolver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Dueler");
            Tooltip.SetDefault("Fires two shots in quick succession");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Orange;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.useAnimation = 28;
            Item.useTime = 14;
            Item.UseSound = SoundID.Item41;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 28;
            Item.knockBack = 3f;
            Item.crit = 8;
            Item.scale = .9f;        
            Item.shootSpeed = 16f;
            Item.shoot = AmmoID.Bullet;
            Item.useAmmo = AmmoID.Bullet;
            base.SetDefaults();

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 2);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.Revolver);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}