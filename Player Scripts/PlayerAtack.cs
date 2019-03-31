using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour {

    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimetoFire;
    public float damage = 20;

    private Animator zoomCameraAnim;

    private Animator zoom_In_Animation;

    private Animator zoom_Out_Animation;
    
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    public bool is_Aiming;

    [SerializeField]
    private GameObject arrow_Prefab, spear_Prefab;

    [SerializeField]
    private Transform arrow_Bow_StartPosition;


    void Awake()
    {

        weapon_Manager = GetComponent<WeaponManager>();






        //zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponentInChildren<Animator>();

        //crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;

    }



    void Start () {
		
	}
	
	
	void Update () {
        WeaponShoot();
        ZoomInAndOut();

    }

    void WeaponShoot()
    {

        if (weapon_Manager.GetCurrentSelectedWeapon().fire_Type == WeaponFireType.MULTIPLE)
        {

            if(Input.GetMouseButton(0) && Time.time > nextTimetoFire)
            {

                nextTimetoFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();

            }

        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {

                if(weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                }
                if(weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.BULLET)
                {

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();

                }
                else
                {

                    if (is_Aiming)
                    {

                        weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                        if(weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.ARROW)
                        {

                            weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                            ThrowArrowOrSpear(true);

                        }
                        else if(weapon_Manager.GetCurrentSelectedWeapon().bullet_Type == WeaponBulletType.SPEAR)
                        {

                            weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                            ThrowArrowOrSpear(false);
                        }

                    }

                }
            }

        }

    }

    void ZoomInAndOut()
    {

        if (Input.GetMouseButtonDown(1))
        {



            is_Aiming = true;

        }

        if (Input.GetMouseButtonUp(1))
        {


            is_Aiming = false;

        }

    }

    void ThrowArrowOrSpear (bool throwArrow)
    {

        if (throwArrow)
        {

            GameObject arrow = Instantiate(arrow_Prefab);
            arrow.transform.position = arrow_Bow_StartPosition.position;

            arrow.GetComponent<ArrowAndBowScript>().Launch(mainCam);

        }
        else
        {

            GameObject spear = Instantiate(spear_Prefab);
            spear.transform.position = arrow_Bow_StartPosition.position;

            spear.GetComponent<ArrowAndBowScript>().Launch(mainCam);

        }

    }

    void BulletFired()
    {

        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {

            if (hit.transform.tag == Tags.ENEMY_TAG)
            {

                hit.transform.GetComponent<HealthScript>().ApplyDamege(damage);

            }

        }

    }
}



































