using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrueFalseUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro gameText;
    public static string[] questions = {"All kittens are born with blue eyes . . .",
        "Newborn kittens cannot purr . . .", 
        "Kittens of the same litter don't always have the same dad . . .",
        "In 1964 a kitten went to space . . ."};
    private static bool[] answers = {true, false, true, false};
    public static int index = Random.Range(0, 4); //Random.Range(0,4);
    public static string txt = questions[index];
    private string txt2;

    private void Start() {
        txt2 = questions[index];
        gameText.text = txt2;
        TrueFalseManager.questionAsked = true;
    }

    // Start is called before the first frame update
    void Update() {
        gameText.text = txt;
        TrueFalseManager.questionAsked = true;
        // TrueFalseManager.ChangeGameState();
    }

    public static void CheckAnswer(bool answer) {
        if (answer == answers[index]) {
            TrueFalseManager.playerCorrect = true;
        } else {
            TrueFalseManager.playerCorrect = false;
        }
        TrueFalseManager.questionAnswered = true;
        TrueFalseManager.ChangeGameState();
    }
}