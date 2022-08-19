using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using System;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace earthmod
{
    public class ModifyRecipes : ModSystem
    {   
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Pizza, 1)
               .AddIngredient(ModContent.ItemType<Items.Materials.InfantrySupplies>(), 1)
               .AddIngredient(ModContent.ItemType<Cooking.Ingredients.SpecialSpice>(), 1)
               .AddTile(TileID.CookingPots)
               .Register();

            Recipe.Create(ItemID.ApplePie, 1)
                .AddIngredient(ItemID.Apple, 3)
                .AddIngredient(ModContent.ItemType<Cooking.Ingredients.Flour>(), 5)
                .AddIngredient(ModContent.ItemType<Cooking.Ingredients.Sugar>(), 1)
                .AddTile(TileID.CookingPots)
                .Register();

            Recipe.Create(ItemID.PumpkinPie, 1)
                .AddIngredient(ItemID.Pumpkin, 15)
                .AddIngredient(ModContent.ItemType<Cooking.Ingredients.Flour>(), 5)
                .AddIngredient(ModContent.ItemType<Cooking.Ingredients.Sugar>(), 1)
                .AddTile(TileID.CookingPots)
                .Register();
            //
            Recipe.Create(ItemID.DirtBlock, 1)
               .AddIngredient(ModContent.ItemType<Placeables.Platforms.DirtPlatform>(), 2)
               .Register();

            Recipe.Create(ItemID.MudBlock, 1)
               .AddIngredient(ModContent.ItemType<Placeables.Platforms.MudPlatform>(), 2)
               .Register();

            Recipe.Create(ItemID.AshBlock, 1)
               .AddIngredient(ModContent.ItemType<Placeables.Platforms.AshPlatform>(), 2)
               .Register();

            Recipe.Create(ItemID.SnowBrick, 1)
               .AddIngredient(ModContent.ItemType<Placeables.Platforms.SnowBrickPlatform>(), 2)
               .Register();
            //
            Recipe.Create(ItemID.ScarabFishingRod, 1)
              .AddIngredient(ItemID.FossilOre, 14)
              .AddRecipeGroup("earthmod:ColoredHusks", 1)
              .AddTile(TileID.Anvils)
              .Register();
        }
        //
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ItemID.PumpkinPie))
                {
                    if (recipe.HasIngredient(ModContent.ItemType<Cooking.Ingredients.Flour>()) == false)
                    {
                        recipe.DisableRecipe();
                    }
                }
            }
        }
        //
        public override void AddRecipeGroups()
        {
            if (RecipeGroup.recipeGroupIDs.ContainsKey("Fruit"))
            {
                int index = RecipeGroup.recipeGroupIDs["Fruit"];
                RecipeGroup group = RecipeGroup.recipeGroups[index];
                group.ValidItems.Add(ModContent.ItemType<Cooking.Foods.Strawberry>());
                group.ValidItems.Add(ModContent.ItemType<Cooking.Foods.HotPepper>());
                group.ValidItems.Add(ModContent.ItemType<Cooking.Foods.Olives>());
                group.ValidItems.Add(ModContent.ItemType<Cooking.Foods.Tomato>());
                group.ValidItems.Add(ItemID.Grapes);
            }

            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Colored Husk", new int[]
            {
                ItemID.CyanHusk,
                ItemID.RedHusk,
                ItemID.VioletHusk
            });
            RecipeGroup.RegisterGroup("earthmod:ColoredHusks", group2);

            RecipeGroup group3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Wild Moss", new int[]
            {
                ItemID.GreenMoss,
                ItemID.BrownMoss,
                ItemID.BlueMoss,
                ItemID.RedMoss,
                ItemID.PurpleMoss
            });
            RecipeGroup.RegisterGroup("earthmod:BasicMoss", group3);

            RecipeGroup group4 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Glowing Moss", new int[]
            {
                ItemID.KryptonMoss,
                ItemID.XenonMoss,
                ItemID.ArgonMoss
            });
            RecipeGroup.RegisterGroup("earthmod:GlowingMoss", group4);

            RecipeGroup group5 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("earthmod:SilverBar", group5);

            RecipeGroup group6 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("earthmod:EvilBar", group6);

        }
    }
    //
    public class ModifyNPCDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.GreekSkeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cooking.Foods.Olives>(), 40));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.InfantrySupplies>(), 5));
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.Pizza;
                });
            }
            if (npc.type == NPCID.Medusa)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cooking.Foods.Olives>(), 40));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.InfantrySupplies>(), 5));
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.Pizza;
                });
            }

            if (npc.type == NPCID.ChaosElemental)
            {
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.ApplePie;
                });
            }
            if (npc.type == NPCID.IlluminantBat)
            {
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.ApplePie;
                });
            }
            if (npc.type == NPCID.IlluminantSlime)
            {
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.ApplePie;
                });
            }
            if (npc.type == NPCID.GraniteFlyer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.GraniteBulb>(), 2));
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.Spaghetti;
                });
            }
            if (npc.type == NPCID.GraniteGolem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.GraniteBulb>(), 2));
                npcLoot.RemoveWhere(rule =>
                {
                    if (rule is not CommonDrop drop)
                        return false;
                    return drop.itemId == ItemID.Spaghetti;
                });
            }
        }
    }

    public class ModifyItemStats : GlobalItem
    {

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.ApplePie)
            {
                foreach (var tooltip in tooltips)
                {
                    if (tooltip.Mod == "Terraria")
                    {
                        if (tooltip.Name == "Tooltip0")
                        {
                            tooltip.Text = "Medium improvements to all stats";
                        }
                    }
                }
            }
            if (item.type == ItemID.ScarabFishingRod)
            {
                int index = 0;
                if (item.favorited)
                {
                    index += 2;
                }
                tooltips.Insert(index + 3, new TooltipLine(Mod, "earthmod:ScarabFishingRodTooltip", "Chance to fish up angry creatures in an Oasis"));
            }
            base.SetDefaults(item);
        }
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.ApplePie)
            {
                item.buffType = BuffID.WellFed2;
                item.rare = ItemRarityID.Green;
                item.buffTime = 36000;
            }
            if (item.type == ItemID.ReaverShark)
            {
                item.pick = 100;
                item.useAnimation = 18;
                item.useTime = 18;
            }
            if (item.type == ItemID.BlueMoon)
            {
                item.crit = 11;
            }
            if (item.type == ItemID.MagicMissile)
            {
                item.crit = 4;
            }
            base.SetDefaults(item);
        }
    }

    public class OasisFishingEvent : ModPlayer
    {
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            bool inWater = !attempt.inLava && !attempt.inHoney;
            if (attempt.playerFishingConditions.PoleItemType == ItemID.ScarabFishingRod && inWater && Player.ZoneDesert && Main.rand.NextBool(5))
            {

                int npc = ModContent.NPCType<NPCS.Oasis.GildedOyster>();
                if (!NPC.AnyNPCs(npc))
                {
                    npcSpawn = npc;
                    itemDrop = -1;
                    return;
                }
            }
        }
    }
}