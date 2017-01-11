using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecObj : MonoBehaviour {
    public bool Objselec;

	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//........Création d'un ray qui prend la position de la souris
        RaycastHit raycast;//.................................................Création d'un raycasthit qui vas détècter se que l'on touche avec notre ray
        if (Physics.Raycast(ray, out raycast, Mathf.Infinity)) {//............On enregistre l'objet que l'on touche avec la souris dans une variable gameobject
            GameObject interactObj = raycast.collider.gameObject;//...........On enregistre l'objet que l'on touche avec la souris dans une variable gameobject
            if (interactObj.tag == "test" && Input.GetMouseButtonDown(0)) {//.Si le tag de l'objet touché est "Ground" et que l'on appuis sur clic gauche
                                                                           //.Vector3 targetPoint = raycast.point;
                                                                           //.print(targetPoint);
                Debug.Log("veroullie");
                Objselec = true;//...........................................Ajoute l'objet selectionné à l'inventaire.
            }
        }
    }
}
