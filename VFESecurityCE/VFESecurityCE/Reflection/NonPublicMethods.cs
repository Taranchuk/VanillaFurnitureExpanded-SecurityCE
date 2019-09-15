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

    public static class NonPublicMethods
    {
        
        [StaticConstructorOnStartup]
        public static class CombatExtended
        {

            public static Func<ExplosionCE, IntVec3, int> ExplosionCE_GetCellAffectTick = (Func<ExplosionCE, IntVec3, int>)
                Delegate.CreateDelegate(typeof(Func<ExplosionCE, IntVec3, int>), null, AccessTools.Method(typeof(ExplosionCE), "GetCellAffectTick"));

            public static Action<ProjectileCE> ProjectileCE_ImpactSomething = (Action<ProjectileCE>)
                Delegate.CreateDelegate(typeof(Action<ProjectileCE>), null, AccessTools.Method(typeof(ProjectileCE), "ImpactSomething"));

            public static Action<ProjectileCE_Explosive> ProjectileCE_Explosive_Explode = (Action<ProjectileCE_Explosive>)
                Delegate.CreateDelegate(typeof(Action<ProjectileCE_Explosive>), null, AccessTools.Method(typeof(ProjectileCE_Explosive), "Explode"));

        }

    }

}
