using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScripts : MonoBehaviour {

    GameObject shield;
    GameObject bossAmmo;
    public GameObject bossAmmoPrefab;
    Transform point;
    public float yspeed;

    public int counter;

    int health;

    

    bool shooting;

    GameObject camera;

    int bullets;

    int timer;

    Rigidbody rb;

    GameObject[] otherRainbowBullets;

    // Use this for initialization
    void Start () {

        health = 9;
        
        rb = gameObject.GetComponent<Rigidbody>();

        //first speed
        rb.velocity = new Vector3(20, 0, 0); 
        shield = GameObject.FindGameObjectWithTag("Shield");

        point = gameObject.transform;

        InvokeRepeating("roll", 2f, 2f);

        camera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {



        if (gameObject.transform.position.x >= 18f) {

            rb.velocity = new Vector3(-20, 0, 0);
        }

        if (gameObject.transform.position.x <= -18f) {
            rb.velocity = new Vector3(20, 0, 0);
        }




    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            shield.GetComponent<shield>().shieldHit(5);
        }
    }



    void roll() {

        if (shooting != true)
        {


            counter = Random.Range(0, 100);


            if (counter < 50)
            {
                shoot();

            }
        }

    }

    public void shoot() {

        StartCoroutine(shootingF());



    }

    

    IEnumerator shootingF() {


        shooting = true;
        for (int i = 0; i < 40; i++)
        {



            bossAmmo = Instantiate(bossAmmoPrefab);
            bossAmmo.transform.position = gameObject.transform.position + new Vector3(0, -2f, 0);
            bossAmmo.GetComponent<Rigidbody>().velocity = new Vector3(0, yspeed, 0);

            yield return new WaitForSeconds(0.05f);
        }
        shooting = false;
    }
    public void hit(int damage)
    {




        for (int i = 0; i < damage; i++)
        {
            health--;

            if (health == 0)
            {

                camera.GetComponent<Main>().addScore(10);
                Destroy(gameObject);


            }


        }



    }
}
