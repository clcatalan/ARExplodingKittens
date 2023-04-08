using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrueFalseUIManager : MonoBehaviour
{
    [SerializeField] private static TextMeshPro txt;
    private string[] questions = {"All kittens are born with blue eyes.",
        "Newborn kittens cannot purr.", 
        "Kittens of the same litter don't always have the same dad.",
        "In 1964 a kitten went to space."};
    private static bool[] answers = {true, false, true, false};
    private static int index = Random.Range(0,4);

    // Start is called before the first frame update
    void Update() {
        txt.text = questions[index];
        TrueFalseManager.questionAsked = true;
    }

    public static void CheckAnswer(bool answer) {
        if (answer == answers[index]) {
            txt.text = "Correct";
        } else {
            txt.text = "Incorrect";
        }
        TrueFalseManager.questionAnswered = true;
        TrueFalseManager.ChangeGameState();
    }
}