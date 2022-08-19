using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using earthmod.Golfer;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace earthmod.Golfer.Bags
{
    public class TestBag : GolferBagItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Bag");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;

            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 30;
            Item.knockBack = 1f;
            Item.shoot = ModContent.ProjectileType<TestBag_Projectile>();
            Item.shootSpeed = 6.5f;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            damage = Item.damage;
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
    public class TestBag_Projectile : GolferProjectile
    {
        public int TestBag_Damage = ModContent.ItemType<TestBag>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Ball");

            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Projectile.owner = Main.myPlayer;
            Projectile.aiStyle = 149;
            Projectile.netImportant = true;
            Projectile.width = 7;
            Projectile.height = 7;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }
    }
}