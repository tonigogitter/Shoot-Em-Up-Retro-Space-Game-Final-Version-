using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

    GameObject enemy;

    // Use this for initialization
    void Start () {
         enemy = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {

        bool ifCheck = this.gameObject.GetComponent<BoundsCheck>().Check();

        if (ifCheck)
            DestroyF();
	}

    

    
     public void DestroyF()
    {




        Destroy(enemy);

    }
}
