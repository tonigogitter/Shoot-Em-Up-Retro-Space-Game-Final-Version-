using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour {


    public Camera camera;
    bool stopx;
    bool stopy;
    bool stopUpper;
    float xBound;
    float yBound;
    bool verticalCheck;

    // Use this for initialization
    void Start() {
        camera = Camera.main;

    }

    // Update is called once per frame
    void Update() {
        xBound = camera.orthographicSize * camera.aspect;
        yBound = camera.orthographicSize;

        stopx = (transform.position.x <= (-1 * xBound))
                   || (transform.position.x >= xBound);
        stopy = (transform.position.y <= (-1 * yBound));
        stopUpper = (transform.position.y >= yBound);



        verticalCheck = (stopy || stopUpper);



    }
    public bool Check() {

        bool bounds = (stopx || stopy);
        bool upperBounds = stopUpper;
        bool ifEnemy = this.gameObject.tag == "Enemy";
        bool ifBullet = this.gameObject.tag == "Bullet" || this.gameObject.tag == "Nuke";
        bool ifPickUp = this.gameObject.tag == "PickUp";

        
        
        

        if ((bounds && ifEnemy) || ((bounds || upperBounds) && ifBullet) || ((bounds || upperBounds) && ifPickUp))
        {

            return true;

        }

        else
            return false;

        }



    }
