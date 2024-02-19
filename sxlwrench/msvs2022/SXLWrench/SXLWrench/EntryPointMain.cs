using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;
using System.Reflection;

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
        public static GUIOverlay modGUI;
        public static SetupOverlay setupOverlay;
        static void Load()
        {
            SkaterXL.Core.SXLWrench.PushDataLocal("From DLL", true);
            //harmony
            //GUI
            EntryPointMain.modGUI = new GameObject().AddComponent<GUIOverlay>();
            UnityEngine.Object.DontDestroyOnLoad(EntryPointMain.modGUI);
            //Rectangle box
            EntryPointMain.setupOverlay = new GameObject().AddComponent<SetupOverlay>();
            UnityEngine.Object.DontDestroyOnLoad(EntryPointMain.setupOverlay);
        }
        
    }
    
}
