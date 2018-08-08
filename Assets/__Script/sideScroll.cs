using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScroll : MonoBehaviour {

    public GameObject stars1;
    public GameObject stars2;

    public float lower = -55f;
    public float upper = 70f;

    public float speed = -0.5f;
    
	// Use this for initialization
	void Start () {


        

	}
	
	// Update is called once per frame
	void Update () {

        stars1.transform.position = stars1.transform.position + new Vector3(0, speed, 0);
        stars2.transform.position = stars2.transform.position + new Vector3(0, speed, 0);

        if (stars1.transform.position.y < lower)
            stars1.transform.position = new Vector3(0, upper, 3);
        if (stars2.transform.position.y < lower)
            stars2.transform.position = new Vector3(0, upper, 3);



    }
}
