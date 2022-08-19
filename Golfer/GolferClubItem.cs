using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace earthmod.Golfer
{
    public abstract class GolferClubItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {         
           Item.CloneDefaults(ItemID.GolfClubIron);
           Item.DamageType = ModContent.GetInstance<GolferDamage.GolferDamage>();
        }
    }
}