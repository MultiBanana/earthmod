using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace earthmod.Items.Sets.GraniteSet
{
	public class GraniteScannerBuff : ModBuff
	{
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GraniteScannerBuffNPC>().markedbyGraniteScanner = true;
		}
	}

	public class GraniteScannerBuffNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool markedbyGraniteScanner;
        public override void ResetEffects(NPC npc)
		{
			markedbyGraniteScanner = false;
		}
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (markedbyGraniteScanner && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
			{
				damage += 8;
			}
		}
	}
}