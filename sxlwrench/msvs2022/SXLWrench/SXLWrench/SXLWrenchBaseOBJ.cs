using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SXLWrench
{
    internal class SXLWrenchBaseOBJ
    {
        string fileDTStamp = "";
        bool fpSwitch = false;
        string debugFile_dtCurrentPath = "";
        string debugFile_dtCurrentFile = "";

        public void setfileDTStamp()
        {
            fileDTStamp = "DT"; 
            ToolBox.AppendDebugFile("--- SXLWrenchBase ---", true); 
            Thread thread = new Thread(new ThreadStart(Worker)); 
            thread.Start(); ToolBox.AppendDebugFile("--- From DT Function ---", true);
        }
        public void Worker()
        {
            ToolBox.AppendDebugFile("--- Threaded Base ---", true);
        }
    }
}