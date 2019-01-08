using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallIdentity : MonoBehaviour {
    public enum ballType
    {
        STRIPES,
        SOLIDS,
        NONE
    }
    public ballType bType;
    private GameManager gameManager;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hole")
        {
            if (gameManager.isFirstSunk == false)
            {
                gameManager.isFirstSunk = true;
                if (gameManager.playerOneTurn == true)
                {
                    if (bType == ballType.SOLIDS)
                    {
                        gameManager.ballTypeAssign(0, GameManager.ballType.SOLIDS);
                        gameManager.ballTypeAssign(1, GameManager.ballType.STRIPES);
                    }
                    else
                    {
                        gameManager.ballTypeAssign(1, GameManager.ballType.SOLIDS);
                        gameManager.ballTypeAssign(0, GameManager.ballType.STRIPES);
                    }
                }
                else
                {
                    if (bType == ballType.SOLIDS)
                    {
                        gameManager.ballTypeAssign(1, GameManager.ballType.SOLIDS);
                        gameManager.ballTypeAssign(0, GameManager.ballType.STRIPES);
                    }
                    else
                    {
                        gameManager.ballTypeAssign(0, GameManager.ballType.SOLIDS);
                        gameManager.ballTypeAssign(1, GameManager.ballType.STRIPES);
                    }
                }
            }
        }
    }
}
