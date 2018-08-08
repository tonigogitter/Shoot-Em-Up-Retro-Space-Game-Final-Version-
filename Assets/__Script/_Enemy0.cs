using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _Enemy0 : _EnemyParent
{

    public GameObject pickUp;
    GameObject star;
    int health = 1;
    GameObject boss;



    // Use this for initialization


    private void Start()
    {
        yspeed = 0.5f;
        base.findCamera();
        boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss != null)
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

                    cameraM.GetComponent<Main>().addScore(1);
                    Destroy(gameObject);

                    int rand = Random.Range(0, 9);

                    if (rand <= 4)
                    {

                        star = Instantiate(pickUp, gameObject.transform.position, Quaternion.identity);
                    }

                }


            }
        }



        // Update is called once per frame
    }

