using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starUpgrade : MonoBehaviour{
    GameObject camera;

    // Use this for initialization
    void Start()
    {

        camera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upgrade()
    {
        camera.GetComponent<Main>().starUpgrade();
        Debug.Log("Star Upgraded");
    }

}