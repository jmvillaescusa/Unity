using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class camera : MonoBehaviour {
    public float mainSpeed = 10.0f; 
    public float camSens = 0.25f; 
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
    private float totalRun = 1.0f;
    private Vector3 mousePos;

    public GameObject cam1;
    public GameObject cam2;
    public Button toggle;

    private GameManager gameMgr;

    void Start() {
        cam1.SetActive(true);
        cam2.SetActive(false);
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
            if (cam2.activeInHierarchy)
            {
                cam2.transform.Translate(p);
            }
            
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
        lastMouse = new Vector3(cam2.transform.eulerAngles.x + lastMouse.x, cam2.transform.eulerAngles.y + lastMouse.y, 0);
        cam2.transform.eulerAngles = lastMouse;
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

    public void camToggle()
    {
        if (cam1.activeInHierarchy) {
            cam1.SetActive(false);
            cam2.SetActive(true);
            GameObject.Find("camToggle").GetComponentInChildren<Text>().text = "Free Camera";
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            GameObject.Find("camToggle").GetComponentInChildren<Text>().text = "Top Camera";
        }
        
    }


}
