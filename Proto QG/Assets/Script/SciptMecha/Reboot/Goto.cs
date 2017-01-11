using UnityEngine;
using System.Collections;

public class Goto : MonoBehaviour
	{
    public GameObject tourne;
    public float Speed =6f;
	public Transform[] Waypoints;
    public float pointX;
    public float pointY;
    public float pointZ;


    Transform currentTarget;
	int currentTargetIndex=0;
    

	void Start() {

    }   

	void Update() {
		currentTarget = Waypoints[currentTargetIndex];

        pointX = currentTarget.transform.rotation.eulerAngles.x;
        pointY = currentTarget.transform.rotation.eulerAngles.y;
        pointZ = currentTarget.transform.rotation.eulerAngles.z;

        Vector3 remainingPath = currentTarget.position - transform.position;
        if (CompareTag("waypoint")) {

        }


        Vector3 nextStep = remainingPath.normalized * Speed * Time.deltaTime;

		if ( nextStep.magnitude > remainingPath.magnitude ) {
            Debug.Log("tourne");
            this.transform.eulerAngles = new Vector3(pointX, pointY, pointZ);
            //Le prochain pas nous fait atteindre le waypoint, on doit viser le prochain:
            currentTargetIndex = currentTargetIndex + 1;
            if (currentTargetIndex == 2) {
                currentTargetIndex = currentTargetIndex + 0;
            }
			//if ( currentTargetIndex >= Waypoints.Length ) { //On a atteint le dernier point, on recommence ?
			//	currentTargetIndex = 0;
			//	}
			}
        else
        {
			transform.Translate( nextStep, Space.World );
			}
		}
	}
