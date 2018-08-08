using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {


    public Rigidbody rb;

    public int powerUpType;

    public GameObject manager;

    int counter;

    Vector3 vector;

    int timeLimit;

    Color alphaC;

    public float lifeTime = 6f;
    public float fadeTime = 4f;
    float birthTime;

    Renderer rend;

    void Awake() {

        

        birthTime = Time.time;


        rend = gameObject.GetComponent<Renderer>();
    }


	// Use this for initialization
	public void Start () {

        vector = new Vector3(0, -7, 0);

        rb = gameObject.GetComponent<Rigidbody>();

        manager = GameObject.Find("powerUpManager");
        rb.velocity = vector;

        alphaC = gameObject.GetComponent<Renderer>().material.color;


    }
	
	// Update is called once per frame
	public void Update () {



        float u = (Time.time - (birthTime + lifeTime)) / fadeTime;

        if (u >= 1) {
            Destroy(this.gameObject);
            return;
        }

        if (u > 0)
        {
            Color c = rend.material.color;
            c.a = 1f - u;
            rend.material.color = c;

        }


        if (gameObject.GetComponent<BoundsCheck>().Check())
        {
            Destroy(gameObject);
        }




    }

    public virtual void setType() { }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")

        {

            Debug.Log("Hit");
            Destroy(gameObject);
            setType();
            
        }

    }

}