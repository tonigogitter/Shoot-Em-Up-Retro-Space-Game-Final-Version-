using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

    public Sprite shield4;
    public Sprite shield3;
    public Sprite shield2;
    public Sprite shield1;
    public GameObject player;
    SpriteRenderer renderer;
    public GameObject camera;
    GameObject star;
    public GameObject starPreFab;


    int count = 5;

    int shieldCounter;

	// Use this for initialization
	void Start () {

        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = shield4;

        shieldCounter = 0;


        

	}
	
	// Update is called once per frame
	void Update () {



        if (star != null)
        {
            
            shieldCounter++;
            star.transform.position = gameObject.transform.position;

            if (shieldCounter == 120)
            {
                Destroy(star);
            }
        }



        if (count < 0)
        {

            Destroy(player);
            Destroy(gameObject);
            camera.GetComponent<restart>().RestartScene();
            camera.GetComponent<Main>().playerDeath();
            
        }


	}

    public void shieldHit(int num) {

        for (int i = 0; i < num; i++)
        {
            count--;
        }

        switch (count) {

            case 4 :
                {
                    renderer.sprite = shield3;
                    break;
                }
            case 3:
                {
                    renderer.sprite = shield2;
                    break;
                }
            case 2 :
                {
                    renderer.sprite = shield1;
                    break;
                }
            case 1:
                {
                    renderer.sprite = null;
                    break;
                }
            case 0:
                {
                    Destroy(player);
                    Destroy(gameObject);
                    camera.GetComponent<restart>().RestartScene();
                    camera.GetComponent<Main>().playerDeath();
                    break;
                  
                }

            case -1:
                {
                    Destroy(player);
                    Destroy(gameObject);
                    camera.GetComponent<restart>().RestartScene();
                    camera.GetComponent<Main>().playerDeath();
                    break;

                }

        }



    }

    public int getHealth() {
        return count;
    }

    public void starShield() {

        if (star == null)
        {

            star = Instantiate(starPreFab, gameObject.transform.position, Quaternion.identity);



        }

    }
    public bool ifStar() {

        if (star == null)
            return false;
        else
            return true;

    }
}


