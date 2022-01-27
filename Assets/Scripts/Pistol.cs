using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ShootHole;
    public float bulletSpeed = 100f;
    public bool gunready1 = false;
    public float perShotDelay = 0.15f;
    private float timestamp = 0.5f;
    Animator Recoil;

    private void Start()
    {
        Recoil = GetComponent<Animator>();
    }
    void Update()
    {
        if (gunready1 == false)
        {
            Recoil.enabled = false;
        }
        else 
        {
            Recoil.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && gunready1 && Time.time > timestamp)
        {
            timestamp = Time.time + perShotDelay;
            GameObject newBullet = Instantiate(bullet, ShootHole.transform.position, ShootHole.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = ShootHole.transform.forward * bulletSpeed;
            FindObjectOfType<AudioManager>().Play("Shoot");
            Recoil.SetTrigger("Shoot");
        }
    }
}
