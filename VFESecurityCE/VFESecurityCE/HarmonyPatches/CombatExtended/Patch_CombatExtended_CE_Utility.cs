using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;
using CombatExtended;
using VFESecurity;

namespace VFESecurityCE
{

    public static class Patch_CombatExtended_CE_Utility
    {

        public static class manual_IsCrouching
        {

            public static void Postfix(Pawn pawn, ref bool __result)
            {
                // Also check that the pawn isn't standing on a tile that doesn't allow for crouching
                if (__result && !TerrainDefExtension.Get(pawn.Map.terrainGrid.TerrainAt(pawn.Position)).allowCrouching)
                {
                    __result = false;
                }
            }

        }

    }

}
