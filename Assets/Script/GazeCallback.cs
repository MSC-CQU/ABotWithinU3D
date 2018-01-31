using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCallback : GazeCast
{
	[SerializeField]
	private GameObject speakor;

	protected override void OnGazeStart()
	{
		speakor.GetComponent<BotSpeak>().Say("Hello");
	}

	protected override void OnGazeExit()
	{
	}

	protected override void OnGazeHold()
	{

	}
}
