using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using earthmod.Dusts;

namespace earthmod.NPCS.Oasis
{
    public class Lobster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lobster");
            Main.npcFrameCount[Type] = 4;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = .75f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 34;
           
            NPC.aiStyle = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.lifeMax = 120;
            NPC.defense = 14;


            NPC.damage = 40;

            base.SetDefaults();
        }
        private enum Frame
        {
            Walk1,
            Walk2,
            Walk3,
            Walk4
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            NPC.frameCounter++;

            if (NPC.frameCounter < 5)
            {
                NPC.frame.Y = (int)Frame.Walk1 * frameHeight;
            }
            else if (NPC.frameCounter < 10)
            {
                NPC.frame.Y = (int)Frame.Walk2 * frameHeight;
            }
            else if (NPC.frameCounter < 15)
            {
                NPC.frame.Y = (int)Frame.Walk3 * frameHeight;
            }
            else if (NPC.frameCounter < 20)
            {
                NPC.frame.Y = (int)Frame.Walk4 * frameHeight;
            }
            else
            {
                NPC.frameCounter = 0;
            }
        }
        public override void AI()
        {
            if (NPC.wet)
            {
                AIType = NPCID.CreatureFromTheDeep;
                NPC.noGravity = true;
            }
            else
            {
                AIType = NPCID.WalkingAntlion;
                NPC.noGravity = false;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 11; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<LobsterDust>(), hitDirection, -1f, 1, Color.White);
            }
            if (NPC.life <= 0 && (Main.netMode != NetmodeID.Server))
            {
                for (int k = 0; k < 11; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<LobsterDust>(), hitDirection, -1f, 1, Color.White);
                }
                var EntitySource = NPC.GetSource_Death();       
                
                int Gore1 = ModContent.Find<ModGore>("earthmod/Lobster_Gore_1").Type;
                int Gore2 = ModContent.Find<ModGore>("earthmod/Lobster_Gore_2").Type;
                int Gore3 = ModContent.Find<ModGore>("earthmod/Lobster_Gore_3").Type;
                int Gore4 = ModContent.Find<ModGore>("earthmod/Lobster_Gore_4").Type;
                int Gore5 = ModContent.Find<ModGore>("earthmod/Lobster_Gore_5").Type;

                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore1);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore2);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore3);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore4);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore5);

                base.HitEffect(hitDirection, damage);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
                new FlavorTextBestiaryInfoElement("When they grow large, lobsters become the second most dangerous creature in the Oasis waters. Their cuthroat claws can tear a Terrarian in two.")
            });
            base.SetBestiary(database, bestiaryEntry);
        }
    }


}