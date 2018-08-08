using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public float camWidth;
    public float camHeight;
    public Camera camera;
    public GameObject enemy1;
    public GameObject enemy1PreFab;
    public GameObject enemy0;
    public GameObject enemy0PreFab;
    public int counter1;
    public int counter0;
    int playerState = 1;
    int score;
    int highScore;

    GameObject shield;


    GameObject gun;

    public enum WeaponType { Simple, Blaster, Upgraded};

    int weaponState;

    weapon myweapon;

    Vector3 ypos;


    // Use this for initialization
    void Start() {
        camWidth = camera.orthographicSize * camera.aspect;
        camHeight = camera.orthographicSize;



        score = 0;


        ypos = new Vector3(0, camHeight + 10, 0);

        weaponState = (int)WeaponType.Simple;

        gun = GameObject.FindGameObjectWithTag("Gun");

        myweapon = new weapon();
        myweapon = gun.GetComponent<weapon>().getWeapon();
        weaponState = 0;
        myweapon.vod = myweapon.shootSimple;
    }

    void spawnEnemy0() {
        
        enemy0 = Instantiate(enemy0PreFab, ypos, Quaternion.identity);

    }

    void spawnEnemy1() {
        enemy1 = Instantiate(enemy1PreFab, ypos, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {

        if (score >= 50)
        {
            SceneManager.LoadScene("Project2", LoadSceneMode.Single);

        }

        if(gun!=null)
        if (Input.GetKey("z")) {
            gun.GetComponent<weapon>().ultmate();
        }

        highScore = PlayerPrefs.GetInt("highScore", highScore);

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("highScore", highScore);
        }

        if (counter0 == 55)
        {
            spawnEnemy0();
            counter0 = 0;
        }
        if (counter1 == 150)    
        {
            spawnEnemy1();
            counter1 = 0;
        }
        if (playerState == 1)
        {
            if (Input.GetKeyDown("g"))
            {
                if (weaponState == 0)
                {
                    weaponState = (int)WeaponType.Blaster;
                    myweapon.vod = myweapon.shootBlaster;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>().upgradeBlasters(false);



                }
                else if (weaponState == 1)
                {
                    weaponState = (int)WeaponType.Upgraded;
                    myweapon.vod = myweapon.shootUpgraded;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>().upgradeBlasters(true);
                    

                

                }
                else if (weaponState == 2) {
                    weaponState = (int)WeaponType.Simple;
                    myweapon.vod = myweapon.shootSimple;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>().upgradeBlasters(false);


                }

            }
            if (Input.GetKeyDown("x"))
                myweapon.vod();
        }


        counter0++;
        counter1++;
        

    }
    void OnDrawGizmos() {
        if (!Application.isPlaying)
            return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);


    }
    public void playerDeath() {

        playerState = 0;

    }

    public void addScore(int amt) {

        score = score + amt;

    }

    public int getScore() {

        return score;
    }

    public int getHighScore() {

        return PlayerPrefs.GetInt("highScore");

    }

    public void upgradeGun() {


        myweapon.GetComponent<weapon>().addAmmo();
    }

    public void starUpgrade() {

        shield = GameObject.FindGameObjectWithTag("Shield");
        if (!shield.GetComponent<shield>().ifStar())
            shield.GetComponent<shield>().starShield();
        else
            Debug.Log("Failed");

    }

}
