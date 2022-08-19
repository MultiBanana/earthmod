using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace earthmod.Items.Equipment.Scissors
{
    public class LunarScissorsBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quicksnipper");
            Description.SetDefault("Sharpening further would tear the fabric of time and space");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(BuffID.Sharpened) == true)
            {
                player.maxRunSpeed *= 50f;
                player.runAcceleration *= 10f;
            }
            else
            {
                player.maxRunSpeed *= 15f;
                player.runAcceleration *= 5f;
            }          
        }
    }
}