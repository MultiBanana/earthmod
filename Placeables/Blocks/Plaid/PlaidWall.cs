using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace earthmod.Placeables.Blocks.Plaid
{
    public class PlaidWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaid Wall");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = WallType<PlaidWall_Tile>();
        }
        public override void AddRecipes()
        {
            var resultItem = ModContent.GetInstance<PlaidWall>();

            resultItem.CreateRecipe(4)
            .AddIngredient(Mod, "PlaidBlock")
            .Register();
            base.AddRecipes();
        }
    }
    public class PlaidWall_Tile : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;

            ItemDrop = ModContent.ItemType<PlaidWall>();

            AddMapEntry(new Color(111, 0, 0));
        }
    }
}
