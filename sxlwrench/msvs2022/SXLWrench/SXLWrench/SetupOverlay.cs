using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using static SkaterXL.Core.MyGUIUtility;

namespace SXLWrench
{
    public class SetupOverlay : MonoBehaviour
    {
        //GUI variables
        GUIStyle boxStyle = new GUIStyle();
        Color myColor1 = new Color(0, 0, 0, 2147483647);
        Color myColor2 = new Color(0, 0, 0, (float)0.1);
        //Box variables
        Color olColor = new Color(1, (float)0.92, (float)0.016, 1);
        Color koColor = new Color(0, 0, 0, 0);
        Texture2D bBGT2D;
        //@"C:\Program Files (x86)\Steam\steamapps\common\Skater XL\Mods\SXLWrenchMod_v1.0.0_for_SkaterXL_1.2.7.8\modT.png";
        private int numW, numH, numX, numY;
        private Rect Box640480 = new Rect();

        
        private void Start()
        {
            //texture
            //
            int screenRestraintW(int value)
            {
                if (value >= 640)
                {
                    return value;
                } else
                {
                    return 640;
                }
            }
            int screenRestraintH(int value)
            {
                if (value >= 480)
                {
                    return value;
                }
                else
                {
                    return 480;
                }
            }
            numW = screenRestraintW((int)(Screen.width / 2.6)); //should not be less that 640     3
            numH = screenRestraintH((int)(Screen.height / 2)); //should not be less than 480     2.25
            numX = ((Screen.width / 2) - (numW / 2)); // = 1/2Screen.width-1/2 rect width
            numY = ((Screen.height / 2) - (numH / 2)); // = 1/2Screen.height-1/2 rect height
            //Box640480 = new Rect((float)numX, (float)numY, (float)numW, (float)numH);
            //Black box
            int spWidth = 3;
            bBGT2D = new Texture2D(numW, numH);
            //Points subroutine
            if (false) {
                for (int i = 0; i < numW; i++)
                {
                    for (int i2 = 0; i2 < numH; i2++)
                    {
                        if ((i <= spWidth | i >= (numW - spWidth)) && (i2 <= spWidth | i2 >= (numH - spWidth)))
                        {
                            bBGT2D.SetPixel(i, i2, olColor);
                        }
                        else
                        {
                            bBGT2D.SetPixel(i, i2, koColor);
                        }
                    }
                }
            }
            //Rectangle subroutine
            if (false)
            {
                for (int i = 0; i < numW; i++)
                {//x
                    for (int i2 = 0; i2 < numH; i2++)
                    {//y
                        bBGT2D.SetPixel(i, i2, koColor);
                        if (i2 <= spWidth | (i2>=(numH-spWidth)))
                        {
                            bBGT2D.SetPixel(i, i2, olColor);
                        }
                        if (i <= spWidth | (i >= (numW-spWidth)))
                        {
                            bBGT2D.SetPixel(i, i2, olColor);
                        }
                    }
                }
            }
        }
        private void Update()
        {

        }
        private void OnGUI()
        {
            if (EntryPointMain.modGUI.boolDisplayWindow)
            {
                //main window
                //GUI.color = myColor1;
                //GUI.backgroundColor = myColor2;
                //Box640480 = GUI.Window(313376367, Box640480, guiWindowFunction, string.Empty);
                //inner window 2
                //GUI.Box(new Rect(numX, numY, numW, numH), "This is a box");
                
                if (false)
                {
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
            //GUI.DragWindow(new Rect(0, 0, 10000, 10000));
        }
        public SetupOverlay()
        {
        }
    }
}
