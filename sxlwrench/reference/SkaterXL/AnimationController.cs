using System;
using RootMotion.Dynamics;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Gameplay
{
	// Token: 0x02000025 RID: 37
	public class AnimationController : GameplayComponent
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00002871 File Offset: 0x00000A71
		public override short ExecutionOrder
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000DD2C File Offset: 0x0000BF2C
		private void OnEnable()
		{
			this.skaterAnim.enabled = true;
			this.ikAnim.enabled = true;
			this.steezeAnim.enabled = true;
			this.skaterAnim.updateMode = AnimatorUpdateMode.AnimatePhysics;
			this.ikAnim.updateMode = AnimatorUpdateMode.AnimatePhysics;
			this.steezeAnim.updateMode = AnimatorUpdateMode.AnimatePhysics;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000DD84 File Offset: 0x0000BF84
		public override void CollectData(PlayerData player, bool collectAll = false)
		{
			player.animation.ResetChangeCheck();
			if (collectAll)
			{
				this.skaterAnim.GetData(ref player.animation);
				player.animation.FrontUpAxis = this.steezeAnim.GetFloat("FrontUpAxis");
				player.animation.BackUpAxis = this.steezeAnim.GetFloat("BackUpAxis");
				player.animation.SetupBase = 0.5f;
			}
			if (player.updateType == UpdateType.Late)
			{
				player.animation.animationEvents = this.cachedAnimationEvents;
				this.cachedAnimationEvents.Clear();
			}
			player.animation.animUpdateType = ((this.skaterAnim.updateMode == AnimatorUpdateMode.AnimatePhysics) ? UpdateType.LateFixed : UpdateType.Late);
			if (collectAll || player.updateType == player.animation.animUpdateType)
			{
				player.animation.skaterAnimState = this.skaterAnim.GetCurrentAnimatorStateInfo(0);
				player.animation.skaterAnimNextState = this.skaterAnim.GetNextAnimatorStateInfo(0);
				AnimatorTransitionInfo animatorTransitionInfo = this.skaterAnim.GetAnimatorTransitionInfo(0);
				player.animation.skaterAnimStateTransitionDuration = animatorTransitionInfo.duration;
				player.animation.skaterAnimStateTransitionTime = animatorTransitionInfo.normalizedTime;
				player.animation.ikAnimState = this.ikAnim.GetCurrentAnimatorStateInfo(0);
				player.animation.ikAnimNextState = this.ikAnim.GetNextAnimatorStateInfo(0);
				AnimatorTransitionInfo animatorTransitionInfo2 = this.ikAnim.GetAnimatorTransitionInfo(0);
				player.animation.ikAnimStateTransitionDuration = animatorTransitionInfo2.duration;
				player.animation.ikAnimStateTransitionTime = animatorTransitionInfo2.normalizedTime;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000DF24 File Offset: 0x0000C124
		public override void ApplyData(PlayerData player, bool applyAll = false)
		{
			player.animation.animationEvents.Clear();
			if (applyAll)
			{
				this.skaterAnim.enabled = (player.ragdoll.puppetState == PuppetMaster.State.Alive);
			}
			if (player.animation.crossFade.called)
			{
				this.skaterAnim.CrossFadeInFixedTime(player.animation.crossFade.parameter1, player.animation.crossFade.parameter2);
				this.ikAnim.CrossFadeInFixedTime(player.animation.crossFade.parameter1, player.animation.crossFade.parameter2);
			}
			if (player.animation.forceAnimation.called)
			{
				this.skaterAnim.Play(player.animation.forceAnimation.parameter1, 0, 0f);
				this.ikAnim.Play(player.animation.forceAnimation.parameter1, 0, 0f);
			}
			if (applyAll)
			{
				if (player.animation.skaterAnimState.fullPathHash == 0)
				{
					this.skaterAnim.Play("Riding", 0);
					this.ikAnim.Play("Riding", 0);
					this.steezeAnim.Play("Riding", 0);
				}
				else
				{
					if (player.animation.skaterAnimState.fullPathHash != 0)
					{
						this.skaterAnim.Play(player.animation.skaterAnimState.fullPathHash, 0, player.animation.skaterAnimState.normalizedTime);
						if (player.animation.skaterAnimNextState.fullPathHash != 0)
						{
							this.skaterAnim.CrossFadeInFixedTime(player.animation.skaterAnimNextState.fullPathHash, player.animation.skaterAnimStateTransitionDuration, 0, 0f, player.animation.skaterAnimStateTransitionTime);
						}
					}
					if (player.animation.ikAnimState.fullPathHash != 0)
					{
						this.ikAnim.Play(player.animation.ikAnimState.fullPathHash, 0, player.animation.ikAnimState.normalizedTime);
						if (player.animation.ikAnimNextState.fullPathHash != 0)
						{
							this.ikAnim.CrossFadeInFixedTime(player.animation.ikAnimNextState.fullPathHash, player.animation.ikAnimStateTransitionDuration, 0, 0f, player.animation.ikAnimStateTransitionTime);
						}
					}
				}
				if (player.currentState != PlayerStateEnum.Bailed)
				{
					this.skaterAnim.Update(0.001f);
					this.ikAnim.Update(0.001f);
					this.steezeAnim.Update(0.001f);
				}
			}
			if (!applyAll && player.updateType != ((this.skaterAnim.updateMode == AnimatorUpdateMode.AnimatePhysics) ? UpdateType.Fixed : UpdateType.Normal))
			{
				return;
			}
			this.skaterAnim.ApplyData(player.animation, this.currentData, applyAll, true);
			this.ikAnim.ApplyData(player.animation, this.currentData, applyAll, false);
			if (applyAll || player.animation.Nollie != this.currentData.Nollie)
			{
				this.steezeAnim.SetFloat("Nollie", player.animation.Nollie);
			}
			if (applyAll || player.animation.FrontToeAxis != this.currentData.FrontToeAxis)
			{
				this.steezeAnim.SetFloat("FrontToeAxis", player.animation.FrontToeAxis);
			}
			if (applyAll || player.animation.FrontForwardAxis != this.currentData.FrontForwardAxis)
			{
				this.steezeAnim.SetFloat("FrontForwardAxis", player.animation.FrontForwardAxis);
			}
			if (applyAll || player.animation.BackToeAxis != this.currentData.BackToeAxis)
			{
				this.steezeAnim.SetFloat("BackToeAxis", player.animation.BackToeAxis);
			}
			if (applyAll || player.animation.BackForwardAxis != this.currentData.BackForwardAxis)
			{
				this.steezeAnim.SetFloat("BackForwardAxis", player.animation.BackForwardAxis);
			}
			if (applyAll || player.animation.FrontToeVelocity != this.currentData.FrontToeVelocity)
			{
				this.steezeAnim.SetFloat("FrontToeVelocity", player.animation.FrontToeVelocity);
			}
			if (applyAll || player.animation.FrontForwardVelocity != this.currentData.FrontForwardVelocity)
			{
				this.steezeAnim.SetFloat("FrontForwardVelocity", player.animation.FrontForwardVelocity);
			}
			if (applyAll || player.animation.BackToeVelocity != this.currentData.BackToeVelocity)
			{
				this.steezeAnim.SetFloat("BackToeVelocity", player.animation.BackToeVelocity);
			}
			if (applyAll || player.animation.BackForwardVelocity != this.currentData.BackForwardVelocity)
			{
				this.steezeAnim.SetFloat("BackForwardVelocity", player.animation.BackForwardVelocity);
			}
			if (applyAll || player.animation.FrontUpAxis != this.currentData.FrontUpAxis)
			{
				this.steezeAnim.SetFloat("FrontUpAxis", player.animation.FrontUpAxis);
			}
			if (applyAll || player.animation.BackUpAxis != this.currentData.BackUpAxis)
			{
				this.steezeAnim.SetFloat("BackUpAxis", player.animation.BackUpAxis);
			}
			if (applyAll || player.animation.GrabHandFloat != this.currentData.GrabHandFloat)
			{
				this.steezeAnim.SetFloat("GrabHand", player.animation.GrabHandFloat);
			}
			if (applyAll || player.animation.GrabPointX != this.currentData.GrabPointX)
			{
				this.steezeAnim.SetFloat("GrabPointX", player.animation.GrabPointX);
			}
			if (applyAll || player.animation.GrabPointY != this.currentData.GrabPointY)
			{
				this.steezeAnim.SetFloat("GrabPointY", player.animation.GrabPointY);
			}
			if (applyAll || player.animation.LeftGrabOffset != this.currentData.LeftGrabOffset)
			{
				this.leftHandIKAnim.SetFloat("X", player.animation.LeftGrabOffset.x);
				this.leftHandIKAnim.SetFloat("Y", player.animation.LeftGrabOffset.y);
			}
			if (applyAll || player.animation.RightGrabOffset != this.currentData.RightGrabOffset)
			{
				this.rightHandIKAnim.SetFloat("X", player.animation.RightGrabOffset.x);
				this.rightHandIKAnim.SetFloat("Y", player.animation.RightGrabOffset.y);
			}
			if (applyAll || this.currentStance != player.stance)
			{
				this.currentStance = player.stance;
				this.skaterAnim.SetBool("Goofy", player.stance == Stance.Goofy);
				this.ikAnim.SetBool("Goofy", player.stance == Stance.Goofy);
				this.steezeAnim.SetBool("Goofy", player.stance == Stance.Goofy);
				this.skaterAnim.SetFloat("GoofyCycleOffset", (player.stance == Stance.Goofy) ? 0.5f : 0f);
				this.ikAnim.SetFloat("GoofyCycleOffset", (player.stance == Stance.Goofy) ? 0.5f : 0f);
				this.steezeAnim.SetFloat("GoofyCycleOffset", (player.stance == Stance.Goofy) ? 0.5f : 0f);
			}
			this.currentData = player.animation;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002874 File Offset: 0x00000A74
		public void QueueAnimationEvent(AnimationEventData animationEventData)
		{
			this.cachedAnimationEvents.Add(animationEventData);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000E69C File Offset: 0x0000C89C
		public void SendEventPop(AnimationEvent p_animationEvent)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.Pop,
				p_string = p_animationEvent.stringParameter
			});
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		public void SendEventBeginPop(string p_animName)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.BeginPop,
				p_string = p_animName
			});
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000E6FC File Offset: 0x0000C8FC
		public void SendEventImpactEnd(string p_animName)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.ImpactEnd,
				p_string = p_animName
			});
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000E728 File Offset: 0x0000C928
		public void SendEventPush(string p_animName)
		{
			AnimationClip clip = this.skaterAnim.GetCurrentAnimatorClipInfo(0).MaxElement((AnimatorClipInfo c) => c.weight).clip;
			this.pushAnimName = (((clip != null) ? clip.name : null) ?? "NULL");
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.PushStart,
				p_string = p_animName
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000E7A8 File Offset: 0x0000C9A8
		public void SendEventLastPushCheck(string p_animName)
		{
			if (p_animName != this.pushAnimName)
			{
				return;
			}
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.PushLastCheck,
				p_string = p_animName
			});
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000E7E4 File Offset: 0x0000C9E4
		public void SendEventPushEnd(string p_animName)
		{
			if (p_animName != this.pushAnimName)
			{
				return;
			}
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.PushEnd,
				p_string = p_animName
			});
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000E820 File Offset: 0x0000CA20
		public void SendEventExtend(AnimationEvent p_animationEvent)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.Extend,
				p_string = p_animationEvent.stringParameter,
				p_float = p_animationEvent.floatParameter,
				p_int = p_animationEvent.intParameter
			});
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000E86C File Offset: 0x0000CA6C
		public void SendEventReleased(string p_animName)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.Released,
				p_string = p_animName
			});
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000E898 File Offset: 0x0000CA98
		public void SendEventEndFlipPeriod(string p_animName)
		{
			this.QueueAnimationEvent(new AnimationEventData
			{
				animationType = AnimationEventType.EndFlipPeriod,
				p_string = p_animName
			});
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002883 File Offset: 0x00000A83
		public AnimationController()
		{
		}

		// Token: 0x04000188 RID: 392
		public Animator skaterAnim;

		// Token: 0x04000189 RID: 393
		public Animator ikAnim;

		// Token: 0x0400018A RID: 394
		public Animator steezeAnim;

		// Token: 0x0400018B RID: 395
		public Animator leftHandIKAnim;

		// Token: 0x0400018C RID: 396
		public Animator rightHandIKAnim;

		// Token: 0x0400018D RID: 397
		public FixedList4<AnimationEventData> cachedAnimationEvents;

		// Token: 0x0400018E RID: 398
		private Stance currentStance;

		// Token: 0x0400018F RID: 399
		private AnimationData currentData;

		// Token: 0x04000190 RID: 400
		private string pushAnimName;
	}
}
