using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCallback : GazeCast
{
    [SerializeField]
    private GameObject speakor;
    [SerializeField]
    private GameObject voiceInput;
    [SerializeField]
    private GameObject myVoiceInput;

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

    protected override void OnGazeIn()
    {
        voiceInput.GetComponent<SpeechInputSource>().StopKeywordRecognizer();
        myVoiceInput.GetComponent<MyVoiceInputManager>().StartDictation();
    }

    protected override void OnGazeStay()
    {

    }
}
