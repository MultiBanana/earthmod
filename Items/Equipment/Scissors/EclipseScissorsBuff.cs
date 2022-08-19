using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace earthmod.Items.Equipment.Scissors
{
    public class EclipseScissorsBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snip and Tear");
            Description.SetDefault("Movement speed notably increased");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<EclipseScissorsPlayer>().EclipseScissorsTypeDamage = true;
            if (player.HasBuff(BuffID.Sharpened) == true)
            {
                player.maxRunSpeed *= 3.15f;
                player.runAcceleration *= 1.25f;
            }
            else
            {
                player.maxRunSpeed *= 2.60f;
                player.runAcceleration *= 1.10f;
            }          
        }
        public class EclipseScissorsPlayer : ModPlayer
        {
            public bool EclipseScissorsTypeDamage;
            public int EclipseScissorsDamage;
            public override void ResetEffects()
            {
                EclipseScissorsTypeDamage = false;
            }
            public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
            {
                if (EclipseScissorsTypeDamage)
                {
                    int EclipseScissorsDamage = damage / 15;
                    damage = (damage + EclipseScissorsDamage);
                }
                return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource, ref cooldownCounter);
            }
        }
    }
}