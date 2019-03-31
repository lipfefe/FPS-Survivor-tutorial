using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfAim : MonoBehaviour
{

    private Animator anim_Self;

    private WeaponAim weapon_Aim;

    private WeaponHandler weapon_Handler;

    void Awake()
    {

        weapon_Aim = GetComponent<WeaponAim>();

        weapon_Handler = GetComponent<WeaponHandler>();

        anim_Self = GetComponent<Animator>();




    }

    void Start()
    {



    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            anim_Self.SetBool(AnimationTags.AIM_PARAMETER, true);

        }
        if (Input.GetMouseButtonUp(1))
        {

            anim_Self.SetBool(AnimationTags.AIM_PARAMETER, false);

        }
    }
}
