using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Vector3 startPos, lastVelocity, accerelation;
    public float killZone, health = 100;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        accerelation = (rb.velocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = rb.velocity;


        if (accerelation.magnitude > killZone)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.GetComponent<Rigidbody>() == null)
        {
            return;
        }

        if (other.gameObject.tag == "Ammo")
        {
            Destroy(gameObject);
        }
        else
        {
            float damage = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 10;
            health -= damage;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
