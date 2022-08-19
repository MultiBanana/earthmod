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
	public class GraniteScanner : ModItem
	{

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Scanner");
			Tooltip.SetDefault("8 summon tag damage\nFires a burning scanning beam\nYour summons will focus scanned enemies");
			HeldItemLayer.RegisterDrawMethod(Type, GlowMagic.DrawSimpleItemGlowmaskOnPlayer);
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Summon;
			Item.width = 24;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 2000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item12;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<GraniteScanner_Projectile>();
			Item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Granite, 20);
			recipe.AddIngredient(Mod, "GraniteBulb", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			spriteBatch.DrawSimpleItemGlowmaskInWorld(Item, Color.White, rotation, scale);
		}
	}
}