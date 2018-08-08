using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnemyCollide : MonoBehaviour {


    GameObject shields;

	// Use this for initialization
	void Start () {

        shields = GameObject.FindGameObjectWithTag("Shield");

	}

    void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {

            shields.GetComponent<shield>().shieldHit(1);
            

            

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
