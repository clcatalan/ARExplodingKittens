using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingKitten : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skin;
    [SerializeField] private Material newMaterial;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject heart;

    private Animator animController;

    private Material oldMaterial;

    private void Start()
    {
        animController = GetComponent<Animator>();
        heart.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            KittenClicked();
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            ResetKitten();
        }
    }


    public void KittenClicked()
    {
        animController.SetBool("Crying", false);
        oldMaterial = skin.material;
        skin.material = newMaterial;
        bomb.SetActive(false);
        heart.SetActive(true);
        animController.SetBool("Saved", true);
    }

    public void ResetKitten()
    {
        skin.material = oldMaterial;
        animController.SetBool("Crying", true);
        animController.SetBool("Saved", false);
        bomb.SetActive(true);
        heart.SetActive(false);
    }
}
