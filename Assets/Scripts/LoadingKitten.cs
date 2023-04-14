using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingKitten : MonoBehaviour   
{

    [SerializeField] private GameObject spinner;
    [SerializeField] private GameObject kitten;
    private Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        StopLoadingKitten();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartLoadingKitten();
        } 
        else if (Input.GetKeyDown(KeyCode.M))
        {
            StopLoadingKitten();
        }
    }

    public void StartLoadingKitten()
    {
        spinner.SetActive(true);
        kitten.SetActive(true);
        animController.SetBool("Loading", true);
    }

    public void StopLoadingKitten()
    {
        spinner.SetActive(false);
        kitten.SetActive(false);
        animController.SetBool("Loading", false);
    }

}
