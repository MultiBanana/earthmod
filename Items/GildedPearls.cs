using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System;

namespace earthmod.Items
{
    public class GildedPearls : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gilded Pearls");
            Tooltip.SetDefault("'These are sure to catch something's eye'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.bait = 333;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 20;
            Item.value = 10500;
            Item.rare = ItemRarityID.Green;
        }
    }
    public class GildedPearlsFishingEvent : ModPlayer
    {
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            bool inWater = !attempt.inLava && !attempt.inHoney;
            if (attempt.playerFishingConditions.BaitItemType == ModContent.ItemType<GildedPearls>() && attempt.playerFishingConditions.PoleItemType != ModContent.ItemType<Equipment.KingSlimeRod>() && Player.ZoneDesert && inWater)
            {
                npcSpawn = ModContent.NPCType<NPCS.Oasis.Gallumpaling>();
                itemDrop = -1;
                return;
            }
        }
    }
}