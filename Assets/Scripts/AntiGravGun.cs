using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ShootHole;
    public float bulletSpeed = 100f;
    public bool gunready = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && gunready)
        {
            GameObject newBullet = Instantiate(bullet, ShootHole.transform.position, ShootHole.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = ShootHole.transform.forward * bulletSpeed;
        }
    }
}
