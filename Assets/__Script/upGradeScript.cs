using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upGradeScript : powerUp{

    // Use this for initialization

    override public void setType() {

        powerUpType = 1;
        Debug.Log("Type Set");
        manager.GetComponent<gunUpGrades>().upgrade();
    }


}
