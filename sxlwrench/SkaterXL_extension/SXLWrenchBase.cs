using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Numba.Awaiting.Engine;
using UnityEngine;
using UnityEngine.UI;

namespace SkaterXL.Core
{
    // Token: 0x02000070 RID: 112
    public class SXLWrenchBase
    {
        string fileDTStamp = "";
        bool fpSwitch = false;
        string debugFile_dtCurrentPath = "";
        string debugFile_dtCurrentFile = "";

        public void setfileDTStamp()
        {
            fileDTStamp = "DT";
            SXLWrench.PushDataLocal("--- SXLWrenchBase ---", true);
            Thread thread = new Thread(new ThreadStart(Worker));
            thread.Start();
            SXLWrench.PushDataLocal("--- From DT Function ---", true);

        }
        public void Worker() {
            SXLWrench.PushDataLocal("--- Threaded Base ---", true);
        }
        public SXLWrenchBase()
        {
        }
    }
}