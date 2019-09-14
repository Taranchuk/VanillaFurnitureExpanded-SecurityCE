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

    public static class NonPublicTypes
    {
        
        [StaticConstructorOnStartup]
        public static class CombatExtended
        {

            public static Type CE_Utility = GenTypes.GetTypeInAnyAssemblyNew("CombatExtended.CE_Utility", "CombatExtended");

        }

    }

}
