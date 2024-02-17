using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Numba.Awaiting.Engine;
using UnityEngine;

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
        }
        public SXLWrenchBase(){
            
        }

    }
}