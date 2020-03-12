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

    public static class Patch_VFESecurity_Building_Shield
    {

        [HarmonyPatch(typeof(Building_Shield), "EnergyShieldTick")]
        public static class EnergyShieldTick
        {

            public static bool Prefix(Building_Shield __instance)
            {
                var thingsWithinRadius = new HashSet<Thing>(__instance.ThingsWithinRadius);
                var thingsWithinScanArea = new HashSet<Thing>(__instance.ThingsWithinScanArea);
                foreach (var thing in thingsWithinScanArea)
                {
                    // Try and block projectiles from outside
                    if (thing is ProjectileCE proj && proj.BlockableByShield(__instance))
                    {
                        var launcher = NonPublicFields.CombatExtended.ProjectileCE_launcher.GetValue(proj) as Thing;
                        if (launcher != null && !thingsWithinRadius.Contains(launcher))
                        {
                            var explosiveProj = proj as ProjectileCE_Explosive;
                            // Explosives are handled separately
                            if (explosiveProj == null)
                                __instance.AbsorbDamage(proj.def.projectile.GetDamageAmount(1), proj.def.projectile.damageDef, proj.ExactRotation.eulerAngles.y);
                            proj.Position += Rot4.FromAngleFlat((__instance.Position - proj.Position).AngleFlat).Opposite.FacingCell;
                            NonPublicMethods.CombatExtended.ProjectileCE_ImpactSomething(proj);
                            if (explosiveProj != null)
                                NonPublicMethods.CombatExtended.ProjectileCE_Explosive_Explode(explosiveProj);
                        }
                    }
                }
                return false;
            }

        }

        [HarmonyPatch(typeof(Building_Shield), "EnergyLossMultiplier")]
        public static class EnergyLossMultiplier
        {

            public static void Postfix(DamageDef damageDef, ref float __result)
            {
                // Very low multiplier since many fragments are typically spawned when an explosion happens
                if (damageDef == DamageDefOf.Fragment)
                    __result = 0.05f;
            }

        }

    }

}
