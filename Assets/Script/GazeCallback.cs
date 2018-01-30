using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCallback : MonoBehaviour
{
	[SerializeField]
	private GameObject charactor;
	[SerializeField]
	private GameObject speakor;

	public void SayHello()
	{
		speakor.GetComponent<BotSpeak>().Say("Hello");
	}
}
