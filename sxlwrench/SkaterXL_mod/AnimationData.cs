using System;
using SkaterXL.Core;
using UnityEngine;

namespace SkaterXL.Gameplay
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public struct AnimationData
	{
		// Token: 0x06000232 RID: 562 RVA: 0x00003544 File Offset: 0x00001744
		public void CrossFade(string animName, float duration)
		{
			this.crossFade.Call(animName, duration);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00003553 File Offset: 0x00001753
		public void ForceAnimation(string animName)
		{
			this.forceAnimation.Call(animName);
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00003561 File Offset: 0x00001761
		// (set) Token: 0x06000235 RID: 565 RVA: 0x00003569 File Offset: 0x00001769
		public float TurnAnimAmount
		{
			get
			{
				return this.turnAnimAmount;
			}
			set
			{
				this.turnAnimAmount = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00003572 File Offset: 0x00001772
		// (set) Token: 0x06000237 RID: 567 RVA: 0x0000357A File Offset: 0x0000177A
		public float TurnVel
		{
			get
			{
				return this.turnVel;
			}
			set
			{
				this.turnVel = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00003583 File Offset: 0x00001783
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0000358B File Offset: 0x0000178B
		public float InAirTurnTarget
		{
			get
			{
				return this.inAirTurnTarget;
			}
			set
			{
				this.inAirTurnTarget = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00003594 File Offset: 0x00001794
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000035AC File Offset: 0x000017AC
		public Vector3 GrindVector
		{
			get
			{
				return new Vector2(this.GrindX, this.GrindY);
			}
			set
			{
				this.GrindX = value.x;
				this.GrindY = value.y;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000035C6 File Offset: 0x000017C6
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000035CE File Offset: 0x000017CE
		public float Speed
		{
			get
			{
				return this.speed;
			}
			set
			{
				this.speed = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000035D7 File Offset: 0x000017D7
		// (set) Token: 0x0600023F RID: 575 RVA: 0x000035DF File Offset: 0x000017DF
		public bool Grounded
		{
			get
			{
				return this.grounded;
			}
			set
			{
				this.grounded = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000240 RID: 576 RVA: 0x000035E8 File Offset: 0x000017E8
		// (set) Token: 0x06000241 RID: 577 RVA: 0x000035F0 File Offset: 0x000017F0
		public bool AllDown
		{
			get
			{
				return this.allDown;
			}
			set
			{
				this.allDown = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000035F9 File Offset: 0x000017F9
		// (set) Token: 0x06000243 RID: 579 RVA: 0x00003601 File Offset: 0x00001801
		public bool Grab
		{
			get
			{
				return this.grab;
			}
			set
			{
				this.grab = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000360A File Offset: 0x0000180A
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00003612 File Offset: 0x00001812
		public GrabHandSide GrabHand
		{
			get
			{
				return this.grabHand;
			}
			set
			{
				this.grabHand = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000361B File Offset: 0x0000181B
		// (set) Token: 0x06000247 RID: 583 RVA: 0x00003623 File Offset: 0x00001823
		public float GrabHandFloat
		{
			get
			{
				return this.grabHandFloat;
			}
			set
			{
				this.grabHandFloat = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000362C File Offset: 0x0000182C
		// (set) Token: 0x06000249 RID: 585 RVA: 0x00003634 File Offset: 0x00001834
		public float GrabPointX
		{
			get
			{
				return this.grabPointX;
			}
			set
			{
				this.grabPointX = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0000363D File Offset: 0x0000183D
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00003645 File Offset: 0x00001845
		public float GrabPointY
		{
			get
			{
				return this.grabPointY;
			}
			set
			{
				this.grabPointY = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000364E File Offset: 0x0000184E
		// (set) Token: 0x0600024D RID: 589 RVA: 0x00003656 File Offset: 0x00001856
		public Vector2 LeftGrabOffset
		{
			get
			{
				return this.leftGrabOffset;
			}
			set
			{
				this.leftGrabOffset = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000365F File Offset: 0x0000185F
		// (set) Token: 0x0600024F RID: 591 RVA: 0x00003667 File Offset: 0x00001867
		public Vector2 RightGrabOffset
		{
			get
			{
				return this.rightGrabOffset;
			}
			set
			{
				this.rightGrabOffset = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00003670 File Offset: 0x00001870
		// (set) Token: 0x06000251 RID: 593 RVA: 0x0000367D File Offset: 0x0000187D
		public Vector2 GrabPointTarget
		{
			get
			{
				return this.grabPointTarget;
			}
			set
			{
				this.grabPointTarget = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0000368B File Offset: 0x0000188B
		// (set) Token: 0x06000253 RID: 595 RVA: 0x0000369E File Offset: 0x0000189E
		public Vector2 GrabPoint
		{
			get
			{
				return new Vector2(this.GrabPointX, this.GrabPointY);
			}
			set
			{
				this.GrabPointX = value.x;
				this.GrabPointY = value.y;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000036B8 File Offset: 0x000018B8
		// (set) Token: 0x06000255 RID: 597 RVA: 0x000036C0 File Offset: 0x000018C0
		public float GrabLerpSpeed
		{
			get
			{
				return this.grabLerpSpeed;
			}
			set
			{
				this.grabLerpSpeed = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000256 RID: 598 RVA: 0x000036C9 File Offset: 0x000018C9
		// (set) Token: 0x06000257 RID: 599 RVA: 0x000036D1 File Offset: 0x000018D1
		public float MelonGrab
		{
			get
			{
				return this.melonGrab;
			}
			set
			{
				this.melonGrab = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000258 RID: 600 RVA: 0x000036DA File Offset: 0x000018DA
		// (set) Token: 0x06000259 RID: 601 RVA: 0x000036E2 File Offset: 0x000018E2
		public float NoseGrab
		{
			get
			{
				return this.noseGrab;
			}
			set
			{
				this.noseGrab = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600025A RID: 602 RVA: 0x000036EB File Offset: 0x000018EB
		// (set) Token: 0x0600025B RID: 603 RVA: 0x000036F3 File Offset: 0x000018F3
		public float MuteGrab
		{
			get
			{
				return this.muteGrab;
			}
			set
			{
				this.muteGrab = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600025C RID: 604 RVA: 0x000036FC File Offset: 0x000018FC
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00003704 File Offset: 0x00001904
		public float SeatbeltGrab
		{
			get
			{
				return this.seatbeltGrab;
			}
			set
			{
				this.seatbeltGrab = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000370D File Offset: 0x0000190D
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00003715 File Offset: 0x00001915
		public float IndyGrab
		{
			get
			{
				return this.indyGrab;
			}
			set
			{
				this.indyGrab = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0000371E File Offset: 0x0000191E
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00003726 File Offset: 0x00001926
		public float TailGrab
		{
			get
			{
				return this.tailGrab;
			}
			set
			{
				this.tailGrab = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000372F File Offset: 0x0000192F
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00003737 File Offset: 0x00001937
		public float RoastBeefGrab
		{
			get
			{
				return this.roastBeefGrab;
			}
			set
			{
				this.roastBeefGrab = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00003740 File Offset: 0x00001940
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00003748 File Offset: 0x00001948
		public float CrailGrab
		{
			get
			{
				return this.crailGrab;
			}
			set
			{
				this.crailGrab = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00003751 File Offset: 0x00001951
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00003759 File Offset: 0x00001959
		public float MelonGrabTarget
		{
			get
			{
				return this.melonGrabTarget;
			}
			set
			{
				this.melonGrabTarget = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00003762 File Offset: 0x00001962
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0000376A File Offset: 0x0000196A
		public float NoseGrabTarget
		{
			get
			{
				return this.noseGrabTarget;
			}
			set
			{
				this.noseGrabTarget = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00003773 File Offset: 0x00001973
		// (set) Token: 0x0600026B RID: 619 RVA: 0x0000377B File Offset: 0x0000197B
		public float MuteGrabTarget
		{
			get
			{
				return this.muteGrabTarget;
			}
			set
			{
				this.muteGrabTarget = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00003784 File Offset: 0x00001984
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000378C File Offset: 0x0000198C
		public float SeatbeltGrabTarget
		{
			get
			{
				return this.seatbeltGrabTarget;
			}
			set
			{
				this.seatbeltGrabTarget = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00003795 File Offset: 0x00001995
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0000379D File Offset: 0x0000199D
		public float IndyGrabTarget
		{
			get
			{
				return this.indyGrabTarget;
			}
			set
			{
				this.indyGrabTarget = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000270 RID: 624 RVA: 0x000037A6 File Offset: 0x000019A6
		// (set) Token: 0x06000271 RID: 625 RVA: 0x000037AE File Offset: 0x000019AE
		public float TailGrabTarget
		{
			get
			{
				return this.tailGrabTarget;
			}
			set
			{
				this.tailGrabTarget = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000272 RID: 626 RVA: 0x000037B7 File Offset: 0x000019B7
		// (set) Token: 0x06000273 RID: 627 RVA: 0x000037BF File Offset: 0x000019BF
		public float RoastBeefGrabTarget
		{
			get
			{
				return this.roastBeefGrabTarget;
			}
			set
			{
				this.roastBeefGrabTarget = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000037C8 File Offset: 0x000019C8
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000037D0 File Offset: 0x000019D0
		public float CrailGrabTarget
		{
			get
			{
				return this.crailGrabTarget;
			}
			set
			{
				this.crailGrabTarget = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000037D9 File Offset: 0x000019D9
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000037E1 File Offset: 0x000019E1
		public bool RollOff
		{
			get
			{
				return this.rollOff;
			}
			set
			{
				this.rollOff = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000037EA File Offset: 0x000019EA
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000037F2 File Offset: 0x000019F2
		public bool Braking
		{
			get
			{
				return this.braking;
			}
			set
			{
				this.braking = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000037FB File Offset: 0x000019FB
		// (set) Token: 0x0600027B RID: 635 RVA: 0x00003803 File Offset: 0x00001A03
		public bool Powersliding
		{
			get
			{
				return this.powersliding;
			}
			set
			{
				this.powersliding = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600027C RID: 636 RVA: 0x0000380C File Offset: 0x00001A0C
		// (set) Token: 0x0600027D RID: 637 RVA: 0x00003814 File Offset: 0x00001A14
		public bool Pumping
		{
			get
			{
				return this.pumping;
			}
			set
			{
				this.pumping = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000381D File Offset: 0x00001A1D
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00003825 File Offset: 0x00001A25
		public bool Push
		{
			get
			{
				return this.push;
			}
			set
			{
				this.push = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000280 RID: 640 RVA: 0x0000382E File Offset: 0x00001A2E
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00003836 File Offset: 0x00001A36
		public bool PushMongo
		{
			get
			{
				return this.pushMongo;
			}
			set
			{
				this.pushMongo = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000383F File Offset: 0x00001A3F
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00003847 File Offset: 0x00001A47
		public bool Setup
		{
			get
			{
				return this.setup;
			}
			set
			{
				this.setup = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00003850 File Offset: 0x00001A50
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00003858 File Offset: 0x00001A58
		public bool NoComply
		{
			get
			{
				return this.noComply;
			}
			set
			{
				this.noComply = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00003861 File Offset: 0x00001A61
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00003869 File Offset: 0x00001A69
		public bool PopInterrupted
		{
			get
			{
				return this.popInterrupted;
			}
			set
			{
				this.popInterrupted = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00003872 File Offset: 0x00001A72
		// (set) Token: 0x06000289 RID: 649 RVA: 0x0000387A File Offset: 0x00001A7A
		public bool Released
		{
			get
			{
				return this.released;
			}
			set
			{
				this.released = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00003883 File Offset: 0x00001A83
		// (set) Token: 0x0600028B RID: 651 RVA: 0x0000388B File Offset: 0x00001A8B
		public bool LandedEarly
		{
			get
			{
				return this.landedEarly;
			}
			set
			{
				this.landedEarly = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00003894 File Offset: 0x00001A94
		// (set) Token: 0x0600028D RID: 653 RVA: 0x0000389C File Offset: 0x00001A9C
		public float FrontFootOnBoard
		{
			get
			{
				return this.frontFootOnBoard;
			}
			set
			{
				this.frontFootOnBoard = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000038A5 File Offset: 0x00001AA5
		// (set) Token: 0x0600028F RID: 655 RVA: 0x000038AD File Offset: 0x00001AAD
		public float BackFootOnBoard
		{
			get
			{
				return this.backFootOnBoard;
			}
			set
			{
				this.backFootOnBoard = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000290 RID: 656 RVA: 0x000038B6 File Offset: 0x00001AB6
		// (set) Token: 0x06000291 RID: 657 RVA: 0x000038BE File Offset: 0x00001ABE
		public bool Manual
		{
			get
			{
				return this.manual;
			}
			set
			{
				this.manual = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000292 RID: 658 RVA: 0x000038C7 File Offset: 0x00001AC7
		// (set) Token: 0x06000293 RID: 659 RVA: 0x000038CF File Offset: 0x00001ACF
		public bool NoseManual
		{
			get
			{
				return this.noseManual;
			}
			set
			{
				this.noseManual = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000294 RID: 660 RVA: 0x000038D8 File Offset: 0x00001AD8
		// (set) Token: 0x06000295 RID: 661 RVA: 0x000038E0 File Offset: 0x00001AE0
		public bool Grind
		{
			get
			{
				return this.grind;
			}
			set
			{
				this.grind = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000296 RID: 662 RVA: 0x000038E9 File Offset: 0x00001AE9
		// (set) Token: 0x06000297 RID: 663 RVA: 0x000038F1 File Offset: 0x00001AF1
		public bool Grinding
		{
			get
			{
				return this.grinding;
			}
			set
			{
				this.grinding = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000298 RID: 664 RVA: 0x000038FA File Offset: 0x00001AFA
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00003902 File Offset: 0x00001B02
		public bool EndImpact
		{
			get
			{
				return this.endImpact;
			}
			set
			{
				this.endImpact = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600029A RID: 666 RVA: 0x0000390B File Offset: 0x00001B0B
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00003913 File Offset: 0x00001B13
		public float BoardAngle
		{
			get
			{
				return this.boardAngle;
			}
			set
			{
				this.boardAngle = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000391C File Offset: 0x00001B1C
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00003924 File Offset: 0x00001B24
		public RevertType RevertType
		{
			get
			{
				return this.revertType;
			}
			set
			{
				this.revertType = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600029E RID: 670 RVA: 0x0000392D File Offset: 0x00001B2D
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00003935 File Offset: 0x00001B35
		public float Pivot
		{
			get
			{
				return this.pivot;
			}
			set
			{
				this.pivot = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000393E File Offset: 0x00001B3E
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00003946 File Offset: 0x00001B46
		public float PivotTurn
		{
			get
			{
				return this.pivotTurn;
			}
			set
			{
				this.pivotTurn = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000394F File Offset: 0x00001B4F
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00003957 File Offset: 0x00001B57
		public float Turn
		{
			get
			{
				return this.turn;
			}
			set
			{
				this.turn = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00003960 File Offset: 0x00001B60
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00003968 File Offset: 0x00001B68
		public float Pump
		{
			get
			{
				return this.pump;
			}
			set
			{
				this.pump = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00003971 File Offset: 0x00001B71
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00003979 File Offset: 0x00001B79
		public float Switch
		{
			get
			{
				return this.@switch;
			}
			set
			{
				this.@switch = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00003982 File Offset: 0x00001B82
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x0000398A File Offset: 0x00001B8A
		public float AnimSwitch
		{
			get
			{
				return this.animSwitch;
			}
			set
			{
				this.animSwitch = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00003993 File Offset: 0x00001B93
		// (set) Token: 0x060002AB RID: 683 RVA: 0x0000399B File Offset: 0x00001B9B
		public float SetupBase
		{
			get
			{
				return this.setupBase;
			}
			set
			{
				this.setupBase = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002AC RID: 684 RVA: 0x000039A4 File Offset: 0x00001BA4
		// (set) Token: 0x060002AD RID: 685 RVA: 0x000039AC File Offset: 0x00001BAC
		public float SetupBlend
		{
			get
			{
				return this.setupBlend;
			}
			set
			{
				this.setupBlend = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000039B5 File Offset: 0x00001BB5
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000039BD File Offset: 0x00001BBD
		public float WindUp
		{
			get
			{
				return this.windUp;
			}
			set
			{
				this.windUp = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x000039C6 File Offset: 0x00001BC6
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x000039CE File Offset: 0x00001BCE
		public float Compression
		{
			get
			{
				return this.compression;
			}
			set
			{
				this.compression = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000039D7 File Offset: 0x00001BD7
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x000039DF File Offset: 0x00001BDF
		public float PopStrength
		{
			get
			{
				return this.popStrength;
			}
			set
			{
				this.popStrength = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000039E8 File Offset: 0x00001BE8
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x000039F0 File Offset: 0x00001BF0
		public float Nollie
		{
			get
			{
				return this.nollie;
			}
			set
			{
				this.nollie = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000039F9 File Offset: 0x00001BF9
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00003A01 File Offset: 0x00001C01
		public bool Ollie
		{
			get
			{
				return this.ollie;
			}
			set
			{
				this.ollie = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00003A0A File Offset: 0x00001C0A
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00003A12 File Offset: 0x00001C12
		public float InAirTurn
		{
			get
			{
				return this.inAirTurn;
			}
			set
			{
				this.inAirTurn = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00003A1B File Offset: 0x00001C1B
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00003A23 File Offset: 0x00001C23
		public float ScoopAxis
		{
			get
			{
				return this.scoopAxis;
			}
			set
			{
				this.scoopAxis = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00003A2C File Offset: 0x00001C2C
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00003A34 File Offset: 0x00001C34
		public float ScoopAxisTarget
		{
			get
			{
				return this.scoopAxisTarget;
			}
			set
			{
				this.scoopAxisTarget = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00003A3D File Offset: 0x00001C3D
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00003A45 File Offset: 0x00001C45
		public float FlipAxis
		{
			get
			{
				return this.flipAxis;
			}
			set
			{
				this.flipAxis = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00003A4E File Offset: 0x00001C4E
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00003A56 File Offset: 0x00001C56
		public float FlipAxisTarget
		{
			get
			{
				return this.flipAxisTarget;
			}
			set
			{
				this.flipAxisTarget = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00003A5F File Offset: 0x00001C5F
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00003A67 File Offset: 0x00001C67
		public float FrontToeAxis
		{
			get
			{
				return this.frontToeAxis;
			}
			set
			{
				this.frontToeAxis = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00003A70 File Offset: 0x00001C70
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00003A78 File Offset: 0x00001C78
		public float FrontToeVelocity
		{
			get
			{
				return this.frontToeVelocity;
			}
			set
			{
				this.frontToeVelocity = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00003A81 File Offset: 0x00001C81
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00003A89 File Offset: 0x00001C89
		public float FrontForwardAxis
		{
			get
			{
				return this.frontForwardAxis;
			}
			set
			{
				this.frontForwardAxis = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00003A92 File Offset: 0x00001C92
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00003A9A File Offset: 0x00001C9A
		public float FrontForwardVelocity
		{
			get
			{
				return this.frontForwardVelocity;
			}
			set
			{
				this.frontForwardVelocity = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00003AA3 File Offset: 0x00001CA3
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00003AAB File Offset: 0x00001CAB
		public float BackToeAxis
		{
			get
			{
				return this.backToeAxis;
			}
			set
			{
				this.backToeAxis = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00003AB4 File Offset: 0x00001CB4
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00003ABC File Offset: 0x00001CBC
		public float BackToeVelocity
		{
			get
			{
				return this.backToeVelocity;
			}
			set
			{
				this.backToeVelocity = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00003AC5 File Offset: 0x00001CC5
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00003ACD File Offset: 0x00001CCD
		public float BackForwardAxis
		{
			get
			{
				return this.backForwardAxis;
			}
			set
			{
				this.backForwardAxis = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00003AD6 File Offset: 0x00001CD6
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00003ADE File Offset: 0x00001CDE
		public float BackForwardVelocity
		{
			get
			{
				return this.backForwardVelocity;
			}
			set
			{
				this.backForwardVelocity = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00003AE7 File Offset: 0x00001CE7
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00003AEF File Offset: 0x00001CEF
		public float FrontUpAxis
		{
			get
			{
				return this.frontUpAxis;
			}
			set
			{
				this.frontUpAxis = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00003AF8 File Offset: 0x00001CF8
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00003B00 File Offset: 0x00001D00
		public float BackUpAxis
		{
			get
			{
				return this.backUpAxis;
			}
			set
			{
				this.backUpAxis = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00003B09 File Offset: 0x00001D09
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00003B11 File Offset: 0x00001D11
		public float FrontUpAxisTarget
		{
			get
			{
				return this.frontUpAxisTarget;
			}
			set
			{
				this.frontUpAxisTarget = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00003B1A File Offset: 0x00001D1A
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00003B22 File Offset: 0x00001D22
		public float BackUpAxisTarget
		{
			get
			{
				return this.backUpAxisTarget;
			}
			set
			{
				this.backUpAxisTarget = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00003B2B File Offset: 0x00001D2B
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00003B40 File Offset: 0x00001D40
		public float UpAxisTarget
		{
			get
			{
				return (this.FrontUpAxisTarget + this.BackUpAxisTarget) / 2f;
			}
			set
			{
				this.FrontUpAxisTarget = value;
				this.BackUpAxisTarget = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00003B50 File Offset: 0x00001D50
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00003B58 File Offset: 0x00001D58
		public float ForwardTweak
		{
			get
			{
				return this.forwardTweak;
			}
			set
			{
				this.forwardTweak = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00003B61 File Offset: 0x00001D61
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00003B69 File Offset: 0x00001D69
		public float ToeSideTweak
		{
			get
			{
				return this.toeSideTweak;
			}
			set
			{
				this.toeSideTweak = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00003B72 File Offset: 0x00001D72
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00003B7A File Offset: 0x00001D7A
		public float TweakMagnitude
		{
			get
			{
				return this.tweakMagnitude;
			}
			set
			{
				this.tweakMagnitude = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00003B83 File Offset: 0x00001D83
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00003B8B File Offset: 0x00001D8B
		public float CatchAngle
		{
			get
			{
				return this.catchAngle;
			}
			set
			{
				this.catchAngle = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00003B94 File Offset: 0x00001D94
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00003B9C File Offset: 0x00001D9C
		public float Impact
		{
			get
			{
				return this.impact;
			}
			set
			{
				this.impact = value;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00003BA5 File Offset: 0x00001DA5
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00003BAD File Offset: 0x00001DAD
		public float BumpImpact
		{
			get
			{
				return this.bumpImpact;
			}
			set
			{
				this.bumpImpact = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00003BB6 File Offset: 0x00001DB6
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00003BBE File Offset: 0x00001DBE
		public float NollieImpact
		{
			get
			{
				return this.nollieImpact;
			}
			set
			{
				this.nollieImpact = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00003BC7 File Offset: 0x00001DC7
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00003BCF File Offset: 0x00001DCF
		public float GrindTweak
		{
			get
			{
				return this.grindTweak;
			}
			set
			{
				this.grindTweak = value;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00003BD8 File Offset: 0x00001DD8
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00003BE0 File Offset: 0x00001DE0
		public float GrindX
		{
			get
			{
				return this.grindX;
			}
			set
			{
				this.grindX = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00003BE9 File Offset: 0x00001DE9
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00003BF1 File Offset: 0x00001DF1
		public float GrindY
		{
			get
			{
				return this.grindY;
			}
			set
			{
				this.grindY = value;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00003BFA File Offset: 0x00001DFA
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x00003C02 File Offset: 0x00001E02
		public float ManualAxis
		{
			get
			{
				return this.manualAxis;
			}
			set
			{
				this.manualAxis = value;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00003C0B File Offset: 0x00001E0B
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00003C13 File Offset: 0x00001E13
		public float ManualStrength
		{
			get
			{
				return this.manualStrength;
			}
			set
			{
				this.manualStrength = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00003C1C File Offset: 0x00001E1C
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00003C24 File Offset: 0x00001E24
		public float FallBlend
		{
			get
			{
				return this.fallBlend;
			}
			set
			{
				this.fallBlend = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00003C2D File Offset: 0x00001E2D
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00003C35 File Offset: 0x00001E35
		public float BailVel
		{
			get
			{
				return this.bailVel;
			}
			set
			{
				this.bailVel = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00003C3E File Offset: 0x00001E3E
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00003C46 File Offset: 0x00001E46
		public float HipX
		{
			get
			{
				return this.hipX;
			}
			set
			{
				this.hipX = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00003C4F File Offset: 0x00001E4F
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00003C57 File Offset: 0x00001E57
		public float HipY
		{
			get
			{
				return this.hipY;
			}
			set
			{
				this.hipY = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00003C60 File Offset: 0x00001E60
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00003C68 File Offset: 0x00001E68
		public float HipUp
		{
			get
			{
				return this.hipUp;
			}
			set
			{
				this.hipUp = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00003C71 File Offset: 0x00001E71
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00003C79 File Offset: 0x00001E79
		public float HipForward
		{
			get
			{
				return this.hipForward;
			}
			set
			{
				this.hipForward = value;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00003C82 File Offset: 0x00001E82
		public override string ToString()
		{
			return this.skaterAnimState.GetAnimationName();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00003C8F File Offset: 0x00001E8F
		public bool IsCurrentAnimationPlaying(string p_name)
		{
			return this.skaterAnimState.IsName(p_name);
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00003C9D File Offset: 0x00001E9D
		public bool IsTransitioning
		{
			get
			{
				return this.skaterAnimNextState.fullPathHash != 0 || this.crossFade.called;
			}
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00016F84 File Offset: 0x00015184
		public bool IsTransitioningToAnimation(string p_name)
		{
			int hash = Animator.StringToHash(p_name);
			if (this.skaterAnimState.IsHash(hash))
			{
				return false;
			}
			if (this.crossFade.called)
			{
				return p_name == this.crossFade.parameter1;
			}
			return this.skaterAnimNextState.IsHash(hash);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00016FD4 File Offset: 0x000151D4
		public bool IsCurrentOrNextAnimation(string p_name)
		{
			int hash = Animator.StringToHash(p_name);
			return this.skaterAnimNextState.IsHash(hash) || this.skaterAnimState.IsHash(hash) || (this.crossFade.called && this.crossFade.parameter1 == p_name);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00003CB9 File Offset: 0x00001EB9
		public void ResetChangeCheck()
		{
			this.crossFade.ResetChangeCheck();
			this.forceAnimation.ResetChangeCheck();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00017028 File Offset: 0x00015228
		public void ResetAllAnimations()
		{
			this.FlipAxis = 0f;
			this.FlipAxisTarget = 0f;
			this.ScoopAxis = 0f;
			this.ScoopAxisTarget = 0f;
			this.Released = false;
			this.Grind = false;
			this.Ollie = false;
			this.Setup = false;
			this.InAirTurn = 0f;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00003CD1 File Offset: 0x00001ED1
		public void ResetAllExceptSetup()
		{
			this.FlipAxis = 0f;
			this.FlipAxisTarget = 0f;
			this.ScoopAxis = 0f;
			this.ScoopAxisTarget = 0f;
			this.Released = false;
			this.Ollie = false;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00003D0D File Offset: 0x00001F0D
		public void ResetAnimationsAfterImpact()
		{
			this.Released = false;
			this.Setup = false;
			this.Ollie = false;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00003D24 File Offset: 0x00001F24
		public void ResetAfterGrinds()
		{
			this.FlipAxis = 0f;
			this.FlipAxisTarget = 0f;
			this.ScoopAxis = 0f;
			this.ScoopAxisTarget = 0f;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00017088 File Offset: 0x00015288
		public void ResetAllAnimationsExceptSpeed()
		{
			this.FlipAxis = 0f;
			this.FlipAxisTarget = 0f;
			this.ScoopAxis = 0f;
			this.ScoopAxisTarget = 0f;
			this.Released = false;
			this.Setup = false;
			this.Ollie = false;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00003D52 File Offset: 0x00001F52
		public void ResetGrabs()
		{
			this.Grab = false;
			this.GrabHand = GrabHandSide.NONE;
			this.GrabPointTarget = Vector2.zero;
			this.GrabLerpSpeed = 5f;
			this.ResetFrontHandGrabs();
			this.ResetBackHandGrabs();
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00003D84 File Offset: 0x00001F84
		public void ResetFrontHandGrabs()
		{
			this.MelonGrabTarget = 0f;
			this.NoseGrabTarget = 0f;
			this.MuteGrabTarget = 0f;
			this.SeatbeltGrabTarget = 0f;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00003DB2 File Offset: 0x00001FB2
		public void ResetBackHandGrabs()
		{
			this.IndyGrabTarget = 0f;
			this.TailGrabTarget = 0f;
			this.RoastBeefGrabTarget = 0f;
			this.CrailGrabTarget = 0f;
		}

		// Token: 0x04000392 RID: 914
		public FixedList4<AnimationEventData> animationEvents;

		// Token: 0x04000393 RID: 915
		public UpdateType animUpdateType;

		// Token: 0x04000394 RID: 916
		public AnimatorStateInfo skaterAnimState;

		// Token: 0x04000395 RID: 917
		public float skaterAnimStateTransitionDuration;

		// Token: 0x04000396 RID: 918
		public float skaterAnimStateTransitionTime;

		// Token: 0x04000397 RID: 919
		public AnimatorStateInfo skaterAnimNextState;

		// Token: 0x04000398 RID: 920
		public AnimatorStateInfo ikAnimState;

		// Token: 0x04000399 RID: 921
		public float ikAnimStateTransitionDuration;

		// Token: 0x0400039A RID: 922
		public float ikAnimStateTransitionTime;

		// Token: 0x0400039B RID: 923
		public AnimatorStateInfo ikAnimNextState;

		// Token: 0x0400039C RID: 924
		public ActionData<string, float> crossFade;

		// Token: 0x0400039D RID: 925
		public ActionData<string> forceAnimation;

		// Token: 0x0400039E RID: 926
		[SerializeField]
		private float turnAnimAmount;

		// Token: 0x0400039F RID: 927
		[SerializeField]
		private float turnVel;

		// Token: 0x040003A0 RID: 928
		[SerializeField]
		private float inAirTurnTarget;

		// Token: 0x040003A1 RID: 929
		[SerializeField]
		private float speed;

		// Token: 0x040003A2 RID: 930
		[SerializeField]
		private bool grounded;

		// Token: 0x040003A3 RID: 931
		[SerializeField]
		private bool allDown;

		// Token: 0x040003A4 RID: 932
		[SerializeField]
		private bool grab;

		// Token: 0x040003A5 RID: 933
		[SerializeField]
		private float grabHandFloat;

		// Token: 0x040003A6 RID: 934
		[SerializeField]
		private GrabHandSide grabHand;

		// Token: 0x040003A7 RID: 935
		[SerializeField]
		private float grabPointX;

		// Token: 0x040003A8 RID: 936
		[SerializeField]
		private float grabPointY;

		// Token: 0x040003A9 RID: 937
		[SerializeField]
		private Vector2 leftGrabOffset;

		// Token: 0x040003AA RID: 938
		[SerializeField]
		private Vector2 rightGrabOffset;

		// Token: 0x040003AB RID: 939
		[SerializeField]
		private Vector3 grabPointTarget;

		// Token: 0x040003AC RID: 940
		[SerializeField]
		private float grabLerpSpeed;

		// Token: 0x040003AD RID: 941
		[SerializeField]
		private float melonGrab;

		// Token: 0x040003AE RID: 942
		[SerializeField]
		private float melonGrabTarget;

		// Token: 0x040003AF RID: 943
		[SerializeField]
		private float noseGrab;

		// Token: 0x040003B0 RID: 944
		[SerializeField]
		private float noseGrabTarget;

		// Token: 0x040003B1 RID: 945
		[SerializeField]
		private float muteGrab;

		// Token: 0x040003B2 RID: 946
		[SerializeField]
		private float muteGrabTarget;

		// Token: 0x040003B3 RID: 947
		[SerializeField]
		private float seatbeltGrab;

		// Token: 0x040003B4 RID: 948
		[SerializeField]
		private float seatbeltGrabTarget;

		// Token: 0x040003B5 RID: 949
		[SerializeField]
		private float indyGrab;

		// Token: 0x040003B6 RID: 950
		[SerializeField]
		private float indyGrabTarget;

		// Token: 0x040003B7 RID: 951
		[SerializeField]
		private float tailGrab;

		// Token: 0x040003B8 RID: 952
		[SerializeField]
		private float tailGrabTarget;

		// Token: 0x040003B9 RID: 953
		[SerializeField]
		private float roastBeefGrab;

		// Token: 0x040003BA RID: 954
		[SerializeField]
		private float roastBeefGrabTarget;

		// Token: 0x040003BB RID: 955
		[SerializeField]
		private float crailGrab;

		// Token: 0x040003BC RID: 956
		[SerializeField]
		private float crailGrabTarget;

		// Token: 0x040003BD RID: 957
		[SerializeField]
		private bool rollOff;

		// Token: 0x040003BE RID: 958
		[SerializeField]
		private bool braking;

		// Token: 0x040003BF RID: 959
		[SerializeField]
		private bool powersliding;

		// Token: 0x040003C0 RID: 960
		[SerializeField]
		private bool pumping;

		// Token: 0x040003C1 RID: 961
		[SerializeField]
		private bool push;

		// Token: 0x040003C2 RID: 962
		[SerializeField]
		private bool pushMongo;

		// Token: 0x040003C3 RID: 963
		[SerializeField]
		private bool setup;

		// Token: 0x040003C4 RID: 964
		[SerializeField]
		private bool noComply;

		// Token: 0x040003C5 RID: 965
		[SerializeField]
		private bool popInterrupted;

		// Token: 0x040003C6 RID: 966
		[SerializeField]
		private bool released;

		// Token: 0x040003C7 RID: 967
		[SerializeField]
		private bool landedEarly;

		// Token: 0x040003C8 RID: 968
		[SerializeField]
		private float frontFootOnBoard;

		// Token: 0x040003C9 RID: 969
		[SerializeField]
		private float backFootOnBoard;

		// Token: 0x040003CA RID: 970
		[SerializeField]
		private bool manual;

		// Token: 0x040003CB RID: 971
		[SerializeField]
		private bool noseManual;

		// Token: 0x040003CC RID: 972
		[SerializeField]
		private bool grind;

		// Token: 0x040003CD RID: 973
		[SerializeField]
		private bool grinding;

		// Token: 0x040003CE RID: 974
		[SerializeField]
		private bool endImpact;

		// Token: 0x040003CF RID: 975
		[SerializeField]
		private float boardAngle;

		// Token: 0x040003D0 RID: 976
		[SerializeField]
		private RevertType revertType;

		// Token: 0x040003D1 RID: 977
		[SerializeField]
		private float pivot;

		// Token: 0x040003D2 RID: 978
		[SerializeField]
		private float pivotTurn;

		// Token: 0x040003D3 RID: 979
		[SerializeField]
		private float turn;

		// Token: 0x040003D4 RID: 980
		[SerializeField]
		private float pump;

		// Token: 0x040003D5 RID: 981
		[SerializeField]
		private float @switch;

		// Token: 0x040003D6 RID: 982
		[SerializeField]
		private float animSwitch;

		// Token: 0x040003D7 RID: 983
		[SerializeField]
		private float setupBase;

		// Token: 0x040003D8 RID: 984
		[SerializeField]
		private float setupBlend;

		// Token: 0x040003D9 RID: 985
		[SerializeField]
		private float windUp;

		// Token: 0x040003DA RID: 986
		[SerializeField]
		private float compression;

		// Token: 0x040003DB RID: 987
		[SerializeField]
		private float popStrength;

		// Token: 0x040003DC RID: 988
		[SerializeField]
		private float nollie;

		// Token: 0x040003DD RID: 989
		[SerializeField]
		private bool ollie;

		// Token: 0x040003DE RID: 990
		[SerializeField]
		private float inAirTurn;

		// Token: 0x040003DF RID: 991
		[SerializeField]
		private float scoopAxis;

		// Token: 0x040003E0 RID: 992
		[SerializeField]
		private float scoopAxisTarget;

		// Token: 0x040003E1 RID: 993
		[SerializeField]
		private float flipAxis;

		// Token: 0x040003E2 RID: 994
		[SerializeField]
		private float flipAxisTarget;

		// Token: 0x040003E3 RID: 995
		[SerializeField]
		private float frontToeAxis;

		// Token: 0x040003E4 RID: 996
		[SerializeField]
		private float frontToeVelocity;

		// Token: 0x040003E5 RID: 997
		[SerializeField]
		private float frontForwardAxis;

		// Token: 0x040003E6 RID: 998
		[SerializeField]
		private float frontForwardVelocity;

		// Token: 0x040003E7 RID: 999
		[SerializeField]
		private float backToeAxis;

		// Token: 0x040003E8 RID: 1000
		[SerializeField]
		private float backToeVelocity;

		// Token: 0x040003E9 RID: 1001
		[SerializeField]
		private float backForwardAxis;

		// Token: 0x040003EA RID: 1002
		[SerializeField]
		private float backForwardVelocity;

		// Token: 0x040003EB RID: 1003
		[SerializeField]
		private float frontUpAxis;

		// Token: 0x040003EC RID: 1004
		[SerializeField]
		private float backUpAxis;

		// Token: 0x040003ED RID: 1005
		[SerializeField]
		private float frontUpAxisTarget;

		// Token: 0x040003EE RID: 1006
		[SerializeField]
		private float backUpAxisTarget;

		// Token: 0x040003EF RID: 1007
		[SerializeField]
		private float forwardTweak;

		// Token: 0x040003F0 RID: 1008
		[SerializeField]
		private float toeSideTweak;

		// Token: 0x040003F1 RID: 1009
		[SerializeField]
		private float tweakMagnitude;

		// Token: 0x040003F2 RID: 1010
		[SerializeField]
		private float catchAngle;

		// Token: 0x040003F3 RID: 1011
		[SerializeField]
		private float impact;

		// Token: 0x040003F4 RID: 1012
		[SerializeField]
		private float bumpImpact;

		// Token: 0x040003F5 RID: 1013
		[SerializeField]
		private float nollieImpact;

		// Token: 0x040003F6 RID: 1014
		[SerializeField]
		private float grindTweak;

		// Token: 0x040003F7 RID: 1015
		[SerializeField]
		private float grindX;

		// Token: 0x040003F8 RID: 1016
		[SerializeField]
		private float grindY;

		// Token: 0x040003F9 RID: 1017
		[SerializeField]
		private float manualAxis;

		// Token: 0x040003FA RID: 1018
		[SerializeField]
		private float manualStrength;

		// Token: 0x040003FB RID: 1019
		[SerializeField]
		private float fallBlend;

		// Token: 0x040003FC RID: 1020
		[SerializeField]
		private float bailVel;

		// Token: 0x040003FD RID: 1021
		[SerializeField]
		private float hipX;

		// Token: 0x040003FE RID: 1022
		[SerializeField]
		private float hipY;

		// Token: 0x040003FF RID: 1023
		[SerializeField]
		private float hipUp;

		// Token: 0x04000400 RID: 1024
		[SerializeField]
		private float hipForward;
	}
}
