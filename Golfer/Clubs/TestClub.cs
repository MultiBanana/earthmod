using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace earthmod.Golfer.Clubs
{
    public class TestClub : GolferClubItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Club");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 30;
            base.SetDefaults();
        }
    }
}