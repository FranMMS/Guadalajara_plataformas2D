using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    PlayerScript playerScript;

    public float timeShoot;
    public float timeShootRun;

    public GameObject bulletPrefab;
    public GameObject bulletRunPrefab;

    public Transform firePoint;
    public Transform fireRunPoint;

    GameObject actualBullet;
    Transform actualFirePoint;

    bool canShoot;
    //public Transform fire_runPoint;

    private void Start()
    {
        playerScript = GetComponent<PlayerScript>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canShoot && !playerScript.isJumping)
        {
            if (playerScript.isMoving())
            {
                StartCoroutine(ShootRun());
            }
            else
            {
                StartCoroutine(Shoot());
            }

            
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        canShoot = false;
        yield return new WaitForSeconds(timeShoot);
        canShoot = true;
    }
    IEnumerator ShootRun()
    {
        Instantiate(bulletRunPrefab, fireRunPoint.position, fireRunPoint.rotation);
        canShoot = false;
        yield return new WaitForSeconds(timeShootRun);
        canShoot = true;
    }

}
