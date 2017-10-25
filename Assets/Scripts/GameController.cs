using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject ammo;
    public Camera cam;

    [HideInInspector]
    public Vector3 camStartPos;

	// Use this for initialization
	void Start () {

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camStartPos = GameObject.Find("Main Camera").transform.position;


    }
	
	// Update is called once per frame
	void Update () {

        ammo = GameObject.FindWithTag("Ammo");

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (ammo != null)
        {
            Vector3 ammoPos = new Vector3(ammo.transform.position.x, ammo.transform.position.y, -4.87f);
            cam.transform.position = ammoPos;
        }
		
        if (ammo == null || Input.GetMouseButtonDown(0))
        {
            cam.transform.position = camStartPos;
            DestroyObject(ammo);
        }
	}
}
