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

    public class VFESecurityCE : Mod
    {
        public VFESecurityCE(ModContentPack content) : base(content)
        {
            harmonyInstance = HarmonyInstance.Create("Andross.VFESecurityCE");
        }

        public static HarmonyInstance harmonyInstance;

    }

}
