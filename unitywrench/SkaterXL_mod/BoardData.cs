using System;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Gameplay
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public struct BoardData
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00020694 File Offset: 0x0001E894
		public static BoardData Default
		{
			get
			{
				return new BoardData
				{
					boardRigidbody = new RigidbodyData(RigidbodyType.Board),
					backTruckRigidbody = new RigidbodyData(RigidbodyType.BackTruck),
					frontTruckRigidbody = new RigidbodyData(RigidbodyType.FrontTruck),
					boardControlLocalPosition = Vector3.zero,
					boardControlLocalRotation = Quaternion.identity,
					catchLocalRotation = Quaternion.identity,
					catchForwardLocalRotation = Quaternion.identity,
					CurrentRotationTarget = Quaternion.identity,
					LastPIDTarget = Quaternion.identity,
					FlipCollidersEnabled = true,
					FlipTriggerEnabled = false
				};
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00020729 File Offset: 0x0001E929
		public Vector3 TailCenter
		{
			get
			{
				return this.boardRigidbody.TransformPoint(new Vector3(0f, 0.01f, -0.33f));
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0002074A File Offset: 0x0001E94A
		public Vector3 NoseCenter
		{
			get
			{
				return this.boardRigidbody.TransformPoint(new Vector3(0f, 0.01f, 0.33f));
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x0002076C File Offset: 0x0001E96C
		public Vector3 adjustedAcceleration
		{
			get
			{
				Vector3 vector = this.boardRigidbody.InverseTransformDirection(Vector3.ProjectOnPlane(this.lastFrameAcceleration, this.boardRigidbody.velocity));
				vector = new Vector3(vector.x * 0.25f, vector.y, vector.z);
				vector = this.boardRigidbody.TransformDirection(vector);
				return vector;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x000207C8 File Offset: 0x0001E9C8
		public float adjustedLocalXAccel
		{
			get
			{
				return this.boardRigidbody.InverseTransformDirection(this.adjustedAcceleration).x;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x000207E0 File Offset: 0x0001E9E0
		public float localXAccel
		{
			get
			{
				return this.boardRigidbody.InverseTransformDirection(this.lastFrameAcceleration).x;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x000207F8 File Offset: 0x0001E9F8
		public bool AutoRevert
		{
			get
			{
				return (this.autoRampTags & AutoRampTags.AutoRevert) > AutoRampTags.None;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00020805 File Offset: 0x0001EA05
		public bool AutoPump
		{
			get
			{
				return (this.autoRampTags & AutoRampTags.AutoPump) > AutoRampTags.None;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00020814 File Offset: 0x0001EA14
		public Vector3 boardLocalGrindContactPoint
		{
			get
			{
				return this.boardRigidbody.InverseTransformPoint(this.boardCollision.grindableContactPoint ?? this.boardCollision.contactPoint);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00020858 File Offset: 0x0001EA58
		public Vector3 backTruckLocalGrindContactPoint
		{
			get
			{
				return this.backTruckRigidbody.InverseTransformPoint(this.backTruckCollision.grindableContactPoint ?? this.backTruckCollision.contactPoint);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0002089C File Offset: 0x0001EA9C
		public Vector3 frontTruckLocalGrindContactPoint
		{
			get
			{
				return this.frontTruckRigidbody.InverseTransformPoint(this.frontTruckCollision.grindableContactPoint ?? this.frontTruckCollision.contactPoint);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000208DD File Offset: 0x0001EADD
		public bool BoardColliding
		{
			get
			{
				return this.boardCollision.colliding;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x000208EA File Offset: 0x0001EAEA
		public bool BackTruckColliding
		{
			get
			{
				return this.backTruckCollision.colliding;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x000208F7 File Offset: 0x0001EAF7
		public bool FrontTruckColliding
		{
			get
			{
				return this.frontTruckCollision.colliding;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00020904 File Offset: 0x0001EB04
		public bool Colliding
		{
			get
			{
				return this.BackTruckColliding || this.FrontTruckColliding || this.BoardColliding;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0002091E File Offset: 0x0001EB1E
		public bool BoardCollisionEnter
		{
			get
			{
				return this.boardCollision.collisionEnter;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0002092B File Offset: 0x0001EB2B
		public bool BackTruckCollisionEnter
		{
			get
			{
				return this.backTruckCollision.collisionEnter;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00020938 File Offset: 0x0001EB38
		public bool FrontTruckCollisionEnter
		{
			get
			{
				return this.frontTruckCollision.collisionEnter;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x00020945 File Offset: 0x0001EB45
		public bool CollisionEnter
		{
			get
			{
				return this.BoardCollisionEnter || this.BackTruckCollisionEnter || this.FrontTruckCollisionEnter;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0002095F File Offset: 0x0001EB5F
		public Vector3 backTruckWorldCenterOfMass
		{
			get
			{
				return this.backTruckRigidbody.TransformPoint(BoardData.backTruckCenterOfMass);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00020971 File Offset: 0x0001EB71
		public Vector3 frontTruckWorldCenterOfMass
		{
			get
			{
				return this.frontTruckRigidbody.TransformPoint(BoardData.frontTruckCenterOfMass);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00020983 File Offset: 0x0001EB83
		public Quaternion rotation
		{
			get
			{
				return this.GetRotation(this.IsBackwards);
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00020991 File Offset: 0x0001EB91
		public Quaternion GetRotation(bool isBackwards)
		{
			if (!isBackwards)
			{
				return this.boardRigidbody.rotation;
			}
			return this.boardRigidbody.rotation * Quaternion.Euler(0f, 180f, 0f);
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x000209C6 File Offset: 0x0001EBC6
		public Vector3 forward
		{
			get
			{
				if (!this.IsBackwards)
				{
					return this.boardRigidbody.forward;
				}
				return -this.boardRigidbody.forward;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x000209EC File Offset: 0x0001EBEC
		public Vector3 right
		{
			get
			{
				if (!this.IsBackwards)
				{
					return this.boardRigidbody.right;
				}
				return -this.boardRigidbody.right;
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00020A12 File Offset: 0x0001EC12
		public Vector3 GetClosestBoardForwardToVelocity()
		{
			if (Vector3.Dot(this.boardRigidbody.forward, this.boardRigidbody.velocity) >= 0f)
			{
				return this.boardRigidbody.forward;
			}
			return -this.boardRigidbody.forward;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00020A54 File Offset: 0x0001EC54
		public float xzRot
		{
			get
			{
				float num = Mathd.RepeatSignedAngle(this.boardRigidbody.rotation.eulerAngles.x);
				float num2 = Mathd.AngleBetween(this.CatchZAngle, this.boardRigidbody.rotation.eulerAngles.z);
				return Mathf.Sqrt(num * num + num2 * num2);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00020AAD File Offset: 0x0001ECAD
		public bool PrevAllWheelsDown
		{
			get
			{
				return this.prevWheelDown1 && this.prevWheelDown2 && this.prevWheelDown3 && this.prevWheelDown4;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00020ACF File Offset: 0x0001ECCF
		public bool PrevAnyWheelDown
		{
			get
			{
				return this.prevWheelDown1 || this.prevWheelDown2 || this.prevWheelDown3 || this.prevWheelDown4;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x00020AF1 File Offset: 0x0001ECF1
		public bool PrevTwoWheelsDown
		{
			get
			{
				return (this.prevWheelDown1 && this.prevWheelDown2) || (this.prevWheelDown3 && this.prevWheelDown4);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00020B15 File Offset: 0x0001ED15
		public bool PrevFrontWheelsDown
		{
			get
			{
				if (!this.IsBackwards)
				{
					return this.prevWheelDown3 && this.prevWheelDown4;
				}
				return this.prevWheelDown1 && this.prevWheelDown2;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x00020B40 File Offset: 0x0001ED40
		public bool PrevBackWheelsDown
		{
			get
			{
				if (this.IsBackwards)
				{
					return this.prevWheelDown3 && this.prevWheelDown4;
				}
				return this.prevWheelDown1 && this.prevWheelDown2;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00020B6B File Offset: 0x0001ED6B
		public int WheelDownCount
		{
			get
			{
				return (this.wheelDown1 ? 1 : 0) + (this.wheelDown2 ? 1 : 0) + (this.wheelDown3 ? 1 : 0) + (this.wheelDown4 ? 1 : 0);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x00020BA0 File Offset: 0x0001EDA0
		public bool AllWheelsDown
		{
			get
			{
				return this.wheelDown1 && this.wheelDown2 && this.wheelDown3 && this.wheelDown4;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x00020BC2 File Offset: 0x0001EDC2
		public bool AnyWheelDown
		{
			get
			{
				return this.wheelDown1 || this.wheelDown2 || this.wheelDown3 || this.wheelDown4;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x00020BE4 File Offset: 0x0001EDE4
		public bool TwoWheelsDown
		{
			get
			{
				return (this.wheelDown1 && this.wheelDown2) || (this.wheelDown3 && this.wheelDown4);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00020C08 File Offset: 0x0001EE08
		public bool AnyFrontWheelDown
		{
			get
			{
				if (!this.IsBackwards)
				{
					return this.wheelDown3 || this.wheelDown4;
				}
				return this.wheelDown1 || this.wheelDown2;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00020C33 File Offset: 0x0001EE33
		public bool AnyBackWheelDown
		{
			get
			{
				if (this.IsBackwards)
				{
					return this.wheelDown3 || this.wheelDown4;
				}
				return this.wheelDown1 || this.wheelDown2;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00020C5E File Offset: 0x0001EE5E
		public bool FrontWheelsDown
		{
			get
			{
				if (!this.IsBackwards)
				{
					return this.wheelDown3 && this.wheelDown4;
				}
				return this.wheelDown1 && this.wheelDown2;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00020C89 File Offset: 0x0001EE89
		public bool BackWheelsDown
		{
			get
			{
				if (this.IsBackwards)
				{
					return this.wheelDown3 && this.wheelDown4;
				}
				return this.wheelDown1 && this.wheelDown2;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00020CB4 File Offset: 0x0001EEB4
		public bool FirstWheelDown
		{
			get
			{
				return this.AnyWheelDown && !this.PrevAnyWheelDown;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x00020CC9 File Offset: 0x0001EEC9
		public bool IsGrounded
		{
			get
			{
				return this.AnyWheelDown || this.darkDown1 || this.darkDown2 || this.primoDown1 || this.primoDown2;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00020CF3 File Offset: 0x0001EEF3
		public bool PrevGrounded
		{
			get
			{
				return this.PrevAnyWheelDown;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00020CFB File Offset: 0x0001EEFB
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x00020D03 File Offset: 0x0001EF03
		public Vector3 AnimBoardTargetPosition
		{
			get
			{
				return this.animBoardTargetPosition;
			}
			set
			{
				this.animBoardTargetPosition = value;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x00020D0C File Offset: 0x0001EF0C
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x00020D14 File Offset: 0x0001EF14
		public Quaternion AnimBoardTargetRotation
		{
			get
			{
				return this.animBoardTargetRotation;
			}
			set
			{
				this.animBoardTargetRotation = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x00020D1D File Offset: 0x0001EF1D
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x00020D25 File Offset: 0x0001EF25
		public Vector3 BoardControlLocalPosition
		{
			get
			{
				return this.boardControlLocalPosition;
			}
			set
			{
				this.boardControlLocalPosition = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x00020D2E File Offset: 0x0001EF2E
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x00020D36 File Offset: 0x0001EF36
		public Quaternion BoardControlLocalRotation
		{
			get
			{
				return this.boardControlLocalRotation;
			}
			set
			{
				this.boardControlLocalRotation = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00020D3F File Offset: 0x0001EF3F
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x00020D47 File Offset: 0x0001EF47
		public float CatchZAngle
		{
			get
			{
				return this.catchZAngle;
			}
			set
			{
				this.catchZAngle = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00020D50 File Offset: 0x0001EF50
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x00020D58 File Offset: 0x0001EF58
		public Quaternion CatchLocalRotation
		{
			get
			{
				return this.catchLocalRotation;
			}
			set
			{
				this.catchLocalRotation = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00020D61 File Offset: 0x0001EF61
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x00020D69 File Offset: 0x0001EF69
		public Quaternion CatchForwardLocalRotation
		{
			get
			{
				return this.catchForwardLocalRotation;
			}
			set
			{
				this.catchForwardLocalRotation = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00020D72 File Offset: 0x0001EF72
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x00020D7A File Offset: 0x0001EF7A
		public FrictionType FrictionType
		{
			get
			{
				return this.frictionType;
			}
			set
			{
				this.frictionType = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00020D83 File Offset: 0x0001EF83
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00020D8B File Offset: 0x0001EF8B
		public bool IsBackwards
		{
			get
			{
				return this.isBackwards;
			}
			set
			{
				this.isBackwards = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00020D94 File Offset: 0x0001EF94
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00020D9C File Offset: 0x0001EF9C
		public bool FrozenAfterRespawn
		{
			get
			{
				return this.frozenAfterRespawn;
			}
			set
			{
				this.frozenAfterRespawn = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00020DA5 File Offset: 0x0001EFA5
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x00020DAD File Offset: 0x0001EFAD
		public float CurrentPushForce
		{
			get
			{
				return this.currentPushForce;
			}
			set
			{
				this.currentPushForce = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00020DB6 File Offset: 0x0001EFB6
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x00020DBE File Offset: 0x0001EFBE
		public float WheelRollSpeed
		{
			get
			{
				return this.wheelRollSpeed;
			}
			set
			{
				this.wheelRollSpeed = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00020DC7 File Offset: 0x0001EFC7
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00020DCF File Offset: 0x0001EFCF
		public float WheelRPS
		{
			get
			{
				return this.wheelRPS;
			}
			set
			{
				this.wheelRPS = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x00020DD8 File Offset: 0x0001EFD8
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x00020DE0 File Offset: 0x0001EFE0
		public bool FlipTriggered
		{
			get
			{
				return this.flipTriggered;
			}
			set
			{
				this.flipTriggered = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00020DE9 File Offset: 0x0001EFE9
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00020DF1 File Offset: 0x0001EFF1
		public bool FlipCollidersEnabled
		{
			get
			{
				return this.flipCollidersEnabled;
			}
			set
			{
				this.flipCollidersEnabled = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00020DFA File Offset: 0x0001EFFA
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x00020E02 File Offset: 0x0001F002
		public bool FlipTriggerEnabled
		{
			get
			{
				return this.flipTriggerEnabled;
			}
			set
			{
				this.flipTriggerEnabled = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00020E0B File Offset: 0x0001F00B
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x00020E13 File Offset: 0x0001F013
		public bool RemovingTorque
		{
			get
			{
				return this.removingTorque;
			}
			set
			{
				this.removingTorque = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00020E1C File Offset: 0x0001F01C
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00020E24 File Offset: 0x0001F024
		public Quaternion CurrentRotationTarget
		{
			get
			{
				return this.currentRotationTarget;
			}
			set
			{
				this.currentRotationTarget = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00020E2D File Offset: 0x0001F02D
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x00020E35 File Offset: 0x0001F035
		public Vector3 CurrentPositionTarget
		{
			get
			{
				return this.currentPositionTarget;
			}
			set
			{
				this.currentPositionTarget = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00020E3E File Offset: 0x0001F03E
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00020E46 File Offset: 0x0001F046
		public Quaternion LastPIDTarget
		{
			get
			{
				return this.lastPIDTarget;
			}
			set
			{
				this.lastPIDTarget = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00020E4F File Offset: 0x0001F04F
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00020E57 File Offset: 0x0001F057
		public bool CenterOfMassChanged
		{
			get
			{
				return this.centerOfMassChanged;
			}
			set
			{
				this.centerOfMassChanged = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00020E60 File Offset: 0x0001F060
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00020E68 File Offset: 0x0001F068
		public Vector3 LastFrameAnimBoardTargetPos
		{
			get
			{
				return this.lastFrameAnimBoardTargetPos;
			}
			set
			{
				this.lastFrameAnimBoardTargetPos = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00020E71 File Offset: 0x0001F071
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00020E79 File Offset: 0x0001F079
		public Vector3 AnimBoardTargetVel
		{
			get
			{
				return this.animBoardTargetVel;
			}
			set
			{
				this.animBoardTargetVel = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00020E82 File Offset: 0x0001F082
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00020E8A File Offset: 0x0001F08A
		public Vector3 GroundNormal
		{
			get
			{
				return this.groundNormal;
			}
			set
			{
				this.groundNormal = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00020E93 File Offset: 0x0001F093
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00020E9B File Offset: 0x0001F09B
		public Vector3 GroundPoint
		{
			get
			{
				return this.groundPoint;
			}
			set
			{
				this.groundPoint = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00020EA4 File Offset: 0x0001F0A4
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x00020EAC File Offset: 0x0001F0AC
		public Vector3 PrevGroundNormal
		{
			get
			{
				return this.prevGroundNormal;
			}
			set
			{
				this.prevGroundNormal = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00020EB5 File Offset: 0x0001F0B5
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00020EBD File Offset: 0x0001F0BD
		public Vector3 LerpedGroundNormal
		{
			get
			{
				return this.lerpedGroundNormal;
			}
			set
			{
				this.lerpedGroundNormal = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00020EC6 File Offset: 0x0001F0C6
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00020ECE File Offset: 0x0001F0CE
		public float GroundY
		{
			get
			{
				return this.groundY;
			}
			set
			{
				this.groundY = value;
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00020ED7 File Offset: 0x0001F0D7
		public override string ToString()
		{
			return this.boardRigidbody.ToString();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00020EEC File Offset: 0x0001F0EC
		public void Transform(Vector3 origPoint, Vector3 newPoint, Quaternion rotationAroundPoint)
		{
			this.boardRigidbody.Transform(origPoint, newPoint, rotationAroundPoint);
			if (this.lastFramePosition.magnitude < 1E-05f)
			{
				this.lastFramePosition = this.boardRigidbody.position;
			}
			else
			{
				this.lastFramePosition = newPoint + rotationAroundPoint * (this.lastFramePosition - origPoint);
			}
			this.lastFrameVelocity = rotationAroundPoint * this.lastFrameVelocity;
			this.GroundY += newPoint.y - origPoint.y;
			this.backTruckRigidbody.Transform(origPoint, newPoint, rotationAroundPoint);
			this.frontTruckRigidbody.Transform(origPoint, newPoint, rotationAroundPoint);
			this.AnimBoardTargetPosition = this.AnimBoardTargetPosition.Transform(origPoint, newPoint, rotationAroundPoint);
			this.AnimBoardTargetRotation *= rotationAroundPoint;
			if (this.LastFrameAnimBoardTargetPos.magnitude < 1E-05f)
			{
				this.LastFrameAnimBoardTargetPos = this.AnimBoardTargetPosition;
			}
			else
			{
				this.LastFrameAnimBoardTargetPos = newPoint + rotationAroundPoint * (this.LastFrameAnimBoardTargetPos - origPoint);
			}
			this.AnimBoardTargetVel = rotationAroundPoint * this.AnimBoardTargetVel;
			this.CurrentPositionTarget = newPoint + rotationAroundPoint * (this.CurrentPositionTarget - origPoint);
			this.CurrentRotationTarget = rotationAroundPoint * this.CurrentRotationTarget;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0002103C File Offset: 0x0001F23C
		public void ApplyFriction(float velXfactor = 0.3f)
		{
			if (this.AllWheelsDown)
			{
				Vector3 dir = this.boardRigidbody.InverseTransformDirection(this.boardRigidbody.angularVelocity);
				dir.z *= 0.9f * Time.deltaTime * 120f;
				dir.x *= 0.9f * Time.deltaTime * 120f;
				this.boardRigidbody.angularVelocity = this.boardRigidbody.TransformDirection(dir);
			}
			Vector3 dir2 = this.boardRigidbody.InverseTransformDirection(this.boardRigidbody.velocity);
			dir2.x *= velXfactor;
			this.boardRigidbody.velocity = this.boardRigidbody.TransformDirection(dir2);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000210F1 File Offset: 0x0001F2F1
		public void ResetBoardCenterOfMass()
		{
			this.boardRigidbody.centerOfMass = BoardData.boardCenterOfMass;
			this.backTruckRigidbody.centerOfMass = BoardData.backTruckCenterOfMass;
			this.frontTruckRigidbody.centerOfMass = BoardData.frontTruckCenterOfMass;
			this.CenterOfMassChanged = false;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0002112C File Offset: 0x0001F32C
		public void SetBoardCenterOfMass(Vector3 p_worldCOM)
		{
			this.boardRigidbody.centerOfMass = this.boardRigidbody.InverseTransformPoint(p_worldCOM);
			this.backTruckRigidbody.centerOfMass = this.backTruckRigidbody.InverseTransformPoint(p_worldCOM);
			this.frontTruckRigidbody.centerOfMass = this.frontTruckRigidbody.InverseTransformPoint(p_worldCOM);
			this.CenterOfMassChanged = true;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00021185 File Offset: 0x0001F385
		public void OnImpact()
		{
			this.boardRigidbody.angularVelocity = Vector3.zero;
			this.backTruckRigidbody.angularVelocity = Vector3.zero;
			this.frontTruckRigidbody.angularVelocity = Vector3.zero;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000211B7 File Offset: 0x0001F3B7
		public void ReduceImpactBounce()
		{
			if (!this.RemovingTorque)
			{
				this.LimitAngularVelocity(5f);
			}
			else
			{
				this.LimitAngularVelocity(0f);
			}
			bool isGrounded = this.IsGrounded;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000211E0 File Offset: 0x0001F3E0
		public void LimitAngularVelocity(float _maxY)
		{
			this.LimitAngularVelocity(1E+09f, _maxY, 1E+09f);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000211F4 File Offset: 0x0001F3F4
		public void LimitAngularVelocity(float _maxX, float _maxY, float _maxZ)
		{
			Vector3 vector = this.boardRigidbody.InverseTransformDirection(this.boardRigidbody.angularVelocity);
			vector.x = Mathf.Clamp(vector.x, -_maxX, _maxX);
			vector.y = Mathf.Clamp(vector.y, -_maxY, _maxY);
			vector.z = Mathf.Clamp(vector.z, -_maxZ, _maxZ);
			this.boardRigidbody.angularVelocity = this.boardRigidbody.TransformDirection(vector);
			Vector3 vector2 = this.frontTruckRigidbody.InverseTransformDirection(this.frontTruckRigidbody.angularVelocity);
			vector2.x = Mathf.Clamp(vector2.x, -_maxX, _maxX);
			vector2.y = Mathf.Clamp(vector2.y, -_maxY, _maxY);
			vector2.z = Mathf.Clamp(vector2.z, -_maxZ, _maxZ);
			this.frontTruckRigidbody.angularVelocity = this.frontTruckRigidbody.TransformDirection(vector2);
			Vector3 vector3 = this.backTruckRigidbody.InverseTransformDirection(this.backTruckRigidbody.angularVelocity);
			vector3.x = Mathf.Clamp(vector3.x, -_maxX, _maxX);
			vector3.y = Mathf.Clamp(vector3.y, -_maxY, _maxY);
			vector3.z = Mathf.Clamp(vector3.z, -_maxZ, _maxZ);
			this.backTruckRigidbody.angularVelocity = this.backTruckRigidbody.TransformDirection(vector3);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00021348 File Offset: 0x0001F548
		// Note: this type is marked as 'beforefieldinit'.
		static BoardData()
		{
		}

		// Token: 0x04000319 RID: 793
		public static Vector3 boardCenterOfMass = new Vector3(-5.527703E-05f, -0.002571746f, -2.101702E-06f);

		// Token: 0x0400031A RID: 794
		public static Vector3 backTruckCenterOfMass = new Vector3(-0.0007130137f, -0.007236305f, 0.00851501f);

		// Token: 0x0400031B RID: 795
		public static Vector3 frontTruckCenterOfMass = new Vector3(-0.0003377593f, -0.01087169f, -0.008458457f);

		// Token: 0x0400031C RID: 796
		public RigidbodyData boardRigidbody;

		// Token: 0x0400031D RID: 797
		public PIDIntegrals boardPIDIntegrals;

		// Token: 0x0400031E RID: 798
		public RigidbodyData frontTruckRigidbody;

		// Token: 0x0400031F RID: 799
		public RigidbodyData backTruckRigidbody;

		// Token: 0x04000320 RID: 800
		[SerializeField]
		private Vector3 animBoardTargetPosition;

		// Token: 0x04000321 RID: 801
		[SerializeField]
		private Quaternion animBoardTargetRotation;

		// Token: 0x04000322 RID: 802
		[SerializeField]
		private Vector3 boardControlLocalPosition;

		// Token: 0x04000323 RID: 803
		[SerializeField]
		private Quaternion boardControlLocalRotation;

		// Token: 0x04000324 RID: 804
		[SerializeField]
		private float catchZAngle;

		// Token: 0x04000325 RID: 805
		[SerializeField]
		private Quaternion catchLocalRotation;

		// Token: 0x04000326 RID: 806
		[SerializeField]
		private Quaternion catchForwardLocalRotation;

		// Token: 0x04000327 RID: 807
		public JointDriveData frontTruckJoint;

		// Token: 0x04000328 RID: 808
		public JointDriveData backTruckJoint;

		// Token: 0x04000329 RID: 809
		[SerializeField]
		private bool centerOfMassChanged;

		// Token: 0x0400032A RID: 810
		[SerializeField]
		private FrictionType frictionType;

		// Token: 0x0400032B RID: 811
		[SerializeField]
		private bool isBackwards;

		// Token: 0x0400032C RID: 812
		[SerializeField]
		private bool frozenAfterRespawn;

		// Token: 0x0400032D RID: 813
		[SerializeField]
		private float currentPushForce;

		// Token: 0x0400032E RID: 814
		[SerializeField]
		private float wheelRollSpeed;

		// Token: 0x0400032F RID: 815
		[SerializeField]
		private float wheelRPS;

		// Token: 0x04000330 RID: 816
		[SerializeField]
		private bool flipTriggered;

		// Token: 0x04000331 RID: 817
		[SerializeField]
		private bool flipCollidersEnabled;

		// Token: 0x04000332 RID: 818
		[SerializeField]
		private bool flipTriggerEnabled;

		// Token: 0x04000333 RID: 819
		[SerializeField]
		private bool removingTorque;

		// Token: 0x04000334 RID: 820
		[SerializeField]
		private Quaternion currentRotationTarget;

		// Token: 0x04000335 RID: 821
		[SerializeField]
		private Vector3 currentPositionTarget;

		// Token: 0x04000336 RID: 822
		[SerializeField]
		private Quaternion lastPIDTarget;

		// Token: 0x04000337 RID: 823
		[SerializeField]
		private Vector3 lastFrameAnimBoardTargetPos;

		// Token: 0x04000338 RID: 824
		[SerializeField]
		private Vector3 animBoardTargetVel;

		// Token: 0x04000339 RID: 825
		public Vector3 lastFramePosition;

		// Token: 0x0400033A RID: 826
		public Vector3 lastFrameVelocity;

		// Token: 0x0400033B RID: 827
		public Vector3 lastFrameAcceleration;

		// Token: 0x0400033C RID: 828
		public bool prevWheelDown1;

		// Token: 0x0400033D RID: 829
		public bool prevWheelDown2;

		// Token: 0x0400033E RID: 830
		public bool prevWheelDown3;

		// Token: 0x0400033F RID: 831
		public bool prevWheelDown4;

		// Token: 0x04000340 RID: 832
		public bool wheelDown1;

		// Token: 0x04000341 RID: 833
		public bool wheelDown2;

		// Token: 0x04000342 RID: 834
		public bool wheelDown3;

		// Token: 0x04000343 RID: 835
		public bool wheelDown4;

		// Token: 0x04000344 RID: 836
		public bool primoDown1;

		// Token: 0x04000345 RID: 837
		public bool primoDown2;

		// Token: 0x04000346 RID: 838
		public bool darkDown1;

		// Token: 0x04000347 RID: 839
		public bool darkDown2;

		// Token: 0x04000348 RID: 840
		public AutoRampTags autoRampTags;

		// Token: 0x04000349 RID: 841
		[SerializeField]
		private Vector3 groundNormal;

		// Token: 0x0400034A RID: 842
		[SerializeField]
		private Vector3 groundPoint;

		// Token: 0x0400034B RID: 843
		[SerializeField]
		private Vector3 prevGroundNormal;

		// Token: 0x0400034C RID: 844
		[SerializeField]
		private Vector3 lerpedGroundNormal;

		// Token: 0x0400034D RID: 845
		[SerializeField]
		private float groundY;

		// Token: 0x0400034E RID: 846
		public Vector3 LastInAirVelocity;

		// Token: 0x0400034F RID: 847
		public Vector3 LastBoardUpWhenAllDown;

		// Token: 0x04000350 RID: 848
		public Vector3 LastGroundNormalWhenAllDown;

		// Token: 0x04000351 RID: 849
		public Vector3 LastGroundNormalWhenGrounded;

		// Token: 0x04000352 RID: 850
		public CollisionData boardCollision;

		// Token: 0x04000353 RID: 851
		public CollisionData backTruckCollision;

		// Token: 0x04000354 RID: 852
		public CollisionData frontTruckCollision;
	}
}
