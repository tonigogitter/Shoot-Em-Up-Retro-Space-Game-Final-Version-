using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammorun : MonoBehaviour {


    
	// Use this for initializations
	void Start () {

		
	}
	
	// Update is called once per framef,    
	void Update () {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0,-0.7f, 0);

        if (gameObject.transform.position.y < -30f)
            Destroy(gameObject);
		
	}
}
