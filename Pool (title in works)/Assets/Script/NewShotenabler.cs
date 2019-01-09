using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShotenabler : MonoBehaviour {
    public GameManager gameMgr;
    private void OnEnable()
    {
        gameMgr.newShot = true;
    }
    private void OnDisable()
    {
        gameMgr.newShot = false;
    }
}
