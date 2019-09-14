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

    public static class NonPublicProperties
    {
        
        [StaticConstructorOnStartup]
        public static class CombatExtended
        {

            public static readonly Func<ProjectileCE, int> ProjectileCE_get_IntTicksToImpact = (Func<ProjectileCE, int>)
                Delegate.CreateDelegate(typeof(Func<ProjectileCE, int>), null, AccessTools.Property(typeof(ProjectileCE), "IntTicksToImpact").GetGetMethod(true));
            public static readonly Func<ProjectileCE, float> ProjectileCE_get_StartingTicksToImpact = (Func<ProjectileCE, float>)
                Delegate.CreateDelegate(typeof(Func<ProjectileCE, float>), null, AccessTools.Property(typeof(ProjectileCE), "StartingTicksToImpact").GetGetMethod(true));

        }

    }

}
