using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using System;

namespace earthmod.Items.Sets.GraniteSet
{
    public class GraniteScanner_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scan Lines");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 526000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];
            target.AddBuff(ModContent.BuffType<GraniteScannerBuff>(), 60 * 4);
            target.AddBuff(BuffID.Frostburn, 60 * 4);
            int num = -1;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(player, false) && Main.npc[i] == target)
                {
                    num = i;
                }
            }
            {
                SoundEngine.PlaySound(SoundID.Item129, Projectile.position);
                player.MinionAttackTargetNPC = num;
                for (int d = 0; d < 5; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 150, Color.CornflowerBlue, 1f);
                }
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * .75f * Main.essScale);
            if (Main.rand.NextBool(5))
            {
                int dustnumber = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Flare_Blue, 0f, 0f, 150, Color.CornflowerBlue, 1f);
                Main.dust[dustnumber].velocity *= 0.3f;
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int d = 0; d < 4; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 150, Color.CornflowerBlue, 1f);
            }
            return base.OnTileCollide(oldVelocity);
        }
    }
}
