using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using Harmony;
using CombatExtended;
using VFESecurity;

namespace VFESecurityCE
{

    public static class Patch_CombatExtended_CollisionVertical
    {

        [HarmonyPatch(typeof(CollisionVertical), "CalculateHeightRange")]
        public static class CalculateHeightRange
        {

            public static void Postfix(Thing thing, ref FloatRange heightRange, ref float shotHeight)
            {
                if (thing != null && thing.Map != null)
                {
                    var terrainCoverEff = TerrainDefExtension.Get(thing.Map.terrainGrid.TerrainAt(thing.Position)).coverEffectiveness;
                    float finalAdj = Mathf.Min(heightRange.max, terrainCoverEff);
                    heightRange.max -= finalAdj;
                    shotHeight -= finalAdj;
                }
            }

        }

    }

}
