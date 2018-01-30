using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.Events;

public class GazeCast : MonoBehaviour//, IFocusable
{
	[Range(0.5f, 5f)]
	[SerializeField]
	private float gazeSpan;
	[SerializeField]
	private UnityEvent[] events;

	private float timer;
	private bool isGazing;

	public bool IsGazing
	{
		get
		{
			return isGazing;
		}
	}

	private void Start()
	{
		timer = 0f;
	}

	private void Update()
	{
		if (GazeManager.Instance.HitObject != null && GazeManager.Instance.HitObject == gameObject)
		{
			Debug.Log(timer);
			timer += Time.deltaTime;
			if (timer >= gazeSpan)
			{
				Debug.Log(events.Length);
				foreach (var item in events)
				{
					item.Invoke();
				}
				timer = 0f;
				isGazing = true;
			}
		}
		else
		{
			timer = 0f;
			isGazing = false;
		}
	}
}
