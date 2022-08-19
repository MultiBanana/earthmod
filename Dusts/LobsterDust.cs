using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace earthmod.Dusts
{
	public class LobsterDust : ModDust
	{
        public override void OnSpawn(Dust dust)
        {
			dust.velocity *= -0.4f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1f;
		}
		public override bool Update(Dust dust)
		{

			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.98f;
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}