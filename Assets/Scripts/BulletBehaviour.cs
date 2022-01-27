using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float onscreenDelay = 3f;
    public float speedUp = 0.1f;
    public Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TakeObject")
        {
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.AddForce(0, 15, 0);

        }
    }
}
