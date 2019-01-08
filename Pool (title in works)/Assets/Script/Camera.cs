using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public float mainSpeed = 10.0f; 
    public float camSens = 0.25f; 
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
    private float totalRun = 1.0f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 p = moveCamera();
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            transform.Translate(p);
        }
        else
        {
            return;
        }
    }

    private Vector3 moveCamera()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
