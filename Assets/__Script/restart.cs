using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour {

    // Use this for initialization
    public void RestartScene() {

        StartCoroutine(Example());
    }

        IEnumerator Example()
        {
            
            yield return new WaitForSeconds(5);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

