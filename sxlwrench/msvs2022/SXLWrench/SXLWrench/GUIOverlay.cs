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
        //GUI variables
        public bool boolDisplayWindow;
        private Rect DWDisplay;
        int numW = 600;
        int numH = 300;
        int numX = 0;
        int numY = 0;
        //GUI box variables
        Color boxColor = new Color(0, 0, 0, 1);
        //6D data of various types declared and defined with default values
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
            boolDisplayWindow = false;
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
                //Main window
                GUI.backgroundColor = Color.black;
                this.DWDisplay = GUI.Window(313376377, new Rect((float)numX, (float)numY, (float)numW, (float)numH), new GUI.WindowFunction(this.guiWindowFunction), "SXLWrench");
                //Black background
                if (true)
                {
                    Texture bBGT;
                    Texture2D bBGT2D = new Texture2D(128, 128);
                    for (int i = 0; i < 128; i++)
                    {
                        for (int i2 = 0; i2 < 128; i2++)
                        {
                            bBGT2D.SetPixel(i, i2, boxColor);

                        }

                    }


                    if (Event.current.type.Equals(EventType.Repaint))
                    {
                        bBGT2D.Apply();
                        Graphics.DrawTexture(new Rect(numX, numY, numW, numH), bBGT2D);
                    }
                }
            }
        }
        private void guiWindowFunction(int windowID)
        {
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
    }
}