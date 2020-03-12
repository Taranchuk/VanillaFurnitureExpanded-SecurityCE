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

    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            VFESecurityCE.harmonyInstance.PatchAll();

            VFESecurityCE.harmonyInstance.Patch(AccessTools.Method(NonPublicTypes.CombatExtended.CE_Utility, "IsCrouching"),
                postfix: new HarmonyMethod(typeof(Patch_CombatExtended_CE_Utility.manual_IsCrouching), "Postfix"));
        }

    }

}
