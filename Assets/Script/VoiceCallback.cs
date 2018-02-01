using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using System;

public class VoiceCallback : MonoBehaviour, IDictationHandler
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

    public void Test()
    {
        Debug.Log("测试");
    }


    private void Update()
    {
        Debug.Log(DictationInputManager.IsListening);
    }


    private void CheckForErrorOnCall(int returnCode)
    {
        MicStream.CheckForErrorOnCall(returnCode);
    }

    public void OnDictationHypothesis(DictationEventData eventData)
    {
        Debug.Log("Hypothesis");
    }

    public void OnDictationResult(DictationEventData eventData)
    {
        Debug.Log(eventData.DictationResult);
    }

    public void OnDictationComplete(DictationEventData eventData)
    {
        Debug.Log("Complete");
    }

    public void OnDictationError(DictationEventData eventData)
    {
        Debug.Log("Dictation error!");
    }
}
