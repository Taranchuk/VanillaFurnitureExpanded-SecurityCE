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

    public static class ShieldGeneratorUtilityCE
    {
        public static bool BlockableByShield(this ProjectileCE proj, Building_Shield shieldGen)
        {
            if (!proj.def.projectile.flyOverhead)
                return true;
            return !shieldGen.coveredCells.Contains(((Vector3)VFESecurity.NonPublicFields.Projectile_origin.GetValue(proj)).ToIntVec3()) &&
                NonPublicProperties.CombatExtended.ProjectileCE_get_IntTicksToImpact(proj) / NonPublicProperties.CombatExtended.ProjectileCE_get_StartingTicksToImpact(proj) <= 0.5f;
        }

    }

}
