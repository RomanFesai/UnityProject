using UnityEngine;
using System.Collections;

public class RayCastPistol : MonoBehaviour
{
    public float Damage = 1f;
    public float Range = 100f;
    public float FireRate = 15f;
    public bool gunready1 = false;
    public float impactForce = 30f;
    public float nextTimeToFire = 0f;
    public GameObject hitmarker;
    //Animator Recoil;

    public Camera fpsCam;


    [Header("Reference Points:")]
    public Transform recoilPosition;
    public Transform rotationPoint;
    [Space(10)]

    [Header("Speed Settings:")]
    public float positionalRecoilSpeed = 8f;
    public float rotationalRecoilSpeed = 8f;
    [Space(10)]

    public float positionalReturnSpeed = 18f;
    public float rotationalReturnSpeed = 38f;
    [Space(10)]

    [Header("Amount Settings:")]
    public Vector3 RecoilRotation = new Vector3(10, 5, 7);
    public Vector3 RecoilKickBack = new Vector3(0.015f, 0f, -0.2f);
    [Space(10)]
    public Vector3 RecoilRotationAim = new Vector3(10, 4, 6);
    public Vector3 RecoilKickBackAim = new Vector3(0.015f, 0f, -0.2f);
    [Space(10)]

    Vector3 rotationalRecoil;
    Vector3 positionalRecoil;
    Vector3 Rot;
    [Header("State:")]
    public bool aiming;

    private void Start()
    {
        //Recoil = GetComponent<Animator>();
        hitmarker.SetActive(false);  
    }
    private void FixedUpdate()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);
        positionalRecoil = Vector3.Lerp(positionalRecoil, Vector3.zero, positionalReturnSpeed * Time.deltaTime);

        recoilPosition.localPosition = Vector3.Slerp(recoilPosition.localPosition, positionalRecoil, positionalRecoilSpeed * Time.fixedDeltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, rotationalRecoilSpeed * Time.fixedDeltaTime);
        rotationPoint.localRotation = Quaternion.Euler(Rot);
    }
    void Update()
    {
        if (gunready1 == false)
        {
            //Recoil.enabled = false;
        }
        else
        {
            
            //Recoil.enabled = true;
        }
        if (Input.GetMouseButtonDown(0) && gunready1 && Time.time >=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
            FindObjectOfType<AudioManager>().Play("Shoot");
            //Recoil.SetTrigger("Shoot");
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range))
        {
            EnemyRagdoll enemy = hit.transform.GetComponent<EnemyRagdoll>();
            
            if (enemy != null)
            {
                HitActive();
                Invoke("HitDisabled", 0.2f);
                enemy.TakeDamage(Damage);
               
            }
            if (hit.rigidbody != null && enemy == null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
        }

        rotationalRecoil += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
        positionalRecoil += new Vector3(Random.Range(-RecoilKickBack.x,RecoilKickBack.x),Random.Range(-RecoilKickBack.y,RecoilKickBack.y),RecoilKickBack.z);
    }

    public void HitActive()
    {
        hitmarker.SetActive(true);
    }

    public void HitDisabled()
    {
        hitmarker.SetActive(false);
    }
}