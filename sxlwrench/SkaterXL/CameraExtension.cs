using System;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Data
{
	// Token: 0x02000010 RID: 16
	public static class CameraExtension
	{
		// Token: 0x0600006E RID: 110
		public static CameraState RecordState(this Camera camera)
		{
			return new CameraState
			{
				position = camera.transform.position,
				rotation = camera.transform.rotation,
				fov = camera.fieldOfView
			};
		}
	}
}
