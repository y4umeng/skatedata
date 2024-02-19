using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SXLWrench
{
    public class GUIOverlay : MonoBehaviour
    {
        private string forMenu = string.Empty;
        private void Start()
        {
            this.boolDisplayWindow = false;
        }
        private void Update()
        {
            forMenu = ToolBox.cleanDTGroup(false);
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.boolDisplayWindow = !this.boolDisplayWindow;
                if (this.boolDisplayWindow)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    return;
                }
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        private void OnGUI()
        {
            if (this.boolDisplayWindow)
            {
                int num = 600;
                int num2 = 300;
                int num3 = 0; //Screen.width
                int num4 = 0; //Screen.height
                GUI.backgroundColor = Color.black;
                this.DWDisplay = GUI.Window(313376377, new Rect((float)num3, (float)num4, (float)num, (float)num2), new GUI.WindowFunction(this.DataWindowedDisplay), "SXLWrench");
            }
        }
        private void DataWindowedDisplay(int windowID)
        {
            float num = (float)((Screen.width - 50) / 2);
            int num2 = (Screen.height - 50) / 2;
            GUI.DragWindow(new Rect(num, (float)num2, 100f, 100f));
            GUILayout.Label(forMenu, Array.Empty<GUILayoutOption>());
        }
        public GUIOverlay()
        {

        }
        private bool boolDisplayWindow;
        private Rect DWDisplay;
    }
}