using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool isOffTable = false;
    public bool isMoving;
    public const int noMvntF = 10;
    private float noMvnt = 0.0001f;
    Vector3[] preLocations = new Vector3[noMvntF];
    private RaycastHit hit;
    public LineRenderer lRend;
    public GameObject ballParent;
    private GameManager M;


    // Use this for initialization
    void Start () {
        for (int i = 0; i < preLocations.Length; i++) {
            preLocations[i] = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
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
                lRend.enabled = false;
                break;
            }
            else {
                isMoving = false;
                lRend.enabled = true;
            }
        }

        if (!isMoving)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1))
            {

            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 100))
            {
                lRend.SetPosition(0, transform.position);
                lRend.SetPosition(1, hit.point);
            }   
        }
	}
}
