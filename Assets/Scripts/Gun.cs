using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isRealoding = false;

    public bool allowedToShoot = true;

    public TrailRenderer tracerEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;

    Ray ray;

    [SerializeField] Text AmmoCount;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRealoding)
        {
            return;
        }
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0)
            {
                AudioManager.Instance.PlaySFX("Reload");
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                AudioManager.Instance.PlaySFX("GunFireSound");
                Shoot();
            }
        }
        AmmoCount.GetComponent<Text>().text = currentAmmo.ToString();
    }

    IEnumerator Reload()
    {
        isRealoding = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isRealoding = false;
    }

    void Shoot()
    {
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position = raycastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            tracer.transform.position = hit.point;
        }
    }

}