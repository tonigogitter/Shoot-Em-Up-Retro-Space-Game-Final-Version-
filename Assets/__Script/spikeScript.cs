using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour {

    Rigidbody rb;

    bool ifLeft;

    GameObject shield;
    GameObject [] otherEnemies;
    // Use this for initialization
    void Start()
    {
        otherEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject otherEnemy in otherEnemies) {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), otherEnemy.GetComponent<Collider>(), true);
        }

        rb = gameObject.GetComponent<Rigidbody>();

        if (gameObject.transform.position.x < 0)
        {
            ifLeft = true;
        }


        InvokeRepeating("Roll", 1f, 1f);

        shield = GameObject.FindGameObjectWithTag("Shield");


    }

    
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.x > 40f || gameObject.transform.position.x < -40f)
            Destroy(gameObject);



    }



    public void launch() {

       

        if (ifLeft)
            rb.velocity = new Vector3(40, 0, 0);

        else

            rb.velocity = new Vector3(-40, 0, 0);
        

    }

    void Roll() {

        int rand = Random.Range(0, 100);
        if (rand < 10)
            launch();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
 
            shield.GetComponent<shield>().shieldHit(2);
            Destroy(gameObject);
   

        }
    }
}
