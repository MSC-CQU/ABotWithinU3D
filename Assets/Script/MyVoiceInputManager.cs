using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MyVoiceInputManager : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    private void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        Debug.Log("Result: " + text);
        dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        Debug.Log("Hypothesis: " + text);
        dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("Error: " + error);
        dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        Debug.Log("Complete: " + cause.ToString());
        dictationRecognizer.Start();
    }

    public void StartDictation()
    {
        if (dictationRecognizer.Status == SpeechSystemStatus.Stopped)
        {
            dictationRecognizer.Start();
        }
    }

    public void StopDictation()
    {
        dictationRecognizer.Stop();
    }

    private void OnDestroy()
    {
        dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
        dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
        dictationRecognizer.Dispose();
    }
}
