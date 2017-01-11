using UnityEngine;
using System.Collections;

public class InteractionObjetScene : MonoBehaviour {

    public Transform departRayCast;
    public int distance;
    void Start () {

	}
	
	void Update () {
        Ray ray = new Ray(departRayCast.position, departRayCast.forward);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 2);
    }
}
