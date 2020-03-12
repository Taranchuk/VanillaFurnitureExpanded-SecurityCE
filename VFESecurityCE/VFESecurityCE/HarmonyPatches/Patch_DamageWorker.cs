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

    public static class Patch_DamageWorker
    {

        [HarmonyPatch(typeof(DamageWorker), nameof(DamageWorker.ExplosionAffectCell))]
        public static class ExplosionAffectCell
        {

            [HarmonyBefore("OskarPotocki.VanillaFurnitureExpanded.Security")]
            public static bool Prefix(Explosion explosion, IntVec3 c)
            {
                // Basically the same code over again for CE Explosions 🤷
                if (explosion is ExplosionCE explosionCE)
                {
                    bool executeOriginal = true;
                    ShieldGeneratorUtility.CheckIntercept(explosionCE, explosionCE.Map, explosionCE.damAmount, explosionCE.damType, () => new List<IntVec3>() { c }, () => explosionCE.damType.AffectsShields(),
                        s =>
                        {
                            executeOriginal = s.WithinBoundary(explosionCE.Position, c);
                            return !s.affectedThings.ContainsKey(explosionCE);
                        },
                        s =>
                        {
                            var cellsToAffect = (List<IntVec3>)NonPublicFields.CombatExtended.ExplosionCE_cellsToAffect.GetValue(explosionCE);
                            int cacheDuration = cellsToAffect.Select(eC => NonPublicMethods.CombatExtended.ExplosionCE_GetCellAffectTick(explosionCE, eC)).Max();
                            s.affectedThings.Add(explosion, cacheDuration);
                        });
                    return executeOriginal;
                }
                return true;   
            }

        }

    }

}
