using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Runtime.Versioning;

public class TrueFalseManager : MonoBehaviour
{
    public static bool questionAsked;
    public static bool questionAnswered;
    public static bool playerCorrect;

    public static TrueFalseManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        questionAsked = false;
        questionAnswered = false;
        playerCorrect = false;
    }

    public static void ChangeGameState() {
        instance.StartCoroutine("ChangeGameStateCoroutine");
    }

    IEnumerator ChangeGameStateCoroutine() {
        if (questionAsked && questionAnswered && playerCorrect) {
            TrueFalseUIManager.txt = "Correct!";
        } else if (questionAsked && questionAnswered && !playerCorrect) {
            TrueFalseUIManager.txt = "Incorrect...";
        }
        yield return new WaitForSeconds(3);
        questionAsked = false;
        questionAnswered = false;
        playerCorrect = false;
        SceneManager.LoadScene("CardTrackerScene");
    }
}