using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public Ray ray;

    public bool Objselec;

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//........Création d'un ray qui prend la position de la souris
        RaycastHit raycast;//.................................................Création d'un raycasthit qui vas détecter se que l'on touche avec notre ray
        if (Physics.Raycast(ray, out raycast, Mathf.Infinity)) {//............On enregistre l'objet que l'on touche avec la souris dans une variable gameobject
            GameObject interactObj = raycast.collider.gameObject;//...........On enregistre l'objet que l'on touche avec la souris dans une variable gameobject
            if (interactObj.tag == "test" && Input.GetMouseButtonDown(0)) {//.Si le tag de l'objet touché est "test" et que l'on appuis sur clic gauche
                                                                            //.Vector3 targetPoint = raycast.point;
                                                                           //.print(targetPoint);
                Debug.Log("veroullie");
                Objselec = true;//...........................................Ajoute l'objet selectionné à l'inventaire.
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray)) {
                Debug.Log("voila voila");
                Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);//....Prend les coordonnées de la souris et les appliques à la variable mousePosition
                Debug.Log(mousePosition);
            }
        }
        if (Objselec) {
            Debug.Log("select");
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);//....Prend les coordonnées de la souris et les appliques à la variable mousePosition
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            Objselec = false;
        }


    }
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Objselec) {//................Appelle les foction pour le Drag&Drop
            OnMouseDown();
            OnMouseDrag();
        }

    }

    void OnMouseDown() {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Debug.Log("mouse down");
    }

    void OnMouseDrag() {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
        Debug.Log("mouse drag");
    }
}