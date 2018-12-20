using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool isOffTable = false;

    // Use this for initialization
    void Start () {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, 0.26f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
