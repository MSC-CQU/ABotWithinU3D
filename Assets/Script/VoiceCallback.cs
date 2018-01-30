using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using System;

public class VoiceCallback : MonoBehaviour
{
	/*[SerializeField]
	private GameObject charactor;
	[SerializeField]
	private GameObject hololensCamera;*/
	[SerializeField]
	private GameObject motionController;
	[SerializeField]
	private MicStream.StreamCategory streamType = MicStream.StreamCategory.HIGH_QUALITY_VOICE;
	[SerializeField]
	private float inputGain = 1f;
	[SerializeField]
	private bool keepAllData;

	private bool isResording;

	private void Start()
	{
		isResording = false;
	}

	public void StartRecord()
	{
		Debug.Log("Recording");
		isResording = true;
	}

	public void FollowMe()
	{
		motionController.GetComponent<BotMotionController>().Follow();
	}

	public void StandStill()
	{
		motionController.GetComponent<BotMotionController>().Stand();
	}



	private void CheckForErrorOnCall(int returnCode)
	{
		MicStream.CheckForErrorOnCall(returnCode);
	}
}
