using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace earthmod.GolferDamage
{
    public class GolferDamage : DamageClass
    {
        public override void SetStaticDefaults()
        {
            ClassName.SetDefault("golfing damage");
        }
	}
}