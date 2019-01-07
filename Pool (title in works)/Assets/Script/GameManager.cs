using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public List<GameObject> balls;
    public List<GameObject> spawnPoints;
	public int numTurn = 0;
	public int playerTurn = 0;
	public Slider pwrBar;
	public Button button;
	private bool isGrowing = true;
	private bool barUse;
	public GameObject cueBall;
    private int maxSpawnPoints = 0;
    public GameObject Rack;

    //Did it Work

	// Use this for initialization
	public void Start () {
        maxSpawnPoints = 14;
        spawnBalls();
        
    }
	
    void spawnBalls () {
        for (int i = 0; i < maxSpawnPoints; i++) {
            int rNum = Random.Range(0, balls.Count - 1);
            int rNumTwo = Random.Range(0, spawnPoints.Count - 1);
            GameObject temp = Instantiate(balls[rNum], spawnPoints[rNumTwo].transform.position, Quaternion.Euler(130,0,90));
            Destroy(spawnPoints[rNumTwo]);
            spawnPoints.Remove(spawnPoints[rNumTwo]);
            balls.Remove(balls[rNum]);
        }
    }

	// Update is called once per frame
	void Update () {
        Ball bScript = cueBall.GetComponent<Ball>();

        if (barUse) {
			if (isGrowing) {
				pwrBar.value += 0.01f;
				if (pwrBar.value >= 1) {
					isGrowing = false;
				}
			}
			else {
				pwrBar.value -= 0.01f;
				if (pwrBar.value <= 0) {
					isGrowing = true;
				}
			}
		}

        if (!bScript.isMoving) {
            preLaunch();
        }
        else {
            pwrBar.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }
    }

    
    public void preLaunch() {
        barUse = true;
        if (Input.GetKey(KeyCode.D)) {
            cueBall.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            cueBall.transform.Rotate(-Vector3.up * 50 * Time.deltaTime); }
        pwrBar.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }

    public void Button() { 
		barUse = false;
        Launch();
    }
    
    public void Launch() {
        cueBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 750 * pwrBar.value);
    }
}
