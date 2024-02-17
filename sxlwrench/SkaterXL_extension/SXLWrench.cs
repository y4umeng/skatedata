using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Numba.Awaiting.Engine;
using UnityEngine;

namespace SkaterXL.Core
{
    // Token: 0x02000078 RID: 120
    public static class SXLWrench
    {
        public static void initCurrentStatus() {
            DateTime nowDateTime = DateTime.Now;
            string newBasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string newPathDT = newBasePath + @"deBugClip_" + nowDateTime; 
            System.IO.Directory.CreateDirectory(Server.MapPath(newPathDT));

        }
        //need constructor here for dt
        public static void PushDataLocal()
        {
            try
            {
                DateTime nowDateTime = DateTime.Now;
                string outputText = "SXLWrench Loaded " + nowDateTime + "\n";
                string debugFile_dtCurrent = @"C:\UnityWrench_data\deBug.txt";
                // Delete the file if it exists.
                if (File.Exists(debugFile_dtCurrent))
                {
                    //File.Delete(debugFile_camera);
                    using (FileStream myfilestream = new FileStream(debugFile_dtCurrent, FileMode.Append))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    using (FileStream myfilestream = File.Create(debugFile_dtCurrent))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
        }
        public static void PushDataLocal(string outputCurrentDebug, bool dtSwitch)
        {
            try
            {
                string outputText = string.Empty;
                DateTime nowDateTime = DateTime.Now;
                string debugFile_dtCurrent = @"C:\UnityWrench_data\deBug.txt";
                if (dtSwitch)
                {
                    outputText = outputCurrentDebug + " " + nowDateTime + "\n";
                }
                else if (!dtSwitch)
                {
                    outputText = outputCurrentDebug + "\n";
                }
                if (File.Exists(debugFile_dtCurrent))
                {
                    //File.Delete(debugFile_camera);
                    using (FileStream myfilestream = new FileStream(debugFile_dtCurrent, FileMode.Append))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    using (FileStream myfilestream = File.Create(debugFile_dtCurrent))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(outputText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
        }
        //state machine start 
        //state machine end
    }
}