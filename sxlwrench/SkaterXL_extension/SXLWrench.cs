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
        public static void PushText()
        {
            //changes start here
            try
            {
                // path of the file that we want to create
                DateTime nowDateTime = DateTime.Now;
                string writableText = "SXLWrench Loaded " + nowDateTime + "\n"; // Create a text string
                string debugFile_camera = @"C:\UnityWrench_data\deBug.txt";

                // Delete the file if it exists.
                if (File.Exists(debugFile_camera))
                {
                    //File.Delete(debugFile_camera);
                    using (FileStream myfilestream = new FileStream(debugFile_camera, FileMode.Append))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(writableText);
                        myfilestream.Write(info, 0, info.Length);
                    }
                }
                else
                {

                    using (FileStream myfilestream = File.Create(debugFile_camera))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(writableText);
                        myfilestream.Write(info, 0, info.Length);
                    }

                }
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
            }
            //changes end here
        }
    }
}