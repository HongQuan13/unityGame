using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
public class voiceControl : MonoBehaviour
{
    public LogicScript logic;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        actions.Add("stop", StopFunction);
        actions.Add("continue", ResumeFunction);
        actions.Add("restart", StartFunction);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    // Update is called once per frame
     private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        System.Action action;
        if (actions.TryGetValue(speech.text, out action))
        {
            action.Invoke();
        }
    }

    private void StopFunction()
    {
        logic.stopGame();
    }

    private void StartFunction()
    {
        logic.restartGame();
    }

    private void ResumeFunction()
    {
        logic.resumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}