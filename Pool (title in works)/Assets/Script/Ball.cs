using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool isOffTable = false;
    public bool isMoving;
    public const int noMvntF = 3;
    private float noMvnt = 0.0001f;
    Vector3[] preLocations = new Vector3[noMvntF];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < preLocations.Length; i++) {
            preLocations[i] = Vector3.zero;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, 0.26f);
    }

    // Update is called once per frame
    void Update () {
		for (int i = 0; i < preLocations.Length - 1; i++) {
            preLocations[i] = preLocations[i + 1];
        }
        preLocations[preLocations.Length - 1] = transform.position;

        for(int i = 0; i < preLocations.Length - 1; i++) {
            if (Vector3.Distance(preLocations[i], preLocations[i + 1]) >= noMvnt) {
                isMoving = true;
                break;
            }
            else {
                isMoving = false;
            }
        }
	}
}
