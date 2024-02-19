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
        //6D string data
        private string data6Ddt = string.Empty;
        private int clipIDnum = 1;
        private string clipID = "clipID: ";
        private long psuedoframe = 0;
        public float data6Dboardxrot = 0;
        public float data6Dboardyrot = 0;
        public float data6Dboardzrot = 0;
        public float data6Ddistfromcamera = 0;
        public float data6Dboardxpos = 0;
        public float data6Dboardypos = 0; 

        private void Start()
        {
            this.boolDisplayWindow = false;
            data6Ddt = ToolBox.cleanDTGroup(false);
            clipID = clipID + clipIDnum.ToString();
        }
        private void Update()
        {
            ToolBox.returnBoardData();
            psuedoframe++;
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
            //dtstamp
            GUILayout.Label(data6Ddt, Array.Empty<GUILayoutOption>());
            //clipid
            GUILayout.Label(clipID, Array.Empty<GUILayoutOption>());
            //psuedoframe
            GUILayout.Label("psuedoframe: " + psuedoframe.ToString(), Array.Empty<GUILayoutOption>());
            //boardx rot
            GUILayout.Label("board.x R: " + data6Dboardxrot.ToString(), Array.Empty<GUILayoutOption>());
            //boardy rot
            GUILayout.Label("board.y R: " + data6Dboardyrot.ToString(), Array.Empty<GUILayoutOption>());
            //boardz rot
            GUILayout.Label("board.z R: " + data6Dboardzrot.ToString(), Array.Empty<GUILayoutOption>());
            //d from cam
            GUILayout.Label("d from cam: " + data6Ddistfromcamera.ToString(), Array.Empty<GUILayoutOption>());
            //boardx pos
            GUILayout.Label("board 2d X: " + data6Dboardxpos.ToString(), Array.Empty<GUILayoutOption>());
            //boardy pos
            GUILayout.Label("board 2d Y: " + data6Dboardypos.ToString(), Array.Empty<GUILayoutOption>());
        }
        public GUIOverlay()
    {

    }
    private bool boolDisplayWindow;
    private Rect DWDisplay;
}
}