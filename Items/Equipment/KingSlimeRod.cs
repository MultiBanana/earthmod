using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;

namespace earthmod.Items.Equipment
{
    public class KingSlimeRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Catcher");
            Tooltip.SetDefault("Reels up slimes with loot inside");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.fishingPole = 30;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<KingSlimeRodBobber>();
        }
    }
    public class KingSlimeRodBobber : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Bobber");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 61;
            Projectile.bobber = true;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            DrawOriginOffsetY = -6;
        }
        public override void ModifyFishingLine(ref Vector2 lineOriginOffset, ref Color lineColor)
        {
            lineOriginOffset = new Vector2(47, -31);
            lineColor = new Color(32, 81, 181);
        }
    }
    public class KingSlimeRodFishingEvent : ModPlayer
    {
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            int TreasureSlime;
            {
                if (Main.player[Main.myPlayer].ZoneDesert)
                {
                    TreasureSlime = NPCID.SandSlime;
                }
                else if (Main.player[Main.myPlayer].ZoneSnow)
                {
                    TreasureSlime = NPCID.IceSlime;
                }
                else if (Main.player[Main.myPlayer].ZoneRockLayerHeight)
                {
                    TreasureSlime = NPCID.BlackSlime;
                }
                else if (Main.player[Main.myPlayer].ZoneJungle)
                {
                    TreasureSlime = NPCID.JungleSlime;
                }
                else
                {
                    TreasureSlime = NPCID.BlueSlime;
                }
            };
            bool inWater = !attempt.inLava && !attempt.inHoney;
            if (attempt.playerFishingConditions.PoleItemType == ModContent.ItemType<KingSlimeRod>() && inWater)
            {     
                npcSpawn = TreasureSlime;
                itemDrop = -1;
                return;
            }
            if (attempt.playerFishingConditions.PoleItemType == ModContent.ItemType<KingSlimeRod>() && attempt.inLava)
            {
                npcSpawn = NPCID.LavaSlime;
                itemDrop = -1;
                return;
            }
            if (attempt.playerFishingConditions.PoleItemType == ModContent.ItemType<KingSlimeRod>() && attempt.inHoney)
            {
                npcSpawn = NPCID.SpikedJungleSlime;
                itemDrop = -1;
                return;
            }
        }
    }

    //
    public class KingSlimeFishingNPC : GlobalNPC
    {
        public int GenerateItemInsideBody()
        {
            // GenerateItemInsideBody() is essentially a clone of AI_001_Slimes_GenerateItemInsideBody() in Main.NPC //;

            int num = Main.rand.Next(4);
            switch (num)
            {
                case 0:
                    switch (Main.rand.Next(7))
                    {
                        case 0:
                            return 290;
                        case 1:
                            return 292;
                        case 2:
                            return 296;
                        case 3:
                            return 2322;
                        default:
                            if (Main.netMode != 0 && Main.rand.NextBool(2))
                            {
                                return 2997;
                            }
                            return 2350;
                    }
                case 1:
                    return Main.rand.Next(4) switch
                    {
                        0 => 8,
                        1 => 166,
                        2 => 965,
                        _ => 58,
                    };
                case 2:
                    if (Main.rand.NextBool(2))
                    {
                        return Main.rand.Next(11, 15);
                    }
                    return Main.rand.Next(699, 703);
                default:
                    return Main.rand.Next(3) switch
                    {
                        0 => 71,
                        1 => 72,
                        _ => 73,
                    };
            }
        }
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (source is EntitySource_FishedOut)
            {
                if (npc.type == NPCID.BlueSlime)
                {
                    npc.ai[1] = GenerateItemInsideBody();
                }
                if (npc.type == NPCID.PurpleSlime)
                {
                    npc.ai[1] = GenerateItemInsideBody();
                }
                if (npc.type == NPCID.JungleSlime)
                {   
                    npc.ai[1] = GenerateItemInsideBody();
                }
                if (npc.type == NPCID.BlackSlime)
                {
                    npc.ai[1] = GenerateItemInsideBody();
                }
            }
            base.OnSpawn(npc, source);
        }
    }
    public class KingSlimeRodBag : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.KingSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeRod>(), 4));
            }
            base.ModifyItemLoot(item, itemLoot);
        }
    }

    public class KingSlimeRodDrop : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.KingSlime && !Main.expertMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingSlimeRod>(), 4));
            }
        }
    }
}