using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.GameContent.Golf;
using Terraria.ID;

namespace earthmod.Golfer
{
    public abstract class GolferProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Type] = 1;
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.IsAGolfBall[Type] = true;
            base.SetStaticDefaults();
        }

        // AI SECTION
        // FUCK THIS, MAN
        /*private enum Phase
        {
            Resting,
            Moving
        }
		public ref float AI_State => ref Projectile.ai[0];

		private void Resting()
        {

        }
		private void Moving()
        {

        }
		public override void AI()
        {
			if (!Projectile.npcProj && Projectile.timeLeft < 10)
			{
				Projectile.timeLeft = 10;
			}
			if (Projectile.ai[1] == -1f)
			{
				Tile tileSafely = Framing.GetTileSafely(Projectile.Bottom.ToTileCoordinates());
				if (!tileSafely.active() || tileSafely.type != 494)
				{
					Projectile.ai[1] = 0f;
					Projectile.netUpdate = true;
				}
				return;
			}
			BallStepResult ballStepResult = GolfHelper.StepGolfBall(Projectile, ref Projectile.localAI[0]);
			if (ballStepResult.State == BallState.Resting)
			{
				Projectile.damage = 0;
				if (Main.netMode == 1 && Projectile.owner == Main.myPlayer && Projectile.localAI[1] != (float)ballStepResult.State)
				{
					Projectile.netUpdate = true;
				}
			}
			Projectile.localAI[1] = (float)ballStepResult.State;
			Projectile.rotation += Projectile.localAI[0];
			if (Projectile.velocity.Y != 0f && ballStepResult.State == BallState.Moving)
			{
				Projectile.rotation += Projectile.velocity.X * 0.1f + Projectile.velocity.Y * 0.1f;
			}
			if (ballStepResult.State == BallState.Moving && Projectile.owner == Main.myPlayer)
			{
				bool? flag = ProjectileID.Sets.ForcePlateDetection[135];
				if ((!flag.HasValue || flag.Value) && Projectile.localAI[1] != 0f)
				{
					Collision.SwitchTiles(Projectile.position, Projectile.width, Projectile.height, Projectile.oldPosition, 4);
				}
			}
			if (ballStepResult.State == BallState.Moving && Main.netMode == 2 && Main.player.IndexInRange(Projectile.owner) && Main.player[Projectile.owner].active)
			{
				RemoteClient.CheckSection(Projectile.owner, Projectile.position);
			}
			Projectile.AI();
        }*/
    }
}