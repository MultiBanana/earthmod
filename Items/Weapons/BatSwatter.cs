using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.Enums;

namespace earthmod.Items.Weapons
{
    public class BatSwatter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bat Swatter");
            Tooltip.SetDefault("Deals immense damage to bats, not much to everything else");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Orange;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.damage = 5;
            Item.UseSound = SoundID.Item1;

            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 5f;
            base.SetDefaults();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type == NPCID.CaveBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.JungleBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.IceBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.SporeBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.Hellbat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.GiantBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.IlluminantBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.GiantFlyingFox)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.Lavabat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            else if (target.type == NPCID.VampireBat)
            {
                target.life = 1;
                target.AddBuff(BuffID.Venom, 60);
            }
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }

    public class BatSwatterShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.SkeletonMerchant)
            {
                if (!Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BatSwatter>());
                    nextSlot++;
                }
                else if (Main.hardMode && Main.moonPhase == 0)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BatSwatter>());
                    nextSlot++;
                }
            }
            base.SetupShop(type, shop, ref nextSlot);
        }
    }
}
