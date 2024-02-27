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
        public static SXLWrenchBaseOBJ newFrames;
        
        static void Load()
        {
            //harmony
            //GUI
            EntryPointMain.modGUI = new GameObject().AddComponent<GUIOverlay>();
            UnityEngine.Object.DontDestroyOnLoad(EntryPointMain.modGUI);
            //Rectangle box
            EntryPointMain.setupOverlay = new GameObject().AddComponent<SetupOverlay>();
            UnityEngine.Object.DontDestroyOnLoad(EntryPointMain.setupOverlay);
            //Tools debug check
            ToolBox.initCurrentStatus();
            ToolBox.AppendDebugFile("Based Test!", true);
            //Timer for frames
            EntryPointMain.newFrames = new GameObject().AddComponent<SXLWrenchBaseOBJ>();
            UnityEngine.Object.DontDestroyOnLoad(EntryPointMain.newFrames);

        }
        
    }
    
}
