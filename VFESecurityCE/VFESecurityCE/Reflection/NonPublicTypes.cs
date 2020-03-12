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

    public static class NonPublicTypes
    {
        
        [StaticConstructorOnStartup]
        public static class CombatExtended
        {

            public static Type CE_Utility = GenTypes.GetTypeInAnyAssembly("CombatExtended.CE_Utility", "CombatExtended");

        }

    }

}
