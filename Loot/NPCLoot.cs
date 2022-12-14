using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using SwordsPlus.Items;
using System;
using IL.Terraria.GameContent;
using System.Security.Cryptography;
using System.Data;

namespace SwordsPlus.Loot
{
    public class NPCLoot : GlobalNPC // Adding NPC Loot to the global npc file
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (!NPCID.Sets.CountsAsCritter[npc.type]) // Checks if NPCID Counts as a critter, if false runs the statment
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwordSoul>(), 3, 1, 4));
                // Uses the basic common drop rule, ints at the end = 1/3 chance, 1 Min, 4 Max
                // ItemDropRule.Common is what you would use in most cases, it simply drops the item with a fractional chance specified.
                // The chanceDenominator int is used for the denominator part of the fractional chance of dropping this item.
            }

            if (npc.type == NPCID.HallowBoss)
            {
                DaytimeDropCondition daytimeDropCondition = new DaytimeDropCondition();
                IItemDropRule conditionalRule = new LeadingConditionRule(daytimeDropCondition);
                int itemType = ModContent.ItemType<PrismaticCore>();
                IItemDropRule rule = ItemDropRule.Common(itemType, chanceDenominator: 1);
                conditionalRule.OnSuccess(rule);
                npcLoot.Add(conditionalRule);
            }

        }
        
        // ModContent.ItemType<PrismaticCore>(), 1, 1, 1));
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Wizard)
            { 
                // We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value. 
                // Editing item.value in SetupShop is an incorrect approach.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DeckOfCards>());
                shop.item[nextSlot].shopCustomPrice = 2500;
                nextSlot++;
            }

            //else if (type == NPCID.<NPC>){ } - we can use this to add items to other shops e.g dryad
        }
    }
}
