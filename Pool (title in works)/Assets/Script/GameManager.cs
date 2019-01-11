using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public List<GameObject> balls;
    public List<GameObject> spawnPoints;
	public int numTurn = 0;
	public bool playerOneTurn = true;
	public Slider pwrBar;
	public Button button;
	private bool isGrowing = true;
	private bool barUse;
	public GameObject cueBall;
    private int maxSpawnPoints = 14;
    public GameObject Rack;
    public GameObject ballParent;
    public enum ballType {
        STRIPES, 
        SOLIDS,
        NONE
    }
    private ballType type;
    private ballType[] playerBall;
    public bool isFirstSunk = false;
    public bool newShot;
    public Ball bScript;
    private Vector3 mousePos;
    public bool firstShot = true;
    private BallIdentity BI;


    // Use this for initialization
    public void Start () {
        spawnBalls();
        playerBall = new ballType[2];
        for (int i = 0; i < playerBall.Length; i++) {
            playerBall[i] = ballType.NONE;
        }
        
    }


    public void ballTypeAssign (int i, ballType type) {
        playerBall[i] = type;
    }

    void spawnBalls () {
        for (int i = 0; i < maxSpawnPoints; i++) {
            int rNum = Random.Range(0, balls.Count - 1);
            //int rNumTwo = Random.Range(0, spawnPoints.Count - 1);
            /*if (i == 8)
            {
                if (balls[rNum].GetComponent<BallIdentity.ballType>() == BallIdentity.ballType.SOLIDS)
                {
                    GameObject temp = Instantiate(balls[rNum], spawnPoints[i].transform.position, Quaternion.Euler(130, 0, 90));
                }
                else if  (balls[rNum].GetComponent<BallIdentity.ballType>() == BallIdentity.ballType.STRIPES)
                {
                    GameObject temp = Instantiate(balls[rNum], spawnPoints[i].transform.position, Quaternion.Euler(130, 0, 90));
                }
            }*/
            GameObject temp = Instantiate(balls[rNum], spawnPoints[i].transform.position, Quaternion.Euler(130, 0, 90));
            //Destroy(spawnPoints[rNumTwo]);
            //spawnPoints.Remove(spawnPoints[rNumTwo]);
            balls.Remove(balls[rNum]);
            Debug.Log(rNum+" "+ i);
        }
    }

	// Update is called once per frame
	void Update () {
        if (barUse) {
            if (isGrowing) {
				pwrBar.value += 0.01f;
				if (pwrBar.value >= 2) {
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
        if (newShot)
        {
            cueBall.transform.rotation = ballParent.transform.rotation;
            newShot = false;
        }
        barUse = true;
        if (Input.GetKey(KeyCode.E)) {
            cueBall.transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)) {
            cueBall.transform.Rotate(-Vector3.up * 30 * Time.deltaTime);
        }
        pwrBar.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }

    public void Button() { 
		barUse = false;
        newShot = false;
        Launch();
    }

    public void Launch()
    {
        newShot = false;
        cueBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500 * pwrBar.value);
        gameObject.transform.parent = null;
    }
}
