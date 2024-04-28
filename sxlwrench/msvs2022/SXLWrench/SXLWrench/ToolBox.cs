using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SkaterXL;
using SkaterXL.Core;
using SkaterXL.Data;
using SkaterXL.Gameplay;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;
using System.Reflection;
using JetBrains.Annotations;
using System.Xml.Linq;
using static UnityEngine.GraphicsBuffer;

namespace SXLWrench
{
    
    public static class ToolBox
    {
        private static string fileDTStamp = "";
        private static bool fpSwitch = false;
        private static string debugFile_dtCurrentPath = "";
        private static string debugFile_dtCurrentFile;
        public static string clipID;
        
        public static void returnBoardData()
        {
            int ifZero(int value)
            {
                if (value == 360)
                {
                    return 0;
                }
                else
                {
                    return value;
                }
            }
            //6D string data
            /*
        private float data6Dboardxpos = 0;
        private float data6Dboardypos = 0;
            */
            string retVal ="";
            //Board Variables
            GameObject BoardOBJ;
            Vector3 BoardV3Position;
            Quaternion BoardQ;
            Vector3 BoardV3Rotation;
            //Camera Variables
            GameObject CameraOBJ;
            Vector3 CameraV3Position;
            Quaternion CameraQ;
            Vector3 CameraV3Rotation;
            float CamBoardDistF;
            //Board data assingments
            BoardOBJ = GameObject.Find("Skateboard");
            BoardV3Position = BoardOBJ.transform.position;
            BoardQ = BoardOBJ.transform.rotation;
            BoardV3Rotation = BoardQ.eulerAngles;
            int angularDataType = 2;

            //float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
            CameraOBJ = GameObject.Find("Main Camera");
            CameraV3Position = CameraOBJ.transform.position;
            CameraQ = CameraOBJ.transform.rotation;
            CameraV3Rotation = CameraQ.eulerAngles;
            CamBoardDistF = Vector3.Distance(CameraOBJ.transform.position, BoardOBJ.transform.position);
            EntryPointMain.modGUI.data6Ddistfromcamera = CamBoardDistF;



            //Player.skateboard 2D position data
            Camera igCam = CameraOBJ.GetComponent<Camera>();
            Vector3 boardSSPOS = igCam.WorldToScreenPoint(BoardOBJ.transform.position);
            float board2DPOSx = boardSSPOS.x;
            float board2DPOSy = boardSSPOS.y;
            EntryPointMain.modGUI.data6Dboardxpos = board2DPOSx;
            EntryPointMain.modGUI.data6Dboardypos = board2DPOSy;

            if (angularDataType == 0)
            {
                //rounded skateboard data
                EntryPointMain.modGUI.data6Dboardxrot = ifZero(Mathf.RoundToInt(BoardV3Rotation.x)); //impossible
                EntryPointMain.modGUI.data6Dboardyrot = ifZero(Mathf.RoundToInt(BoardV3Rotation.y)); //flat
                EntryPointMain.modGUI.data6Dboardzrot = ifZero(Mathf.RoundToInt(BoardV3Rotation.z)); //roll


            } else if (angularDataType == 1)
            {
                //not rounded skateboard data
                EntryPointMain.modGUI.data6Dboardxrot = BoardV3Rotation.x; //impossible
                EntryPointMain.modGUI.data6Dboardyrot = BoardV3Rotation.y; //flat
                EntryPointMain.modGUI.data6Dboardzrot = BoardV3Rotation.z; //roll

            } else if (angularDataType == 2)
            {
                //Adjusted angle for camera position test routine 1

                //X ROUTINE IMPOSSIBLE AXIS
                double moneYb, moneyTb, moneyOb;
                moneyOb = 0;
                double val1b = (CameraV3Position.z - BoardV3Position.z);
                double val2b = (CameraV3Position.y - BoardV3Position.y);
                moneYb = Mathf.Atan2((float)val1b, (float)val2b);
                moneYb = moneYb * (180 / Math.PI);
                moneYb = moneYb + 180;
                moneyTb = BoardV3Rotation.x;
                moneyTb += 90;
                if (moneyTb > 360)
                {
                    moneyTb = moneyTb % 360;
                }
                moneyTb -= 360;
                moneyTb = moneyTb * -1;
                //determine difference and normalize
                if (moneYb == moneyTb)
                {
                    moneyOb = 0;
                }
                else
                {
                    moneyOb = ((360 + moneYb) - moneyTb);
                    if (moneyOb > 360)
                    {
                        moneyOb = moneyOb % 360;
                    }
                }
                EntryPointMain.modGUI.data6Dboardxrot = (float)moneyOb;


                //Y ROUTINE SHUVIT AXIS
                double moneY, moneyT, moneyO;
                moneyO = 0;
                double val1 = (CameraV3Position.z - BoardV3Position.z);
                double val2 = (CameraV3Position.x - BoardV3Position.x);
                moneY = Mathf.Atan2((float) val1,(float) val2);
                moneY = moneY * (180 / Math.PI);
                moneY = moneY + 180;
                moneyT = BoardV3Rotation.y;
                moneyT += 90;
                if (moneyT > 360)
                {
                    moneyT = moneyT % 360;
                }
                moneyT -= 360;
                moneyT = moneyT * -1;
                //determine difference and normalize
                if (moneY == moneyT)
                {
                    moneyO = 0;
                } else
                {
                    moneyO = ((360 + moneY) - moneyT);
                    if (moneyO > 360)
                    {
                        moneyO = moneyO % 360;
                    }
                }
                EntryPointMain.modGUI.data6Dboardyrot = (float) moneyO;

                //Z ROUTINE FLIP AXIS
                double moneYc, moneyTc, moneyOc;
                moneyOc = 0;
                double val1c = (CameraV3Position.y - BoardV3Position.y);
                double val2c = (CameraV3Position.x - BoardV3Position.x);
                moneYc = Mathf.Atan2((float)val1c, (float)val2c);
                moneYc = moneYc * (180 / Math.PI);
                moneYc = moneYc + 180;
                moneyTc = BoardV3Rotation.z;
                moneyTc += 90;
                if (moneyTc > 360)
                {
                    moneyTc = moneyTc % 360;
                }
                moneyTc -= 360;
                moneyTc = moneyTc * -1;
                //determine difference and normalize
                if (moneYc == moneyTc)
                {
                    moneyOc = 0;
                }
                else
                {
                    moneyOc = ((360 + moneYc) - moneyTc);
                    if (moneyOc > 360)
                    {
                        moneyOc = moneyOc % 360;
                    }
                }
                EntryPointMain.modGUI.data6Dboardzrot = (float)moneyOc;




            }
        }
        private static Vector2 atan2PrepF()
        {
            Vector2 money;
            float val1 = 0;
            float val2 = 0;
            money = new Vector2(val1, val2); //y,x
            return money;
        }
        public static string cleanDTGroup(bool yon)
        {
            DateTime nowDateTime = DateTime.Now;
            string dtStringAppend = nowDateTime.ToString();
            if (yon)
            {

                //remove special characters from Date Time
                dtStringAppend = dtStringAppend.Replace(" ", "");
                dtStringAppend = dtStringAppend.Replace(@"\", "");
                dtStringAppend = dtStringAppend.Replace(":", "");
                dtStringAppend = dtStringAppend.Replace(@"/", "");
                dtStringAppend = dtStringAppend.Replace("@", "");
                dtStringAppend = dtStringAppend.Replace("_", "");
                dtStringAppend = dtStringAppend.Replace("-", "");
                dtStringAppend = dtStringAppend.Replace("?", "");
                dtStringAppend = dtStringAppend.Replace(",", "");
                dtStringAppend = dtStringAppend.Replace(".", "");
                dtStringAppend = dtStringAppend.Replace("!", "");
                dtStringAppend = dtStringAppend.Replace("&", "");
                dtStringAppend = dtStringAppend.Replace("(", "");
                dtStringAppend = dtStringAppend.Replace(")", "");
                dtStringAppend = dtStringAppend.Replace("$", "");
                dtStringAppend = dtStringAppend.Replace("#", "");

                //remove special characters from Date Time end
                return dtStringAppend;
            }
            else if (!yon)
            {
                return dtStringAppend;

            }
            else
            {
                return dtStringAppend;
            }
            return dtStringAppend;
        }
        private static void initTimeFile()
        {
            if (fpSwitch == false)
            {
                try
                {
                    fileDTStamp = cleanDTGroup(true);
                    clipID = resetHashStringID(fileDTStamp);
                    string newBasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string newPathDT = newBasePath + @"\SXLWrenchFiles\deBugClip" + clipID;
                    System.IO.Directory.CreateDirectory(newPathDT);
                    debugFile_dtCurrentPath = newPathDT;
                    debugFile_dtCurrentFile = debugFile_dtCurrentPath + @"\deBugClip" + fileDTStamp +".txt";
                    
                }
                catch (Exception e)
                {
                    return;
                }
                fpSwitch = true;

            }
            else
            {

            }
        }
        public static void initCurrentStatus()
        {
            initTimeFile();
            AppendDebugFile("initCurrentStatus" + " " + @"new file\folder" + " " + debugFile_dtCurrentFile, true);

        }
        public static string resetHashStringID(string strword)
        {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 3; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
        }
        //need constructor here for dt
        public static void AppendDebugFile()
        {
            try
            {
                string outputText = " --- Ping --- " + cleanDTGroup(false) + "\n";
                if (File.Exists(debugFile_dtCurrentFile))
                {
                    using (FileStream myfilestream = new FileStream(debugFile_dtCurrentFile, FileMode.Append))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    initCurrentStatus();
                    using (FileStream myfilestream = File.Create(debugFile_dtCurrentFile))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        public static void AppendDebugFile(string outputCurrentDebug, bool dtSwitch)
        {
            try
            {
                string outputText = string.Empty;
                if (dtSwitch)
                {
                    outputText = outputCurrentDebug + " " + cleanDTGroup(false) + "\n";
                }
                else if (!dtSwitch)
                {
                    outputText = outputCurrentDebug + "\n";
                }
                if (File.Exists(debugFile_dtCurrentFile))
                {
                    //File.Delete(debugFile_camera);
                    using (FileStream myfilestream = new FileStream(debugFile_dtCurrentFile, FileMode.Append))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    using (FileStream myfilestream = File.Create(debugFile_dtCurrentFile))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        //state machine start 
        //state machine end
    }
}
