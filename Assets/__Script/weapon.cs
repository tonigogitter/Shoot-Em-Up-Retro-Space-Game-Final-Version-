using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletPreFab;
    public GameObject upgradedPreFab;
    Transform point;

    int ult;

    int ultAmmo;

    public float yspeed;
    float xspeed;

    public VoidOpDelegate vod;

    public delegate void VoidOpDelegate();

    int ammo;

    GameObject explosion;
    public GameObject explosionPreFab;

    // Use this for initialization
    void Start()
    {
        ultAmmo = 1;
        ammo = 0;

        xspeed = 0.866f * yspeed;

        point = gameObject.transform;

    }


    // Update is called once per frame
    void Update()
    {


        ult++;
        if(ult == 1200 && ultAmmo < 3)
        { 

            ultAmmo++;
            ult = 0;
        }


    }
    public void shootSimple()
    {

        bullet = Instantiate(bulletPreFab);
        bullet.transform.position = point.position;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, yspeed, 0);

    }

    public void shootBlaster()
    {

        bullet = Instantiate(bulletPreFab);// Straight 
        bullet.transform.position = point.position;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, yspeed, 0);

        bullet = Instantiate(bulletPreFab);//30 degrees left

        bullet.transform.Rotate(Vector3.forward * -30);
        bullet.transform.position = point.position + new Vector3(1, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(xspeed, yspeed, 0);


        bullet = Instantiate(bulletPreFab);//30 degress 
        bullet.transform.Rotate(Vector3.forward * 30);
        bullet.transform.position = point.position + new Vector3(-1, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(-xspeed, yspeed, 0);

    }

    public void shootUpgraded()
    {
        if (ammo > 0)
        {

            bullet = Instantiate(upgradedPreFab);
            bullet.transform.position = point.position;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, yspeed, 0);
            ammo--;
        }
    }

    public weapon getWeapon()
    {
        return this;
    }

    public void addAmmo() {


        ammo += 3;

    }

    public void ultmate() {

        if (ultAmmo > 0)
        {
            ultAmmo--;
            explosion = Instantiate(explosionPreFab, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public int nukeAmmo()
    {

        return ammo;

    }

    public int ultiAmmo() {

        return ultAmmo;
    }
}
