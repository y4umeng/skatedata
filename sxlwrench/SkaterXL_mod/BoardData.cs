using System;
using System.IO;
using System.Text;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Gameplay
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public struct BoardData
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003EA RID: 1002
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
		// (get) Token: 0x060003EB RID: 1003
		public Vector3 TailCenter
		{
			get
			{
				return this.boardRigidbody.TransformPoint(new Vector3(0f, 0.01f, -0.33f));
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003EC RID: 1004
		public Vector3 NoseCenter
		{
			get
			{
				return this.boardRigidbody.TransformPoint(new Vector3(0f, 0.01f, 0.33f));
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003ED RID: 1005
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
		// (get) Token: 0x060003EE RID: 1006
		public float adjustedLocalXAccel
		{
			get
			{
				return this.boardRigidbody.InverseTransformDirection(this.adjustedAcceleration).x;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003EF RID: 1007
		public float localXAccel
		{
			get
			{
				return this.boardRigidbody.InverseTransformDirection(this.lastFrameAcceleration).x;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003F0 RID: 1008
		public bool AutoRevert
		{
			get
			{
				return (this.autoRampTags & AutoRampTags.AutoRevert) > AutoRampTags.None;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003F1 RID: 1009
		public bool AutoPump
		{
			get
			{
				return (this.autoRampTags & AutoRampTags.AutoPump) > AutoRampTags.None;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003F2 RID: 1010
		public Vector3 boardLocalGrindContactPoint
		{
			get
			{
				return this.boardRigidbody.InverseTransformPoint(this.boardCollision.grindableContactPoint ?? this.boardCollision.contactPoint);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003F3 RID: 1011
		public Vector3 backTruckLocalGrindContactPoint
		{
			get
			{
				return this.backTruckRigidbody.InverseTransformPoint(this.backTruckCollision.grindableContactPoint ?? this.backTruckCollision.contactPoint);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003F4 RID: 1012
		public Vector3 frontTruckLocalGrindContactPoint
		{
			get
			{
				return this.frontTruckRigidbody.InverseTransformPoint(this.frontTruckCollision.grindableContactPoint ?? this.frontTruckCollision.contactPoint);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003F5 RID: 1013
		public bool BoardColliding
		{
			get
			{
				return this.boardCollision.colliding;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003F6 RID: 1014
		public bool BackTruckColliding
		{
			get
			{
				return this.backTruckCollision.colliding;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003F7 RID: 1015
		public bool FrontTruckColliding
		{
			get
			{
				return this.frontTruckCollision.colliding;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003F8 RID: 1016
		public bool Colliding
		{
			get
			{
				return this.BackTruckColliding || this.FrontTruckColliding || this.BoardColliding;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003F9 RID: 1017
		public bool BoardCollisionEnter
		{
			get
			{
				return this.boardCollision.collisionEnter;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003FA RID: 1018
		public bool BackTruckCollisionEnter
		{
			get
			{
				return this.backTruckCollision.collisionEnter;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003FB RID: 1019
		public bool FrontTruckCollisionEnter
		{
			get
			{
				return this.frontTruckCollision.collisionEnter;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003FC RID: 1020
		public bool CollisionEnter
		{
			get
			{
				return this.BoardCollisionEnter || this.BackTruckCollisionEnter || this.FrontTruckCollisionEnter;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003FD RID: 1021
		public Vector3 backTruckWorldCenterOfMass
		{
			get
			{
				return this.backTruckRigidbody.TransformPoint(BoardData.backTruckCenterOfMass);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003FE RID: 1022
		public Vector3 frontTruckWorldCenterOfMass
		{
			get
			{
				return this.frontTruckRigidbody.TransformPoint(BoardData.frontTruckCenterOfMass);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003FF RID: 1023
		public Quaternion rotation
		{
			get
			{
				return this.GetRotation(this.IsBackwards);
			}
		}

		// Token: 0x06000400 RID: 1024
		public Quaternion GetRotation(bool isBackwards)
		{
			if (!isBackwards)
			{
				return this.boardRigidbody.rotation;
			}
			return this.boardRigidbody.rotation * Quaternion.Euler(0f, 180f, 0f);
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000401 RID: 1025
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
		// (get) Token: 0x06000402 RID: 1026
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

		// Token: 0x06000403 RID: 1027
		public Vector3 GetClosestBoardForwardToVelocity()
		{
			if (Vector3.Dot(this.boardRigidbody.forward, this.boardRigidbody.velocity) >= 0f)
			{
				return this.boardRigidbody.forward;
			}
			return -this.boardRigidbody.forward;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000404 RID: 1028
		public float xzRot
		{
			get
			{
				float num3 = Mathd.RepeatSignedAngle(this.boardRigidbody.rotation.eulerAngles.x);
				float num2 = Mathd.AngleBetween(this.CatchZAngle, this.boardRigidbody.rotation.eulerAngles.z);
				return Mathf.Sqrt(num3 * num3 + num2 * num2);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000405 RID: 1029
		public bool PrevAllWheelsDown
		{
			get
			{
				return this.prevWheelDown1 && this.prevWheelDown2 && this.prevWheelDown3 && this.prevWheelDown4;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000406 RID: 1030
		public bool PrevAnyWheelDown
		{
			get
			{
				return this.prevWheelDown1 || this.prevWheelDown2 || this.prevWheelDown3 || this.prevWheelDown4;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000407 RID: 1031
		public bool PrevTwoWheelsDown
		{
			get
			{
				return (this.prevWheelDown1 && this.prevWheelDown2) || (this.prevWheelDown3 && this.prevWheelDown4);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000408 RID: 1032
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
		// (get) Token: 0x06000409 RID: 1033
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
		// (get) Token: 0x0600040A RID: 1034
		public int WheelDownCount
		{
			get
			{
				return (this.wheelDown1 ? 1 : 0) + (this.wheelDown2 ? 1 : 0) + (this.wheelDown3 ? 1 : 0) + (this.wheelDown4 ? 1 : 0);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600040B RID: 1035
		public bool AllWheelsDown
		{
			get
			{
				return this.wheelDown1 && this.wheelDown2 && this.wheelDown3 && this.wheelDown4;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600040C RID: 1036
		public bool AnyWheelDown
		{
			get
			{
				return this.wheelDown1 || this.wheelDown2 || this.wheelDown3 || this.wheelDown4;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600040D RID: 1037
		public bool TwoWheelsDown
		{
			get
			{
				return (this.wheelDown1 && this.wheelDown2) || (this.wheelDown3 && this.wheelDown4);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600040E RID: 1038
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
		// (get) Token: 0x0600040F RID: 1039
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
		// (get) Token: 0x06000410 RID: 1040
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
		// (get) Token: 0x06000411 RID: 1041
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
		// (get) Token: 0x06000412 RID: 1042
		public bool FirstWheelDown
		{
			get
			{
				return this.AnyWheelDown && !this.PrevAnyWheelDown;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000413 RID: 1043
		public bool IsGrounded
		{
			get
			{
				return this.AnyWheelDown || this.darkDown1 || this.darkDown2 || this.primoDown1 || this.primoDown2;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000414 RID: 1044
		public bool PrevGrounded
		{
			get
			{
				return this.PrevAnyWheelDown;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000415 RID: 1045
		// (set) Token: 0x06000416 RID: 1046
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
		// (get) Token: 0x06000417 RID: 1047
		// (set) Token: 0x06000418 RID: 1048
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
		// (get) Token: 0x06000419 RID: 1049
		// (set) Token: 0x0600041A RID: 1050
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
		// (get) Token: 0x0600041B RID: 1051
		// (set) Token: 0x0600041C RID: 1052
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
		// (get) Token: 0x0600041D RID: 1053
		// (set) Token: 0x0600041E RID: 1054
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
		// (get) Token: 0x0600041F RID: 1055
		// (set) Token: 0x06000420 RID: 1056
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
		// (get) Token: 0x06000421 RID: 1057
		// (set) Token: 0x06000422 RID: 1058
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
		// (get) Token: 0x06000423 RID: 1059
		// (set) Token: 0x06000424 RID: 1060
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
		// (get) Token: 0x06000425 RID: 1061
		// (set) Token: 0x06000426 RID: 1062
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
		// (get) Token: 0x06000427 RID: 1063
		// (set) Token: 0x06000428 RID: 1064
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
		// (get) Token: 0x06000429 RID: 1065
		// (set) Token: 0x0600042A RID: 1066
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
		// (get) Token: 0x0600042B RID: 1067
		// (set) Token: 0x0600042C RID: 1068
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
		// (get) Token: 0x0600042D RID: 1069
		// (set) Token: 0x0600042E RID: 1070
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
		// (get) Token: 0x0600042F RID: 1071
		// (set) Token: 0x06000430 RID: 1072
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
		// (get) Token: 0x06000431 RID: 1073
		// (set) Token: 0x06000432 RID: 1074
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
		// (get) Token: 0x06000433 RID: 1075
		// (set) Token: 0x06000434 RID: 1076
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
		// (get) Token: 0x06000435 RID: 1077
		// (set) Token: 0x06000436 RID: 1078
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
		// (get) Token: 0x06000437 RID: 1079
		// (set) Token: 0x06000438 RID: 1080
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
		// (get) Token: 0x06000439 RID: 1081
		// (set) Token: 0x0600043A RID: 1082
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
		// (get) Token: 0x0600043B RID: 1083
		// (set) Token: 0x0600043C RID: 1084
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
		// (get) Token: 0x0600043D RID: 1085
		// (set) Token: 0x0600043E RID: 1086
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
		// (get) Token: 0x0600043F RID: 1087
		// (set) Token: 0x06000440 RID: 1088
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
		// (get) Token: 0x06000441 RID: 1089
		// (set) Token: 0x06000442 RID: 1090
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
		// (get) Token: 0x06000443 RID: 1091
		// (set) Token: 0x06000444 RID: 1092
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
		// (get) Token: 0x06000445 RID: 1093
		// (set) Token: 0x06000446 RID: 1094
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
		// (get) Token: 0x06000447 RID: 1095
		// (set) Token: 0x06000448 RID: 1096
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
		// (get) Token: 0x06000449 RID: 1097
		// (set) Token: 0x0600044A RID: 1098
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
		// (get) Token: 0x0600044B RID: 1099
		// (set) Token: 0x0600044C RID: 1100
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

		// Token: 0x0600044D RID: 1101
		public override string ToString()
		{
			return this.boardRigidbody.ToString();
		}

		// Token: 0x0600044E RID: 1102
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

		// Token: 0x0600044F RID: 1103
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

		// Token: 0x06000450 RID: 1104
		public void ResetBoardCenterOfMass()
		{
			this.boardRigidbody.centerOfMass = BoardData.boardCenterOfMass;
			this.backTruckRigidbody.centerOfMass = BoardData.backTruckCenterOfMass;
			this.frontTruckRigidbody.centerOfMass = BoardData.frontTruckCenterOfMass;
			this.CenterOfMassChanged = false;
		}

		// Token: 0x06000451 RID: 1105
		public void SetBoardCenterOfMass(Vector3 p_worldCOM)
		{
			this.boardRigidbody.centerOfMass = this.boardRigidbody.InverseTransformPoint(p_worldCOM);
			this.backTruckRigidbody.centerOfMass = this.backTruckRigidbody.InverseTransformPoint(p_worldCOM);
			this.frontTruckRigidbody.centerOfMass = this.frontTruckRigidbody.InverseTransformPoint(p_worldCOM);
			this.CenterOfMassChanged = true;
		}

		// Token: 0x06000452 RID: 1106
		public void OnImpact()
		{
			this.boardRigidbody.angularVelocity = Vector3.zero;
			this.backTruckRigidbody.angularVelocity = Vector3.zero;
			this.frontTruckRigidbody.angularVelocity = Vector3.zero;
			try
			{
				string writableText = "BoardData Function (OnImpact)\n";
				string debugFile_camera = "C:\\UnityWrench_data\\deBug.txt";
				DateTime now = DateTime.Now;
				if (File.Exists(debugFile_camera))
				{
					using (FileStream myfilestream = new FileStream(debugFile_camera, FileMode.Append))
					{
						byte[] info = new UTF8Encoding(true).GetBytes(writableText);
						myfilestream.Write(info, 0, info.Length);
						goto IL_A8;
					}
				}
				using (FileStream myfilestream2 = File.Create(debugFile_camera))
				{
					byte[] info2 = new UTF8Encoding(true).GetBytes(writableText);
					myfilestream2.Write(info2, 0, info2.Length);
				}
				IL_A8:;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000453 RID: 1107
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

		// Token: 0x06000454 RID: 1108
		public void LimitAngularVelocity(float _maxY)
		{
			this.LimitAngularVelocity(1E+09f, _maxY, 1E+09f);
		}

		// Token: 0x06000455 RID: 1109
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

		// Token: 0x06000456 RID: 1110
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
