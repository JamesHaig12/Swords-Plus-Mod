using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using SwordsPlus.Items;
using System;
using IL.Terraria.GameContent;

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
        }
    }
}
