using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.ModLoader.Utilities;

namespace earthmod.NPCS.Oasis
{
    public class GildedOyster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.IceMimic];
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = .75f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.width = 14;
            NPC.height = 14;
            NPC.HitSound = SoundID.NPCHit42;
            NPC.DeathSound = SoundID.NPCDeath26;
            NPC.noGravity = false;

            NPC.aiStyle = 25;
            AIType = NPCID.IceMimic;
            AnimationType = NPCID.IceMimic;

            NPC.lifeMax = 45;
            NPC.defense = 8;

            NPC.damage = 25;
            NPC.value = 10600;

            base.SetDefaults();
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 15; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Sand, 1.5f * hitDirection, 1.5f, 0, Color.White);
            }

            if (NPC.life <= 0 &&(Main.netMode != NetmodeID.Server))
            {
                var EntitySource = NPC.GetSource_Death();

                int Gore1 = ModContent.Find<ModGore>("earthmod/GildedOyster_Gore_1"). Type;
                int Gore2 = ModContent.Find<ModGore>("earthmod/GildedOyster_Gore_2").Type;
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore1);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore2);
                base.HitEffect(hitDirection, damage);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.PinkPearl, 100));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.LuckCharm>(), 20));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.GildedPearls>(), 10));
            base.ModifyNPCLoot(npcLoot);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneDesert && spawnInfo.Water ? 0.75f : 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
                new FlavorTextBestiaryInfoElement("Sometimes, oysters grow large enough to hunt prey. This monster catches creatures in its jaws and crushes them into pearls.")
            });
            base.SetBestiary(database, bestiaryEntry);
        }
    }
}