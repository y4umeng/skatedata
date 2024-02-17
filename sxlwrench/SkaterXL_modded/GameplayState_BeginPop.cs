using System;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Gameplay
{
	// Token: 0x020000BB RID: 187
	public class GameplayState_BeginPop : GameplayState_OnBoard
	{
		// Token: 0x060008EB RID: 2283 RVA: 0x00007F59 File Offset: 0x00006159
		public GameplayState_BeginPop()
		{
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x00002871 File Offset: 0x00000A71
		public override PlayerStateEnum StateEnum
		{
			get
			{
				return PlayerStateEnum.BeginPop;
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0002C32C File Offset: 0x0002A52C
		public override void Enter()
		{
			SXLWrench.PushDataLocal("BoardData Function (GameplayState_BeginPop)!", true);
			base.Enter();
			if (base.player.turn.Mode != TurningMode.FastLeft && base.player.turn.Mode != TurningMode.FastRight)
			{
				base.player.turn.Mode = TurningMode.InAir;
			}
			base.player.MovementMaster = MovementMaster.Target;
			base.player.air.PopRotationDone = false;
			base.player.air.KickAddSoFar = 0f;
			base.player.camera.NeedToSlowLerpCamera = true;
			base.player.board.FlipTriggerEnabled = true;
			base.player.board.FlipCollidersEnabled = false;
			this._velocityOnBeginPop = base.player.board.boardRigidbody.velocity;
			if (base.player.WasInGrindState())
			{
				this._velocityOnBeginPop = Vector3.Project(this._velocityOnBeginPop, base.player.grind.splineDirection);
			}
			base.player.sound.PlayMovementFoleySound(0.3f, true);
			base.player.ik.FeetLerpSpeed = 4f;
			base.player.SetBoardControllerUpVector(base.player.skater.skaterRigidbody.up, 10f);
			base.player.animation.InAirTurn = 0f;
			base.player.ik.ForceKneeIKWeight(1f);
			base.player.air.PopType = PopType.Ollie;
			bool flag;
			if (base.player.WasInGrindState())
			{
				flag = base.player.IsGrindingBackwards();
			}
			else
			{
				flag = base.player.IsSwitch;
			}
			if (!flag)
			{
				base.player.air.PopType = (base.player.air.ForwardLoad ? PopType.Nollie : PopType.Ollie);
			}
			else
			{
				base.player.air.PopType = (base.player.air.ForwardLoad ? PopType.Switch : PopType.Fakie);
			}
			base.player.skater.RightFootColliderActive = false;
			base.player.skater.LeftFootColliderActive = false;
			base.player.animation.UpAxisTarget = 0.5f;
			base.player.ragdoll.BoostImmunity(1000f);
			base.player.animation.CrossFade("Pop", 0.04f);
			base.player.ScaleCOMDisplacementCurve(Vector3.ProjectOnPlane(base.player.skater.skaterRigidbody.position - base.player.board.boardRigidbody.position, base.player.skater.skaterRigidbody.forward).magnitude + 0.0935936f);
			base.player.tweak.Reset();
			base.player.CacheBoardUp();
			base.player.UpdateReferenceBoardTargetRotation();
			base.player.KickAdd();
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0002C620 File Offset: 0x0002A820
		public override void Exit()
		{
			base.Exit();
			base.player.air.VelocityOnPop = base.player.board.boardRigidbody.velocity;
			base.player.camera.NeedToSlowLerpCamera = false;
			base.player.board.FlipTriggerEnabled = false;
			if (base.player.nextState != PlayerStateEnum.Pop)
			{
				base.player.ResetAugmentedAngle();
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0002C694 File Offset: 0x0002A894
		public override void Update()
		{
			base.Update();
			if (Mathf.Abs(base.player.air.ScoopSpeed) > 5f)
			{
				base.player.ik.FeetLerpSpeed = 8f;
			}
			base.player.OnFlipStickUpdate(false);
			base.player.OnPopStickUpdate(10f);
			base.player.LerpLeftIKOffset(false, base.player.animation.Released);
			base.player.LerpRightIKOffset(false, base.player.animation.Released);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00007F6C File Offset: 0x0000616C
		public override void LateUpdate()
		{
			base.LateUpdate();
			if (base.player.animation.animUpdateType == UpdateType.Late)
			{
				this.AdjustKneeTarget();
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0002C72C File Offset: 0x0002A92C
		public override void FixedUpdate()
		{
			if (this._isRespawning)
			{
				return;
			}
			base.FixedUpdate();
			base.player.ScalePlayerCollider();
			base.player.SetBoardRotationTarget();
			base.player.UpdateCOM();
			base.player.AddUpwardDisplacement(base.player.timeInState);
			if (base.player.timeInState <= 0.06f)
			{
				base.player.KickAdd();
				base.player.RotateBoard(true, false);
				if (base.player.BoardDisplacement.magnitude > 0.2f)
				{
					base.player.SnapBoardPosition();
				}
				if (base.player.air.WasGrindingOnPop)
				{
					base.player.ForceBoardPosition();
				}
			}
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0002C7EC File Offset: 0x0002A9EC
		public override void LateFixedUpdate()
		{
			base.LateFixedUpdate();
			if (base.player.animation.animUpdateType == UpdateType.LateFixed)
			{
				this.AdjustKneeTarget();
			}
			base.player.board.FlipCollidersEnabled = base.player.board.FlipTriggered;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0002C838 File Offset: 0x0002AA38
		private void AdjustKneeTarget()
		{
			if (base.player.controllerInput.IsRightStickPopFoot)
			{
				PlayerData player = base.player;
				player.ik.leftKneeTarget.position = player.ik.leftKneeTarget.position + base.player.skater.skaterRigidbody.up;
				return;
			}
			PlayerData player2 = base.player;
			player2.ik.rightKneeTarget.position = player2.ik.rightKneeTarget.position + base.player.skater.skaterRigidbody.up;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0002C8C4 File Offset: 0x0002AAC4
		public override bool CheckForStateTransitionFixed()
		{
			if (base.CheckForStateTransitionFixed())
			{
				return true;
			}
			if (base.player.timeInState > 1f)
			{
				base.player.animation.PopInterrupted = true;
				this.DoTransition(new GameplayState_Riding());
				return true;
			}
			if (base.player.timeInState > 0.06f)
			{
				this.TransitionToPop();
				return true;
			}
			if (base.player.BoardDisplacement.magnitude > 0.5f)
			{
				base.ForceBail();
				return true;
			}
			return false;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00007F8D File Offset: 0x0000618D
		public override void OnAnimatorEvent(AnimationEventType eventType, string p_string, float p_float, float p_int)
		{
			base.OnAnimatorEvent(eventType, p_string, p_float, p_int);
			if (eventType == AnimationEventType.Pop)
			{
				this.TransitionToPop();
			}
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0002C94C File Offset: 0x0002AB4C
		public void TransitionToPop()
		{
			if (!base.player.air.WasGrindingOnPop)
			{
				base.player.animation.Setup = false;
				base.player.OnPop();
				this.DoTransition(new GameplayState_Pop());
				return;
			}
			Vector3 vector = Vector3.ProjectOnPlane(base.player.grind.splineRight, Vector3.up).normalized;
			if (base.player.grind.SideEntered == SideEnteredGrind.Left)
			{
				vector = -vector;
			}
			Vector3 p_popOutDir = vector;
			base.player.animation.Setup = false;
			if (base.player.grind.SideEntered != SideEnteredGrind.Center)
			{
				base.player.OnPop(base.player.controllerInput.PopStick.AugmentedToeAxisVel, p_popOutDir);
			}
			else
			{
				base.player.OnPop();
			}
			this.DoTransition(new GameplayState_Pop());
		}

		// Token: 0x04000769 RID: 1897
		private Vector3 _velocityOnBeginPop = Vector3.zero;

		// Token: 0x0400076A RID: 1898
		private bool _isRespawning;
	}
}
