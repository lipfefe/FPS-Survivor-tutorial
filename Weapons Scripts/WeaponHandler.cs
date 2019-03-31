using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeapomAim
{

    NONE,
    SELF_AIM,
    AIM

}

public enum WeaponFireType
{

    SINGLE,
    MULTIPLE

}

public enum WeaponBulletType
{

    BULLET,
    ARROW,
    SPEAR,
    NONE

}

public class WeaponHandler : MonoBehaviour {

    private Animator anim;

    private Animator aim_In_Anim;

    private Animator aim_Out_Anim;

    public WeapomAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound, reload_Sound;

    public WeaponFireType fire_Type;

    public WeaponBulletType bullet_Type;

    public GameObject attack_Point;

    void Awake()
    {
        
        anim = GetComponent<Animator>();

    }
    public void AimInAnimation()
    {

        aim_In_Anim.SetTrigger("In");

    }

    public void AimOutAnimation()
    {

        aim_Out_Anim.SetTrigger("Out");

    }

    public void ShootAnimation()
    {

        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);

    }

    public void AimIn()
    {

        anim.SetBool(AnimationTags.AIM_PARAMETER, true);

    }

    public void AimOut()
    {

        anim.SetBool(AnimationTags.AIM_PARAMETER, false);

    }

    void Turn_On_MuzzleFlash()
    {

        muzzleFlash.SetActive(true);

    }

    void Turn_Off_MuzzleFlash()
    {

        muzzleFlash.SetActive(false);

    }

    void Play_ShootSound()
    {

        shootSound.Play();

    }

    void Play_ReloadSound()
    {

        reload_Sound.Play();

    }

    void Turn_On_AtackPoint()
    {

        attack_Point.SetActive(true);

    }

    void Turn_Off_AtackPoint()
    {

        if (attack_Point.activeInHierarchy)
        {

            attack_Point.SetActive(false);

        }

    }


}
