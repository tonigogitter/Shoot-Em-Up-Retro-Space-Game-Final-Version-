using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy1 : _EnemyParent
{



    public GameObject pickUp;
    GameObject gun;
    GameObject boss;

    int health;

    // Use this for initialization
    void Start()
    {

        health = 4;
        base.findCamera();

        bool Boolean = (Random.value > 0.5f);

        if (Boolean == true)
            direction = 1;
        else if (Boolean == false)
            direction = -1;


        boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss!=null)
        Physics.IgnoreCollision(this.GetComponent<Collider>(), boss.GetComponent<Collider>(), true);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            hit(1);



    }

    public void hit(int damage)
    {

        

            for (int i = 0; i < damage; i++)
            {
                health--;

                if (health == 0)
                {
                Debug.Log("Destroyed");
                cameraM.GetComponent<Main>().addScore(3);
                    Destroy(gameObject);

  

                    int rand = Random.Range(0, 9);

                    if (rand <= 5)
                    {
                        Debug.Log("Spawn here");
                        gun = Instantiate(pickUp, gameObject.transform.position, Quaternion.identity);
                    }

                }


            }


        }
    }