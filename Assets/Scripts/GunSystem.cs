using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public float hitForce = 100f;

    //bools 
   public bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    //public LayerMask whatIsEnemy;

    //Graphics
    //public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake;
    //public float camShakeMagnitude, camShakeDuration;
    //public TextMeshProUGUI text;

    private void Awake()
    {
        //bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        //text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

                ShootingAi health = rayHit.collider.GetComponent<ShootingAi>();
                if (health != null)
                {
                    health.Damage(damage);
                }
                if (rayHit.rigidbody != null)
                {
                    rayHit.rigidbody.AddForce(-rayHit.normal * hitForce);
                }
        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        //bulletsLeft--;
        //bulletsShot--;

        //Invoke("ResetShot", timeBetweenShooting);

       // if (bulletsShot > 0 && bulletsLeft > 0)
            //Invoke("Shoot", timeBetweenShots);
    }
    /*private void ResetShot()
    {
        readyToShoot = true;
    }*/
    /*private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }*/
   /* private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }*/
}