using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followShip : MonoBehaviour {

    public GameObject ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(ship!=null)
        gameObject.transform.position = ship.transform.position;
		
	}
}
