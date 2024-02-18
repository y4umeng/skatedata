using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

/* Notes
 * added references for the following
 * SkaterXL.Core
 * 0Harmony
 * Assembly-CSharp
 * Assembly-CSharp-firstpass FROM MANAGED
 * UnityEngine
 * UnityEngine.UI
 * UnityEngine.CoreModule
 * UnityEngine.IMGUIModule
 * UnityModManager
 * */

namespace SXLWrench
{
    static class EntryPointMain
    {
        static void Load()
        {
            SkaterXL.Core.SXLWrench.PushDataLocal("From DLL", true);
            //harmony
        }
    }
}
