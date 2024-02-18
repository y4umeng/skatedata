using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXLWrench
{
    
    public static class ToolBox
    {
        private static string fileDTStamp = "";
        private static bool fpSwitch = false;
        private static string debugFile_dtCurrentPath = "";
        private static string debugFile_dtCurrentFile;
        private static string cleanDTGroup(bool yon)
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
                    string newBasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string newPathDT = newBasePath + @"\SXLWrenchFiles\deBugClip" + fileDTStamp;
                    System.IO.Directory.CreateDirectory(newPathDT);
                    debugFile_dtCurrentPath = newPathDT;
                    debugFile_dtCurrentFile = debugFile_dtCurrentPath + @"\deBugClip" + fileDTStamp;
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
