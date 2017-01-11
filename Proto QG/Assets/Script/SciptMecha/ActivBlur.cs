using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ActivBlur : MonoBehaviour {
    [SerializeField]
    public Camera oeil;
    public GameObject canvas;
    private bool flou;
    [SerializeField]
    bool invertBehavior;
    bool activation;

    private Invetory inventory;

    void Awake() {
        inventory = GetComponent<Invetory>();
        activation = invertBehavior ? false : true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            flou = !flou;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            flou = !flou;
            inventory.showInventory = false;
            inventory.SaveInventory();
        }
        if (flou == true) {
            oeil.GetComponent<Blur>().enabled = true;
            canvas.SetActive(true);
        }
        if (flou == false) {
            oeil.GetComponent<Blur>().enabled = false;
            canvas.SetActive(false);
        }
        if (inventory.showInventory == true) {
            oeil.GetComponent<Blur>().enabled = true;
            canvas.SetActive(true);
        }

        if (inventory.showInventory == false) {
            oeil.GetComponent<Blur>().enabled = false;
            canvas.SetActive(false);
        }

    }
}
