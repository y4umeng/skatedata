using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using SkaterXL.Core;
using UnityEngine;
using ZeroFormatter;

namespace SkaterXL.Data
{
	// Token: 0x0200008A RID: 138
	[ZeroFormattable]
	[Serializable]
	public class ReplayRecordedFrame : ISerializable
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000520E File Offset: 0x0000340E
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00005216 File Offset: 0x00003416
		[Index(0)]
		public virtual TransformInfo[] transformInfos { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000521F File Offset: 0x0000341F
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00005227 File Offset: 0x00003427
		[Index(1)]
		public virtual TransformInfo cameraTransform { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00005230 File Offset: 0x00003430
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00005238 File Offset: 0x00003438
		[Index(2)]
		public virtual TransformInfo spawnPointTransform { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00005241 File Offset: 0x00003441
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00005249 File Offset: 0x00003449
		[Index(3)]
		public virtual ControllerState controllerState { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00005252 File Offset: 0x00003452
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000525A File Offset: 0x0000345A
		[Index(4)]
		public virtual float time { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x00005263 File Offset: 0x00003463
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x0000526B File Offset: 0x0000346B
		[Index(5)]
		public virtual bool isSwitch { get; set; }

		// Token: 0x06000430 RID: 1072 RVA: 0x0000232F File Offset: 0x0000052F
		public ReplayRecordedFrame()
		{
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00005274 File Offset: 0x00003474
		public ReplayRecordedFrame(TransformInfo[] transforms, TransformInfo cameraTransform, TransformInfo respawnInfo, ControllerState controllerState, bool isSwitch, float time)
		{
			this.time = time;
			this.controllerState = controllerState;
			this.cameraTransform = cameraTransform;
			this.spawnPointTransform = this.spawnPointTransform;
			this.transformInfos = transforms;
			this.isSwitch = isSwitch;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000123A4 File Offset: 0x000105A4
		public ReplayRecordedFrame Copy()
		{
			ReplayRecordedFrame replayRecordedFrame = new ReplayRecordedFrame();
			replayRecordedFrame.transformInfos = (from t in this.transformInfos
			select t.Copy()).ToArray<TransformInfo>();
			TransformInfo cameraTransform = this.cameraTransform;
			replayRecordedFrame.cameraTransform = ((cameraTransform != null) ? cameraTransform.Copy() : null);
			TransformInfo spawnPointTransform = this.spawnPointTransform;
			replayRecordedFrame.spawnPointTransform = ((spawnPointTransform != null) ? spawnPointTransform.Copy() : null);
			ControllerState controllerState = this.controllerState;
			replayRecordedFrame.controllerState = ((controllerState != null) ? controllerState.Copy() : null);
			replayRecordedFrame.isSwitch = this.isSwitch;
			replayRecordedFrame.time = this.time;
			return replayRecordedFrame;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0001244C File Offset: 0x0001064C
		public void ApplyTo(List<Transform> transforms)
		{
			for (int i = 0; i < transforms.Count; i++)
			{
				this.transformInfos[i].ApplyTo(transforms[i]);
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000052AE File Offset: 0x000034AE
		public ReplayRecordedFrame(SerializationInfo info, StreamingContext context)
		{
			this.GetObjectData(info, context);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00012480 File Offset: 0x00010680
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			this.transformInfos = info.GetValue("transformInfos");
			this.cameraTransform = info.GetValue("cameraTransform");
			this.spawnPointTransform = info.GetValue("spawnPointTransform");
			this.controllerState = info.GetValue("controllerState");
			this.time = info.GetValue("time");
			foreach (SerializationEntry serializationEntry in info)
			{
				if (serializationEntry.Name == "isSwitch")
				{
					this.isSwitch = (bool)serializationEntry.Value;
					return;
				}
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00012520 File Offset: 0x00010720
		public ReplayPlayerFrameHalf Migrate(TransformInfo parentTransform, ReplayRecordedFrame lastFrame, Dictionary<string, List<AudioClipEvent>> clipEvents, Dictionary<string, List<AudioOneShotEvent>> oneShots, Dictionary<string, List<AudioVolumeEvent>> volumeEvents, Dictionary<string, List<AudioPitchEvent>> pitchEvents, Dictionary<string, List<AudioCutoffEvent>> cutoffEvents)
		{
			PlayerTransformStateHalf transformState = default(PlayerTransformStateHalf);
			TransformInfo transformInfo = parentTransform.Transform(this.transformInfos[0]);
			transformState.boardPosition = transformInfo.position;
			transformState.boardRotation = transformInfo.rotation;
			int[] array = new int[]
			{
				2,
				3,
				5,
				6
			};
			for (int i2 = 0; i2 < 4; i2++)
			{
				if (lastFrame != null)
				{
					TransformInfo transformInfo2 = lastFrame.transformInfos[array[i2]];
					float value = Mathf.Repeat(this.transformInfos[array[i2]].rotation.eulerAngles.x - transformInfo2.rotation.eulerAngles.x + 180f, 360f) - 180f;
					transformState.boardWheelSpeeds[i2] = value;
				}
				else
				{
					transformState.boardWheelSpeeds[i2] = 0f;
				}
			}
			TransformInfo[] array2 = new TransformInfo[]
			{
				this.transformInfos[1],
				this.transformInfos[4]
			};
			for (int j = 0; j < array2.Length; j++)
			{
				transformState.boardTruckLocalPositions[j] = array2[j].position;
				transformState.boardTruckLocalRotations[j] = array2[j].rotation;
			}
			TransformInfo transformInfo3 = parentTransform.Transform(this.transformInfos[7]);
			transformState.skaterRootPosition = transformInfo3.position;
			transformState.skaterRootRotation = transformInfo3.rotation;
			TransformInfo transformInfo4 = this.transformInfos[9];
			transformState.skaterPelvisLocalPosition = transformInfo4.position;
			TransformInfo[] array3 = (from i in new int[]
			{
				9,
				14,
				15,
				16,
				17,
				18,
				21,
				22,
				23,
				24,
				25,
				26,
				42,
				43,
				44,
				45,
				46,
				47,
				63,
				64,
				65,
				66,
				67,
				68,
				69,
				70,
				71,
				72,
				73,
				74,
				75,
				76
			}
			select this.transformInfos[i]).ToArray<TransformInfo>();
			for (int k = 0; k < array3.Length; k++)
			{
				transformState.skaterBoneLocalRotations[k] = array3[k].rotation;
			}
			TransformInfo transformInfo5 = this.transformInfos[10];
			TransformInfo transformInfo6 = this.transformInfos[12];
			transformState.secondaryDeformerLeft = transformInfo5.position.x;
			transformState.secondaryDeformerRight = transformInfo6.position.x;
			TransformInfo[] array4 = this.transformInfos.Skip(27).Take(15).Union(this.transformInfos.Skip(48).Take(15)).ToArray<TransformInfo>();
			for (int l = 0; l < array4.Length; l++)
			{
				float num;
				Vector3 a;
				(PlayerTransformStateHalf.fingerRestRotationInverse[l] * array4[l].rotation).ToAngleAxis(out num, out a);
				num = Mathf.Repeat(num + 180f, 360f) - 180f;
				float value2 = Vector3.Dot(num * a, PlayerTransformStateHalf.fingerRotationDeltaNormalized[l]) / PlayerTransformStateHalf.fingerRotationDeltaMagnitude[l];
				transformState.fingerLerpValues[l] = Mathf.Clamp01(value2);
			}
			transformState.camera.position = this.cameraTransform.position;
			transformState.camera.rotation = this.cameraTransform.rotation;
			transformState.didRespawn = false;
			List<PlayingClipData> list = new List<PlayingClipData>();
			foreach (KeyValuePair<string, List<AudioClipEvent>> keyValuePair in clipEvents)
			{
				byte idforAudioSource;
				try
				{
					idforAudioSource = SoundHelper.manager.GetIDForAudioSource(keyValuePair.Key);
				}
				catch
				{
					Debug.LogError("Unknown sourceID for sourceName: " + keyValuePair.Key);
					continue;
				}
				AudioClipID clipID = AudioClipID.NONE;
				foreach (AudioClipEvent audioClipEvent in keyValuePair.Value)
				{
					if (audioClipEvent.time > this.time)
					{
						break;
					}
					if (!audioClipEvent.isPlaying)
					{
						clipID = AudioClipID.NONE;
					}
					else
					{
						try
						{
							clipID = SoundHelper.manager.GetIDForClipName(audioClipEvent.clipName);
						}
						catch
						{
							Debug.LogError("Unknown clipID for clip Name: " + keyValuePair.Key);
						}
					}
				}
				if (clipID.isValid)
				{
					list.Add(new PlayingClipData(idforAudioSource, clipID));
				}
			}
			List<AudioParamEventData> list2 = new List<AudioParamEventData>();
			foreach (KeyValuePair<string, List<AudioVolumeEvent>> keyValuePair2 in volumeEvents)
			{
				byte idforAudioSource2;
				try
				{
					idforAudioSource2 = SoundHelper.manager.GetIDForAudioSource(keyValuePair2.Key);
				}
				catch
				{
					continue;
				}
				AudioClipID none = AudioClipID.NONE;
				foreach (AudioVolumeEvent audioVolumeEvent in keyValuePair2.Value)
				{
					if (lastFrame == null || audioVolumeEvent.time >= lastFrame.time)
					{
						if (audioVolumeEvent.time > this.time)
						{
							break;
						}
						AudioParamEventData audioParamEventData = AudioParamEventData.Volume(idforAudioSource2, audioVolumeEvent.volume, (lastFrame != null) ? audioVolumeEvent.time : this.time);
						bool flag = false;
						for (int m = 0; m < list2.Count; m++)
						{
							if (list2[m].CanMergeWith(audioParamEventData, 0.02f))
							{
								list2[m] = list2[m].MergedWith(audioParamEventData);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list2.Add(audioParamEventData);
						}
					}
				}
			}
			foreach (KeyValuePair<string, List<AudioPitchEvent>> keyValuePair3 in pitchEvents)
			{
				byte idforAudioSource3;
				try
				{
					idforAudioSource3 = SoundHelper.manager.GetIDForAudioSource(keyValuePair3.Key);
				}
				catch
				{
					continue;
				}
				AudioClipID none2 = AudioClipID.NONE;
				foreach (AudioPitchEvent audioPitchEvent in keyValuePair3.Value)
				{
					if (lastFrame == null || audioPitchEvent.time >= lastFrame.time)
					{
						if (audioPitchEvent.time > this.time)
						{
							break;
						}
						AudioParamEventData audioParamEventData2 = AudioParamEventData.Pitch(idforAudioSource3, audioPitchEvent.pitch, (lastFrame != null) ? audioPitchEvent.time : this.time);
						bool flag2 = false;
						for (int n = 0; n < list2.Count; n++)
						{
							if (list2[n].CanMergeWith(audioParamEventData2, 0.02f))
							{
								list2[n] = list2[n].MergedWith(audioParamEventData2);
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							list2.Add(audioParamEventData2);
						}
					}
				}
			}
			foreach (KeyValuePair<string, List<AudioCutoffEvent>> keyValuePair4 in cutoffEvents)
			{
				byte idforAudioSource4;
				try
				{
					idforAudioSource4 = SoundHelper.manager.GetIDForAudioSource(keyValuePair4.Key);
				}
				catch
				{
					continue;
				}
				AudioClipID none3 = AudioClipID.NONE;
				foreach (AudioCutoffEvent audioCutoffEvent in keyValuePair4.Value)
				{
					if (lastFrame == null || audioCutoffEvent.time >= lastFrame.time)
					{
						if (audioCutoffEvent.time > this.time)
						{
							break;
						}
						AudioParamEventData audioParamEventData3 = AudioParamEventData.Cutoff(idforAudioSource4, audioCutoffEvent.cutoff, (lastFrame != null) ? audioCutoffEvent.time : this.time);
						bool flag3 = false;
						for (int num2 = 0; num2 < list2.Count; num2++)
						{
							if (list2[num2].CanMergeWith(audioParamEventData3, 0.02f))
							{
								list2[num2] = list2[num2].MergedWith(audioParamEventData3);
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							list2.Add(audioParamEventData3);
						}
					}
				}
			}
			for (int num3 = 0; num3 < list2.Count; num3++)
			{
				list2[num3].SetTimeDiff(this.time);
			}
			List<OneShotEventData> list3 = new List<OneShotEventData>();
			foreach (KeyValuePair<string, List<AudioOneShotEvent>> keyValuePair5 in oneShots)
			{
				byte idforAudioSource5;
				try
				{
					idforAudioSource5 = SoundHelper.manager.GetIDForAudioSource(keyValuePair5.Key);
				}
				catch
				{
					Debug.LogError("Unknown sourceID for sourceName: " + keyValuePair5.Key);
					continue;
				}
				foreach (AudioOneShotEvent audioOneShotEvent in keyValuePair5.Value)
				{
					if (lastFrame == null || audioOneShotEvent.time >= lastFrame.time)
					{
						if (audioOneShotEvent.time > this.time)
						{
							break;
						}
						AudioClipID idforClipName;
						try
						{
							idforClipName = SoundHelper.manager.GetIDForClipName(audioOneShotEvent.clipName);
						}
						catch
						{
							Debug.LogError("Unknown clipID for clip Name: " + keyValuePair5.Key);
							continue;
						}
						OneShotEventData item = new OneShotEventData(idforAudioSource5, idforClipName, audioOneShotEvent.volumeScale, this.time);
						list3.Add(item);
					}
				}
			}
			return new ReplayPlayerFrameHalf
			{
				time = this.time,
				transformState = transformState,
				controllerState = this.controllerState.Migrate(),
				oneShotEvents = list3.ToArray(),
				paramChangeEvents = list2.ToArray(),
				playingClips = list.ToArray()
			};
		}
	}
}
