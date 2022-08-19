using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Audio;
using Terraria.ModLoader.Utilities;
using System;

namespace earthmod.NPCS
{
    public class Woody : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stumpling");
            Main.npcFrameCount[Type] = 6;
            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                PortraitPositionYOverride = -25f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifier);
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            NPC.width = 48;
            NPC.height = 32;
            NPC.HitSound = SoundID.NPCHit11;
            NPC.DeathSound = SoundID.NPCDeath27;
            NPC.lifeMax = 95;
            NPC.knockBackResist = 0;
            NPC.damage = 16;
            NPC.value = 265;

            base.SetDefaults();
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RichMahogany, 1.5f * hitDirection, 1.5f, 0, Color.White);
            }
            if (NPC.life <= 0 && (Main.netMode != NetmodeID.Server))
            {
                var EntitySource = NPC.GetSource_Death();

                int Gore1 = ModContent.Find<ModGore>("earthmod/Woody_Gore_1").Type;
                int Gore2 = ModContent.Find<ModGore>("earthmod/Woody_Gore_2").Type;
                int Gore3 = ModContent.Find<ModGore>("earthmod/Woody_Gore_3").Type;
                int Gore4 = ModContent.Find<ModGore>("earthmod/Woody_Gore_4").Type;
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore1);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore2);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore3);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore4);
                Gore.NewGore(EntitySource, NPC.position, NPC.velocity, Gore4);
                base.HitEffect(hitDirection, damage);
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.RichMahogany, 1, 5, 15));
            npcLoot.Add(ItemDropRule.Common(ItemID.Vine, 2, 1, 2));
            base.ModifyNPCLoot(npcLoot);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneJungle && spawnInfo.Player.ZoneRockLayerHeight ? .75f : 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                new FlavorTextBestiaryInfoElement("These territorial stumps use their leafy propellers to float, smashing down when the time is right. In their free time they like to stack on top of each other.")
            });
            base.SetBestiary(database, bestiaryEntry);
        }

        //AI SECTION

        private enum Phase
        {
            Hover,
            Descent,
            Rest
        }
        public ref float AI_State => ref NPC.ai[0];
        public ref float FallTimer => ref NPC.ai[1];
        private enum Frame
        {
            Hover1,
            Hover2,
            Hover3,
            Hover4,
            Descend,
            Rest
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            switch (AI_State)
            {
                case (float)Phase.Hover:
                {
                        NPC.frameCounter++;

                        if (NPC.frameCounter < 5)
                        {
                            NPC.frame.Y = (int)Frame.Hover1 * frameHeight;
                        }
                        else if (NPC.frameCounter < 10)
                        {
                            NPC.frame.Y = (int)Frame.Hover2 * frameHeight;
                        }
                        else if (NPC.frameCounter < 15)
                        {
                            NPC.frame.Y = (int)Frame.Hover3 * frameHeight;
                        }
                        else if (NPC.frameCounter < 20)
                        {
                            NPC.frame.Y = (int)Frame.Hover4 * frameHeight;
                        }
                        else
                        {
                            NPC.frameCounter = 0;
                        }

                    }
                    break;
                case (float)Phase.Descent:
                    NPC.frame.Y = (int)Frame.Descend * frameHeight;
                    break;
                case (float)Phase.Rest:
                    NPC.frame.Y = (int)Frame.Rest * frameHeight;
                    break;
            }
        }
        public override bool? CanFallThroughPlatforms()
        {
            return true;
        }

        public override void AI()
        {
            switch (AI_State)
            {
                case (float)Phase.Hover:
                    Hover();
                    break;
                case (float)Phase.Descent:
                    Descent();
                    break;
                case (float)Phase.Rest:
                    Rest();
                    break;
            }
        }
        private void Hover()
        {
            NPC.defense = 999;
            NPC.noGravity = true;
            NPC.TargetClosest();
            float num767 = 4f;
            float num768 = 0.25f;
            Vector2 vector94 = new Vector2(NPC.Center.X, NPC.Center.Y);
            float num769 = Main.player[NPC.target].Center.X - vector94.X;
            float num770 = Main.player[NPC.target].Center.Y - vector94.Y - 175f;
            float num771 = (float)Math.Sqrt(num769 * num769 + num770 * num770);
            if (num771 < 20f)
            {
                num769 = NPC.velocity.X;
                num770 = NPC.velocity.Y;
            }
            else
            {
                num771 = num767 / num771;
                num769 *= num771;
                num770 *= num771;
            }


            if (NPC.velocity.Y < num770)
            {
                NPC.velocity.Y += num768;
                if (NPC.velocity.Y < 0f && num770 > 0f)
                {
                    NPC.velocity.Y += num768 * 2f;
                }
            }
            else if (NPC.velocity.Y > num770)
            {
                NPC.velocity.Y -= num768;
                if (NPC.velocity.Y > 0f && num770 < 0f)
                {
                    NPC.velocity.Y -= num768 * 2f;
                }
            }
            if (NPC.position.X + (float)NPC.width > Main.player[NPC.target].position.X && NPC.position.X < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width
               && NPC.position.Y + (float)NPC.height < Main.player[NPC.target].position.Y - 75
               && NPC.velocity.Y < 1
               && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && Main.netMode != 1)
            {
                AI_State = (float)Phase.Descent;
                SoundEngine.PlaySound(SoundID.NPCHit14, NPC.position);
            }
        }
        private void Descent()
        {
            NPC.noGravity = false;
            NPC.defense = 999;
            if (NPC.velocity.Y < 6)
            {
                NPC.velocity.Y += .5f;
            }
            else if (NPC.velocity.Y < 6)
            {
                NPC.velocity.Y = 6;
            }
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.JunglePlants, 0, -1, 0, Color.White);
            }
            if (NPC.collideY)
            {
                SoundEngine.PlaySound(SoundID.Dig, NPC.position);
                for (int k = 0; k < 5; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.RichMahogany, 1, 1, 0, Color.White);
                }
                AI_State = (float)Phase.Rest;
            }
        }
        private void Rest()
        {
            NPC.defense = 5;
            NPC.velocity = new Vector2(0, 0);
            FallTimer++;
            if (FallTimer > 100)
            {
                AI_State = (float)Phase.Hover;
                FallTimer = 0;
            }
        }
    }
}
   