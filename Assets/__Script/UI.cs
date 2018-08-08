using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
    float deltaTime = 0.0f;

    public GameObject player;

    public GameObject weapon;

    int health;
    int ult;
    int nuke;
    int score = 0;
    int highScore;

    void Update()
    {

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        if(player != null)
        health = player.GetComponent<shield>().getHealth();
        if (player == null)
            health = 0;
        score = gameObject.GetComponent<Main>().getScore();
        highScore = gameObject.GetComponent<Main>().getHighScore();
        if (player == null)
        {
            ult = 0;
            nuke = 0;
        }
        else
        {
            ult = weapon.GetComponent<weapon>().ultiAmmo();
            nuke = weapon.GetComponent<weapon>().nukeAmmo();
        }
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();
        GUIStyle style2 = new GUIStyle();
        GUIStyle style3 = new GUIStyle();
        GUIStyle style4 = new GUIStyle();
        GUIStyle style5 = new GUIStyle();
        GUIStyle style6 = new GUIStyle();



        Rect rect = new Rect(0, 15, 0, h * 2 / 100);
        Rect rect1 = new Rect(0, 0, 0, h * 2 / 100);
        Rect rect2 = new Rect(0, 0, w, h * 2 / 100);
        Rect nukeRect = new Rect(0, h - 20, w, h * 2 / 100);
        Rect ultRect = new Rect(0, h - 40, w, h * 2 / 100);

        //style.alignment = TextAnchor.LowerLeft;
        //style.fontSize = h * 2 / 100;
        //style.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);


        style2.alignment = TextAnchor.UpperCenter;
        style2.fontSize = h * 2 / 50;
        style2.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);

        style3.alignment = TextAnchor.UpperLeft;
        style3.fontSize = h * 2 / 50;
        style3.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);

        style4.alignment = TextAnchor.UpperLeft;
        style4.fontSize = h * 2 / 50;
        style4.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);

        style5.alignment = TextAnchor.UpperLeft;
        style5.fontSize = h * 2 / 50;
        style5.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);

        style6.alignment = TextAnchor.UpperLeft;
        style6.fontSize = h * 2 / 50;
        style6.normal.textColor = new Color(1.0f, 1.0f, 1f, 1.0f);

        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;

        string frames = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        string playerHealth = ("Health: " + health.ToString());
        string scoreText = ("Score: "+ score.ToString());
        string hScore = ("High Score: " + highScore.ToString());
        string ultString = ("Ultimate Ammo: " + ult.ToString());
        string nukeString = ("Nuke Ammo: " + nuke.ToString());

        //GUI.Label(frames, text, style);
        GUI.Label(rect2, playerHealth, style2);
        GUI.Label(rect, scoreText, style3);
        GUI.Label(rect1, hScore, style4);
        GUI.Label(ultRect, ultString, style5);
        GUI.Label(nukeRect, nukeString, style6);
    }

 

}