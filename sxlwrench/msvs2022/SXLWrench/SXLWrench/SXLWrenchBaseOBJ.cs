using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SXLWrench
{
    public class SXLWrenchBaseOBJ : MonoBehaviour
    {
        public float timerTime = 0.0f;
        public long frameNumber = 0;
        public float frameRate = 30.0f;
        public void Awake()
        {
            ToolBox.AppendDebugFile("Frame Rate set to: " + frameRate.ToString(), true);
            frameRate = (1 / frameRate);
            ToolBox.AppendDebugFile("Frame Rate Value delaTime: " + frameRate.ToString(), true);

        }
        public void Update()
        {
            //works too slow for pulling frame updates
        }
        public void updateFrameValue()
        {
            //works no GameObject
        }
        public void FixedUpdate()
        {
            //ToolBox.AppendDebugFile(Time.deltaTime.ToString(), true);
            timerTime += Time.deltaTime;
            if ((timerTime + Time.deltaTime) >= frameRate)
            {
                ToolBox.AppendDebugFile(frameNumber.ToString(), true);
                frameNumber += 1;
                timerTime = 0.0f;
            }
        }

    }

}