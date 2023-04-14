using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private MeshRenderer txtEnable;
    [SerializeField] private GameObject clock;
    private Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        StopTimeUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartTimeUp();
        } else if (Input.GetKeyDown(KeyCode.V))
        {
            StopTimeUp();
        }
    }

    void StopTimeUp()
    {
        txtEnable.enabled = false;
        clock.SetActive(false);
        animController.SetBool("Time Up", false);
    }

    void StartTimeUp()
    {
        txtEnable.enabled = true;
        clock.SetActive(true);
        animController.SetBool("Time Up", true);
        AudioManager.Instance.PlaySound("Magic");
    }
}
