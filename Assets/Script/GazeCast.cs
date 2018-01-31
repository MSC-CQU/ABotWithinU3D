using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.Events;

public abstract class GazeCast : MonoBehaviour
{
	[Range(0.5f, 5f)]
	[SerializeField]
	private float gazeSpan;

	private float timer;
	private bool isGazing;

	private void Start()
	{
		timer = 0f;
	}

	private void Update()
	{
		if (GazeManager.Instance.HitObject != null && GazeManager.Instance.HitObject == gameObject)
		{
			//Debug.Log(timer);
			timer += Time.deltaTime;
			if (timer >= gazeSpan)
			{
				if (isGazing == false)//timer = 0f;
				{
					isGazing = true;
					OnGazeStart();
				}
				else
				{
					OnGazeHold();
				}
			}
		}
		else
		{
			timer = 0f;
			isGazing = false;

			OnGazeExit();
		}
	}

	protected abstract void OnGazeStart();
	protected abstract void OnGazeHold();
	protected abstract void OnGazeExit();
}
