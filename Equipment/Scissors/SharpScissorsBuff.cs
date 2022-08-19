using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace earthmod.Items.Equipment.Scissors
{
    public class SharpScissorsBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Safety First!");
            Description.SetDefault("Movement speed increased");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SharpScissorsPlayer>().SharpScissorsTypeDamage = true;
            if (player.HasBuff(BuffID.Sharpened) == true)
            {
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 1.05f;
            }
            else
            {
                player.maxRunSpeed *= 1.5f;
            }
        }
        public class SharpScissorsPlayer : ModPlayer
        {
            public bool SharpScissorsTypeDamage;
            public int SharpScissorsDamage;
            public override void ResetEffects()
            {
                SharpScissorsTypeDamage = false;
            }
            public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
            {
                if (SharpScissorsTypeDamage)
                {
                    int EclipseScissorsDamage = damage / 15;
                    damage = (damage + EclipseScissorsDamage);
                }
                return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource, ref cooldownCounter);
            }
        }
    }
}