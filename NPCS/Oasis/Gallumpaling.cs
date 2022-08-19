using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace earthmod.NPCS.Oasis
{
    public class Gallumpaling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Arapaima];
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = .75f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.width = 56;
            NPC.height = 26;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.aiStyle = 16;
            AIType = NPCID.Piranha;
            AnimationType = NPCID.Piranha;
            NPC.noGravity = true;

            NPC.lifeMax = 40;
            NPC.defense = 8;
            NPC.knockBackResist = .5f;

            NPC.damage = 16;
            NPC.value = 110;
            
            base.SetDefaults();
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 11; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 1.5f * hitDirection, 1.5f, 0, Color.White);
            }
            if (NPC.life <= 0 && (Main.netMode != NetmodeID.Server))
            {
                var EntitySource = NPC.GetSource_Death();

                int Gore1 = ModContent.Find<ModGore>("earthmod/Gallumpaling_Gore_1").Type;
                int Gore2 = ModContent.Find<ModGore>("earthmod/Gallumpaling_Gore_2").Type;
                int Gore3 = ModContent.Find<ModGore>("earthmod/Gallumpaling_Gore_3").Type;
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore1);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore2);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore3);
                base.HitEffect(hitDirection, damage);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Amethyst, 5, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.Topaz, 5, 1, 3));

            npcLoot.Add(ItemDropRule.Common(ItemID.Sapphire, 10, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.Emerald, 10, 1, 3));

            npcLoot.Add(ItemDropRule.Common(ItemID.Ruby, 20, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.Amber, 20, 1, 3));

            npcLoot.Add(ItemDropRule.Common(ItemID.Diamond, 100, 1,3));
            base.ModifyNPCLoot(npcLoot);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneDesert && spawnInfo.Water ? 1.5f : 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
                new FlavorTextBestiaryInfoElement("These large fish hoard sediment and pearls which surface on the oasisbed.")
            });
            base.SetBestiary(database, bestiaryEntry);
        }
    }
}