using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    private Animator self_Aim_Anim;

    private Animator aim_Anim;

    


    private WeaponManager weapon_Manager;

    public bool is_Aiming;

    private GameObject crosshair;

    private WeaponHandler weapon_Handler;

    public int current_Weapon_Selected;

    public bool cant_Aim;

    public bool self_Aim;

 

    void Awake()
    {

        weapon_Manager = GetComponent<WeaponManager>();

        weapon_Handler = GetComponent<WeaponHandler>();

        self_Aim_Anim = GetComponent<Animator>();

        aim_Anim = GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        current_Weapon_Selected = 1;
        cant_Aim = true;
        is_Aiming = false;

    }

    void Start()
    {



    }


    void Update()
    {
        ZoomInAndOut();
        IsAimong();
        

        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            current_Weapon_Selected = 1;
            cant_Aim = true;
            self_Aim = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            current_Weapon_Selected = 2;
            cant_Aim = false;
            self_Aim = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            current_Weapon_Selected = 3;
            cant_Aim = false;
            self_Aim = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            current_Weapon_Selected = 4;
            cant_Aim = false;
            self_Aim = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            current_Weapon_Selected = 5;
            cant_Aim = true;
            self_Aim = true;

        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            current_Weapon_Selected = 6;
            cant_Aim = true;
            self_Aim = true;


        }


    }

    void ZoomInAndOut()
    {
        if (cant_Aim == false)


        {

            if (Input.GetMouseButtonDown(1))
            {

                aim_Anim.SetTrigger(AnimationTags.ZOOM_IN_ANIM);

                crosshair.SetActive(false);

                

            }

            if (Input.GetMouseButtonUp(1))
            {

                aim_Anim.SetTrigger(AnimationTags.ZOOM_OUT_ANIM);

                crosshair.SetActive(true);

                

            }
          
        }
     

    }
    void IsAimong()
    {

        if (self_Aim)
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

    }
   
    

   
}
