using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CryingKitten : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skin;
    [SerializeField] private Material newMaterial;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject heart;
    [SerializeField] private Text kittenClickText;

    private Animator animController;

    private Material oldMaterial;
    private static HashSet<GameObject> kittenClickedSet = new HashSet<GameObject>();

    private void Start()
    {
        animController = GetComponent<Animator>();
        kittenClickText.text = $"Cats Found: {kittenClickedSet.Count} / 3";
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
        kittenClickedSet.Add(gameObject);
        animController.SetBool("Crying", false);
        oldMaterial = skin.material;
        skin.material = newMaterial;
        bomb.SetActive(false);
        heart.SetActive(true);
        animController.SetBool("Saved", true);
        kittenClickText.text = $"Cats Found: {kittenClickedSet.Count} / 3";
        if (kittenClickedSet.Count == 3) {
            StartCoroutine(ChangeGameStateCoroutine());
        }
    }

    public void ResetKitten()
    {
        skin.material = oldMaterial;
        animController.SetBool("Crying", true);
        animController.SetBool("Saved", false);
        bomb.SetActive(true);
        heart.SetActive(false);
    }

    IEnumerator ChangeGameStateCoroutine() {
        if (kittenClickedSet.Count == 3) {
            yield return new WaitForSeconds(3);
            kittenClickedSet.Clear();
            SceneManager.LoadScene("CardTrackerScene");
        }
    }
}
