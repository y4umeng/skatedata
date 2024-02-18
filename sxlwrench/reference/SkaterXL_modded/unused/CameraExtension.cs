using System;
using UnityEngine;

namespace SkaterXL.Data
{
	// Token: 0x02000010 RID: 16
	public static class CameraExtension
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00003F08 File Offset: 0x00002108
		public static CameraState RecordState(this Camera camera)
		{
			SkaterXL.Core.SXLWrench.PushDataLocal("Camera Extension ", true);
			return new CameraState
			{
				position = camera.transform.position,
				rotation = camera.transform.rotation,
				fov = camera.fieldOfView
			};
		}
	}
}