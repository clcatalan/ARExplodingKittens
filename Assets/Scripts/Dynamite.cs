using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dynamite : MonoBehaviour
{
    //kitten vars
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material redEyeMat;
    [SerializeField] private Material greenEyeMat;
    [SerializeField] private SkinnedMeshRenderer kittenSkin;
    [SerializeField] private GameObject kitten;
    [SerializeField] private AudioSource beepSound;
    private Animator animController;
    private bool setKittenCD = true;

    //txt vars
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private MeshRenderer txtEnable;


    // Start is called before the first frame update
    void Start()
    {
        //kittenSkin.material = defaultMat;
        //timeInterval = 0;
        //setKittenCD = true;
        animController = GetComponentInChildren<Animator>();
        animController.SetBool("Defused", false);
        StartCoroutine(KittenCountDown());
        txtEnable.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartKittenCountDown();
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            StopKittenCountDown();
        }

        if (DefuseMinigameManager.gameOver) {
            StopKittenCountDown();
        }

        if (!DefuseMinigameManager.gameOver)
            txt.text = $"{Mathf.RoundToInt(CountdownManager.timeRemaining)}";
        //timeInterval += 1;
        //if (setKittenCD)
        //{
        //    if (timeInterval % 120 == 60)
        //    {
        //        kittenSkin.material = redEyeMat;
        //    } 
        //    else if (timeInterval % 120 == 0)
        //    {
        //        kittenSkin.material = defaultMat;
        //    }
        //}
    }

    //void SetKittenCountDown()
    //{
    //    setKittenCD = true;
    //    timeInterval = 0;
    //}

    void StartKittenCountDown()
    {
        animController.SetBool("Defused", false);
        txtEnable.enabled = true;
        setKittenCD = true;
        StartCoroutine(KittenCountDown());
    }

    void StopKittenCountDown()
    {
        //setKittenCD = false;
        //kittenSkin.material = greenEyeMat;
        StopAllCoroutines();
        if (DefuseMinigameManager.playerWon) {
            animController.SetBool("Defused", true);
            txt.text = "DEFUSED!";
        } else {
            txt.text = "EXPLODED!";
            animController.SetBool("Defused", false);
        }
        txt.fontSize = 14;
        kittenSkin.material = greenEyeMat;
        txtEnable.enabled = true;
    }

    private IEnumerator KittenCountDown()
    {
        while (true)
        {
            if (setKittenCD) 
            {
                kittenSkin.material = defaultMat;
                setKittenCD = false;
            }
            else
            {
                kittenSkin.material = redEyeMat;
                setKittenCD = true;
            }
            if (!DefuseMinigameManager.gameOver) {
                beepSound.Play();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
