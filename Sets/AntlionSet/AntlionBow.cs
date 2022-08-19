using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.DataStructures;

namespace earthmod.Items.Sets.AntlionSet
{
    public class AntlionBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mandible Bow");
            Tooltip.SetDefault("Fires quick, inaccurate arrows");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item5;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 6;
            Item.knockBack = 2f;

            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 6.5f;
            base.SetDefaults();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}