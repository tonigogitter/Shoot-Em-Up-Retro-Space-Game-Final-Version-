using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starScript : powerUp {

    // Use this for initialization
    override public void setType()
    {

        powerUpType = 2;
        Debug.Log("Type Set");
        manager.GetComponent<starUpgrade>().upgrade();
    }

}
