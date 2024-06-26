﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SXLWrench
{
    public class GUIOverlay : MonoBehaviour
    {
        //GUI variables
        public bool boolDisplayWindow;
        private Rect DWDisplay;
        int numW = 300;
        int numH = 750;
        int numX = 0;
        int numY = 0;
        //GUI box variables
        Color boxColor = new Color(0, 0, 0, 1);
        //6D data of various types declared and defined with default values
        private string data6Ddt = string.Empty;
        private string clipID = "NYD";
        //Board rel cam data
        public float data6Dboardxpos = 0;
        public float data6Dboardypos = 0;
        public float data6Ddistfromcamera = 0;
        //Camera data
        public float data6DCameraGlobXPos = 0;
        public float data6DCameraGlobYPos = 0;
        public float data6DCameraGlobZPos = 0;
        public float data6DCameraXrot = 0;
        public float data6DCameraYrot = 0;
        public float data6DCameraZrot = 0;
        //Board data
        public float data6DboardGlobXPos = 0;
        public float data6DboardGlobYPos = 0;
        public float data6DboardGlobZPos = 0;
        public float data6Dboardxrot = 0;
        public float data6Dboardyrot = 0;
        public float data6Dboardzrot = 0;
        
        
        //Threaded base OBJ
        public long frameSinceStart = 0;
        //Multi-Camera solution
        GameObject BaseOBJ = new GameObject();
        Camera cameraX;
        private void resetFrameCount()
        {
            /* SXLWrench.ToolBox.AppendDebugFile("Spawn Camera!", false);
            Camera.main.enabled = false;            
            BaseOBJ = GameObject.Find("New Master Prefab(Clone)");
            cameraX = BaseOBJ.AddComponent<Camera>();
            cameraX.enabled = true;
            cameraX.transform.position = new Vector3(0, 1.7F, 5);
            cameraX.transform.rotation = Quaternion.Euler(0, 327, 0);
            */
            try  {
                EntryPointMain.newFrames.frameNumber = 0;
            }
            catch (Exception e)
            {
                return;
            }
            


        }

        private void Start()
        {
            boolDisplayWindow = false;
            data6Ddt = ToolBox.cleanDTGroup(false);
            clipID = ToolBox.clipID;
            //Initialize black background
            bBGT2D = new Texture2D(128, 128);
            for (int i = 0; i < 128; i++)
            {
                for (int i2 = 0; i2 < 128; i2++)
                {
                    bBGT2D.SetPixel(i, i2, boxColor);
                }
            }

        }
        private void Update()
        {
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
                //Black background
                if (true)
                {
                    if (Event.current.type.Equals(EventType.Repaint))
                    {
                        bBGT2D.Apply();
                        Graphics.DrawTexture(new Rect(numX, numY, numW, numH), bBGT2D);
                    }
                }
                //Main window
                GUI.backgroundColor = Color.black;
                GUI.skin.label.fontSize = 30;
                this.DWDisplay = GUI.Window(313376377, new Rect((float)numX, (float)numY, (float)numW, (float)numH), new GUI.WindowFunction(this.guiWindowFunction), "SXLWrench");

            
            }
        }
        private void FixedUpdate()
        {
            if (this.boolDisplayWindow)
            {
                
                frameSinceStart = EntryPointMain.newFrames.frameNumber;
                ToolBox.returnBoardData();
            }

            }
        private void guiWindowFunction(int windowID)
        {
            if (false)
            {
                //dtstamp
                //GUILayout.Label(data6Ddt, Array.Empty<GUILayoutOption>());
                //clipid
                GUILayout.Label(clipID, Array.Empty<GUILayoutOption>());
                //psuedoframe
                //GUILayout.Label("psuedoframe: " + psuedoframe.ToString(), Array.Empty<GUILayoutOption>());
                //frame
                GUILayout.Label(frameSinceStart.ToString(), Array.Empty<GUILayoutOption>());
                //boardx rot
                GUILayout.Label(data6Dboardxrot.ToString(), Array.Empty<GUILayoutOption>());
                //boardy rot
                GUILayout.Label(data6Dboardyrot.ToString(), Array.Empty<GUILayoutOption>());
                //boardz rot
                GUILayout.Label(data6Dboardzrot.ToString(), Array.Empty<GUILayoutOption>());
                //d from cam
                GUILayout.Label(data6Ddistfromcamera.ToString(), Array.Empty<GUILayoutOption>());
                //boardx pos
                GUILayout.Label(data6Dboardxpos.ToString(), Array.Empty<GUILayoutOption>());
                //boardy pos
                GUILayout.Label(data6Dboardypos.ToString(), Array.Empty<GUILayoutOption>());
                //spawn cam
            }
            if (true)
            {
                GUILayout.Label(clipID, Array.Empty<GUILayoutOption>());
                GUILayout.Label(frameSinceStart.ToString(), Array.Empty<GUILayoutOption>());
                //board rel cam data
                GUILayout.Label(data6Dboardxpos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6Dboardypos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6Ddistfromcamera.ToString(), Array.Empty<GUILayoutOption>());
                //camera data
                GUILayout.Label(data6DCameraGlobXPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DCameraGlobYPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DCameraGlobZPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DCameraXrot.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DCameraYrot.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DCameraZrot.ToString(), Array.Empty<GUILayoutOption>());
                //board data
                GUILayout.Label(data6DboardGlobXPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DboardGlobYPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6DboardGlobZPos.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6Dboardxrot.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6Dboardyrot.ToString(), Array.Empty<GUILayoutOption>());
                GUILayout.Label(data6Dboardzrot.ToString(), Array.Empty<GUILayoutOption>());
            }
            if (GUILayout.Button("Reset Frames to 0"))
            {
                resetFrameCount();
            }
        }
        public GUIOverlay()
        {
        }
        Texture2D bBGT2D;
    }
}