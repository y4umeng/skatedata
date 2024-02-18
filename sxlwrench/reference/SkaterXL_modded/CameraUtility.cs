using System;
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
		// (get) Token: 0x0600007E RID: 126
		public static Camera MainCam
		{
			get
			{
				if (CameraUtility.m_mainCam == null || !CameraUtility.m_mainCam.isActiveAndEnabled)
				{
					CameraUtility.m_mainCam = Camera.main;
					SXLWrench.initCurrentStatus();
					new SXLWrenchBase().setfileDTStamp();
				}
				return CameraUtility.m_mainCam;
			}
		}

		// Token: 0x0600007F RID: 127
		public static bool DidUpdateCameraThisFrame()
		{
			return CameraUtility.lastCameraUpdateFrame == Time.frameCount;
		}

		// Token: 0x06000080 RID: 128
		public static void OnCameraUpdated()
		{
			while (CameraUtility.cameraUpdateAwaiters.Count > 0)
			{
				CameraUtility.cameraUpdateAwaiters[0].RunContinuation();
				CameraUtility.cameraUpdateAwaiters.RemoveAt(0);
			}
			CameraUtility.lastCameraUpdateFrame = Time.frameCount;
		}

		// Token: 0x06000081 RID: 129
		public static async Task WaitForBrainUpdate()
		{
			if (!CameraUtility.DidUpdateCameraThisFrame())
			{
				await new WaitForCameraUpdate();
			}
		}

		// Token: 0x06000082 RID: 130
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
