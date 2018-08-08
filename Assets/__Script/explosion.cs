using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    // Use this for initialization

    GameObject camera;

    GameObject boss;

    public GameObject[] enemyarray;
	void Start () {

    
        enemyarray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject otherenemy in enemyarray)
        {
            if (otherenemy.name == "_Enemy0(Clone)")
            {
                otherenemy.GetComponent<_Enemy0>().hit(1);
            }

            else if (otherenemy.name == "_Enemy1(Clone)")
            {
                otherenemy.GetComponent<_Enemy1>().hit(4);
            }

            
        }



	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(3, 3);
        if (transform.localScale.x == 91f && transform.localScale.y == 91f) {
            Destroy(gameObject);
        }
	}
}


