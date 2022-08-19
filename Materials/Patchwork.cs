using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using System;

namespace earthmod.Items.Materials
{
    public class Patchwork : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'A relic of the creatures of the eclipse'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.Yellow;
            Item.maxStack = 999;
        }
    }
    public class NPCPatchworkDrop : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Frankenstein)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patchwork>(), 15));
            }
            if (npc.type == NPCID.Vampire)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patchwork>(), 40));
            }
            if (npc.type == NPCID.Fritz)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patchwork>(), 20));
            }
            if (npc.type == NPCID.ThePossessed)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Patchwork>(), 20));
            }
            base.ModifyNPCLoot(npc, npcLoot);
        }
    }
}