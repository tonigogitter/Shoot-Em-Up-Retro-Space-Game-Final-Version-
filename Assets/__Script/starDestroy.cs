using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Destroy(gameObject);
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "_Enemy0(Clone)")
        {
            other.gameObject.GetComponent<_Enemy0>().hit(1);
        }

        if (other.gameObject.name == "_Enemy1(Clone)")
        {
            other.gameObject.GetComponent<_Enemy1>().hit(4);
        }
        else if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == "Boss")
        {

            Destroy(gameObject);    

        }
    }
}
