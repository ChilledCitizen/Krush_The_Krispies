using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject ammo;
    public Camera cam;
    
    public Scene scene;

    [HideInInspector]
    public Vector3 camStartPos;

	// Use this for initialization
	void Start () {

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camStartPos = GameObject.Find("Main Camera").transform.position;
        
        scene = SceneManager.GetActiveScene();

    }
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemies.Length;

        if (scene.name != "WinScreen")
        {

            
            ammo = GameObject.FindWithTag("Ammo");

            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(0);
            }

            if (ammo != null)
            {
                Vector3 ammoPos = new Vector3(ammo.transform.position.x, ammo.transform.position.y, camStartPos.z);
                cam.transform.position = ammoPos;
            }

            if (ammo == null || Input.GetMouseButtonDown(0))
            {
                cam.transform.position = camStartPos;
                DestroyObject(ammo);
            }

            if (enemies.Length == 0 || enemies == null || enemyCount == 0)
            {
                Debug.Log("All Enemies Killed");
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
	}
}
