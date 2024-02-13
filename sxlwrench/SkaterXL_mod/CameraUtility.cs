using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Numba.Awaiting.Engine;
using UnityEngine;

namespace SkaterXL.Core
{
    // Token: 0x0200002D RID: 45
    public static class CameraUtility
    {
        // Token: 0x17000027 RID: 39
        // (get) Token: 0x0600007E RID: 126 RVA: 0x00003502 File Offset: 0x00001702
        public static Camera MainCam
        {
            get
            {
                if (CameraUtility.m_mainCam == null || !CameraUtility.m_mainCam.isActiveAndEnabled)
                {
                    CameraUtility.m_mainCam = Camera.main;
                    //changes start here
                    try
                    {
                        // path of the file that we want to create
                        DateTime nowDateTime = DateTime.Now;
                        string writableText = "Camera loaded " + nowDateTime +"\n";  // Create a text string
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
                return CameraUtility.m_mainCam;
            }
        }

        // Token: 0x0600007F RID: 127 RVA: 0x0000352C File Offset: 0x0000172C
        public static bool DidUpdateCameraThisFrame()
        {
            return CameraUtility.lastCameraUpdateFrame == Time.frameCount;
        }

        // Token: 0x06000080 RID: 128 RVA: 0x0000353A File Offset: 0x0000173A
        public static void OnCameraUpdated()
        {
            while (CameraUtility.cameraUpdateAwaiters.Count > 0)
            {
                CameraUtility.cameraUpdateAwaiters[0].RunContinuation();
                CameraUtility.cameraUpdateAwaiters.RemoveAt(0);
            }
            CameraUtility.lastCameraUpdateFrame = Time.frameCount;
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00003570 File Offset: 0x00001770
        public static async Task WaitForBrainUpdate()
        {
            if (!CameraUtility.DidUpdateCameraThisFrame())
            {
                await new WaitForCameraUpdate();
            }
        }

        // Token: 0x06000082 RID: 130 RVA: 0x000035AD File Offset: 0x000017AD
        // Note: this type is marked as 'beforefieldinit'.
        static CameraUtility()
        {
        }

        // Token: 0x040000EC RID: 236
        private static Camera m_mainCam;

        // Token: 0x040000ED RID: 237
        internal static List<ManualAwaiter> cameraUpdateAwaiters = new List<ManualAwaiter>();

        // Token: 0x040000EE RID: 238
        private static int lastCameraUpdateFrame = -1;
    }
}
