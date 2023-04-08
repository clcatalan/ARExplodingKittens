using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriviaCard : MonoBehaviour
{
    // Hover Button Vars
    [SerializeField] private Material trueMat;
    [SerializeField] private Material falseMat;
    [SerializeField] private Material trueHoverMat;
    [SerializeField] private Material falseHoverMat;
    [SerializeField] private MeshRenderer trueSkin;
    [SerializeField] private MeshRenderer falseSkin;

    // Correct/Incorrect Material Vars
    [SerializeField] private Material CorrectMat;
    [SerializeField] private Material IncorrectMat;
    [SerializeField] private SkinnedMeshRenderer kittenSkin;
    [SerializeField] private GameObject kitten;

    // Correct/Incorrect Text Vars
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private MeshRenderer txtEnable;

    // Correct/Incorrect Animation Vars
    private Animator animController;


    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponentInChildren<Animator>();
        txtEnable.enabled = false;
        kitten.SetActive(false);
        animController.SetBool("Correct", false);
        animController.SetBool("Incorrect", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            HoverTrue();
        } else if (Input.GetKeyDown(KeyCode.F))
        {
            HoverFalse();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            ResetAll();
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayCorrect();
        } else if (Input.GetKeyDown(KeyCode.X))
        {
            PlayIncorrect();
        }
    }

    void HoverTrue()
    {
        trueSkin.material = trueHoverMat;
    }

    void HoverFalse()
    {
        falseSkin.material = falseHoverMat;
    }

    void ResetAll()
    {
        trueSkin.material = trueMat;
        falseSkin.material = falseMat;
        kitten.SetActive(false);
        txtEnable.enabled = false;
        animController.SetBool("Correct", false);
        animController.SetBool("Incorrect", false);

    }

    void PlayCorrect()
    {
        kittenSkin.material = CorrectMat;
        kitten.SetActive(true);
        animController.SetBool("Correct", true);
        txt.text = "Correct!";
        txtEnable.enabled = true;
    }

    void PlayIncorrect()
    {
        kittenSkin.material = IncorrectMat;
        kitten.SetActive(true);
        animController.SetBool("Incorrect", true);
        txt.text = "Incorrect!";
        txtEnable.enabled = true;
    }

}
