using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourM4 : MonoBehaviour
{
    public float onscreenDelay = 3f;
    private GameObject Enemy;
    // Start is called before the first frame update
    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
    }
    void Update()
    {
    Destroy(this.gameObject, onscreenDelay);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(Enemy);
        }
    }
}
