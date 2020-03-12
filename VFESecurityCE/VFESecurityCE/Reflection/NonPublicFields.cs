using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;
using CombatExtended;
using VFESecurity;

namespace VFESecurityCE
{

    public static class NonPublicFields
    {
        
        [StaticConstructorOnStartup]
        public static class CombatExtended
        {

            public static FieldInfo ExplosionCE_cellsToAffect = AccessTools.Field(typeof(ExplosionCE), "cellsToAffect");

            public static FieldInfo ProjectileCE_launcher = AccessTools.Field(typeof(ProjectileCE), "launcher");
            public static FieldInfo ProjectileCE_ticksToImpact = AccessTools.Field(typeof(ProjectileCE), "ticksToImpact");

        }

    }

}
