using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyParent : MonoBehaviour
{
    public float yspeed;
    public float xspeed;
    public float zspeed;
    public float direction;
    public bool random;
    public GameObject cameraM;
    

    // Use this for initialization
    void Start()
    {



    }

    public void findCamera() {
        cameraM = GameObject.FindGameObjectWithTag("MainCamera");
    }


    // Update is called once per frame
    void Update()
    {


        gameObject.transform.position = gameObject.transform.position + Vector3.down * yspeed + Vector3.right * direction * xspeed + Vector3.forward * zspeed;
    }



}
