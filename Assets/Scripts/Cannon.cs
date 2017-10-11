using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {


    public float rotationSpeed = 1, shootSpeed,shotMod = 1, maxShotSpeed;
    public bool goingDown, maxPow, isRotate, firstClick;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;


    // Use this for initialization
    void Start () {

        goingDown = false;
        isRotate = false;
        firstClick = true;
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
            
            
            if(!firstClick)
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
            if (!firstClick)
            {
                isRotate = false;
                maxPow = false;

                Fire();
            }

            if (firstClick && !isRotate)
            {
                isRotate = true;
                firstClick = false;
            }            

                       
        }
        
    }

    public void Fire()
    {

        firstClick = true;

        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shootSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
        shootSpeed = 0;
        
    }
}
