using System;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Data
{
	// Token: 0x02000077 RID: 119
	public struct RespawnInfo
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000360 RID: 864
		public Quaternion playerRotation
		{
			get
			{
				if (!this.isSwitch)
				{
					return this.rotation;
				}
				return this.rotation * Quaternion.Euler(0f, 180f, 0f);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000361 RID: 865
		public Vector3 pinPosition
		{
			get
			{
				return this.position + Vector3.up * 1.05f;
			}
		}

		// Token: 0x06000362 RID: 866
		public RespawnInfo(Vector3 spawnPosition, Quaternion spawnRotation, bool spawnSwitch = false)
		{
			this.position = spawnPosition;
			this.rotation = Quaternion.LookRotation(spawnRotation * Vector3.forward, Vector3.up);
			this.IsBoardBackwards = false;
			this.isSwitch = spawnSwitch;
		}

		// Token: 0x06000363 RID: 867
		public static RespawnInfo? GetMapSpawnPoint(bool spawnSwitch = false)
		{
			GameObject gameObject = GameObject.FindWithTag("SpawnPoint") ?? GameObject.Find("SpawnPoint");
			Transform transform = (gameObject != null) ? gameObject.transform : null;
			if (transform == null)
			{
				return null;
			}
			return new RespawnInfo?(RespawnInfo.GetGroundedSpawnPoint(transform, spawnSwitch));
		}

		// Token: 0x06000364 RID: 868
		public static RespawnInfo GetGroundedSpawnPoint(Transform spawnPoint, bool spawnSwitch = false)
		{
			return RespawnInfo.GetGroundedSpawnPoint(spawnPoint.position, spawnPoint.rotation, spawnSwitch);
		}

		// Token: 0x06000365 RID: 869
		public static RespawnInfo GetGroundedSpawnPoint(Vector3 position, Quaternion rotation, bool spawnSwitch = false)
		{
			position = RespawnInfo.MoveToGround(position, rotation);
			return new RespawnInfo(position, rotation, spawnSwitch);
		}

		// Token: 0x06000366 RID: 870
		public static Vector3 MoveToGround(Vector3 point, Quaternion rotation)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(point + Vector3.up * 0.05f, rotation * Vector3.down, out raycastHit, 10f, LayerUtility.GroundMask))
			{
				return raycastHit.point;
			}
			return point;
		}

		// Token: 0x04000190 RID: 400
		public Vector3 position;

		// Token: 0x04000191 RID: 401
		public Quaternion rotation;

		// Token: 0x04000192 RID: 402
		public bool IsBoardBackwards;

		// Token: 0x04000193 RID: 403
		public bool isSwitch;
	}
}
