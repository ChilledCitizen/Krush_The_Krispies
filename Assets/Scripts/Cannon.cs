using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {


    public float rotationSpeed = 1, shootSpeed,shotMod = 1, maxShotSpeed;
    public bool goingDown, maxPow, isRotate;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int clickCount;

    // Use this for initialization
    void Start () {

        goingDown = false;
        isRotate = false;
        clickCount = 0;
	}
	
	// Update is called once per frame
	void Update () {


        if (isRotate)
        {

            if (transform.rotation.eulerAngles.z >= 65f && transform.rotation.eulerAngles.z < 250)
            {
                goingDown = true;
            }

            else if (transform.rotation.eulerAngles.z <= 330f && transform.rotation.eulerAngles.z > 250.0f)
            {
                goingDown = false;
            }

            if (goingDown == true)
            {
                transform.Rotate(Vector3.back * rotationSpeed);
            }

            Debug.Log("Angle = " + transform.rotation.eulerAngles.z);



            if (goingDown == false)
            {
                transform.Rotate(Vector3.forward * rotationSpeed);


            }
        }

      
      


        if (Input.GetMouseButton(0))
        {
            
            
            if(clickCount == 1)
            {
                if (!maxPow)
                {
                    shootSpeed += shotMod;
                }


                if (shootSpeed > maxShotSpeed)
                {
                    maxPow = true;
                    shootSpeed = maxShotSpeed;
                }
            }


            
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (clickCount == 1)
            {
                isRotate = false;
                maxPow = false;

                Fire();
            }

            if (clickCount == 0 && !isRotate)
            {
                isRotate = true;
                clickCount = 1;
            }            

                       
        }

        if (GameObject.FindWithTag("Ammo") == null && clickCount == 2)
        {
            clickCount = 0;
        }
        
    }

    public void Fire()
    {

        clickCount = 2;

        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shootSpeed;

        // Destroy the bullet after 10 seconds
        Destroy(bullet, 10.0f);
        shootSpeed = 0;
        
    }
}
