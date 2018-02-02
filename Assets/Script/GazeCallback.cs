using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

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

    //public void OnFocusEnter()
    //{
    //    //voiceInput.GetComponent<SpeechInputSource>().StopKeywordRecognizer();
    //    PhraseRecognitionSystem.Shutdown();
    //    myVoiceInput.GetComponent<MyVoiceInputManager>().StartDictation();
    //}

    //public void OnFocusExit()
    //{
    //    myVoiceInput.GetComponent<MyVoiceInputManager>().StopDictation();
    //    PhraseRecognitionSystem.Shutdown();
    //    voiceInput.GetComponent<SpeechInputSource>().StartKeywordRecognizer();
    //}
}
