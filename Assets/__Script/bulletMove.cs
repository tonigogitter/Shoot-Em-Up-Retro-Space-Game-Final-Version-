using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{

    public float speed = 100;
    Rigidbody rb;
    GameObject bullet;
    bool ifCheck;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        bullet = this.gameObject;

            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());

    }

    // Update is called once per frame
    void Update()
    {

        ifCheck = this.gameObject.GetComponent<BoundsCheck>().Check();
        if (ifCheck)
            DestroyF();

        if (this.tag == "Nuke")
        {
            rb.velocity = new Vector3(0, speed, 0);
        }

    }





    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy" && this.tag == "Bullet"){

            Destroy(gameObject);
        }

        if (other.gameObject.name == "_Enemy0(Clone)" && this.tag == "Nuke")
        {
            other.gameObject.GetComponent<_Enemy0>().hit(1);
        }

        if (other.gameObject.name == "_Enemy1(Clone)" && this.tag == "Nuke")
        {
            other.gameObject.GetComponent<_Enemy1>().hit(4);
        }
        if (other.gameObject.name == "Nyan" && this.tag == "Nuke")
        {

            other.gameObject.GetComponent<BossScripts>().hit(3);
            Destroy(gameObject);

        }

        if (other.gameObject.name == "Nyan" && this.tag == "Bullet")
        {

            other.gameObject.GetComponent<BossScripts>().hit(1);
            Destroy(gameObject);

        }

    }

    public void DestroyF()
    {

        Destroy(gameObject);

    }
}
    
		
	

