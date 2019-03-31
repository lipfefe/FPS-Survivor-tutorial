﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour {

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;

    public bool is_Player, is_Boar, is_Cannibal;

    private bool is_Dead;

    private EnnemyAudio enemy_Audio;

    private PlayerStats player_Stats;


	void Awake ()
    {
	
        if(is_Boar || is_Cannibal)
        {

            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            enemy_Audio = GetComponentInChildren<EnnemyAudio>();
        }

        if (is_Player)
        {

            player_Stats = GetComponent<PlayerStats>();


        }

	}
	
	

	public void ApplyDamege(float damage)
    {

        if (is_Dead) return;

        health -= damage;

        if (is_Player)
        {

            player_Stats.Display_HealthStats(health);

        }
        if(is_Boar || is_Cannibal)
        {

            if(enemy_Controller.Enemy_State == EnemyState.PATROL)
            {

                enemy_Controller.chase_Distance = 50f;

            }


        }
        if ( health <= 0)
        {

            PlayerDied();
            is_Dead = true;

        }

    }
    void PlayerDied()
    {

        if (is_Cannibal)
        {

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 10f);

            gameObject.SetActive(false);

            enemy_Controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;

            StartCoroutine(DeadSound());
            gameObject.SetActive(false);

        }
        if (is_Boar)
        {

            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_Controller.enabled = false;

            enemy_Anim.Dead();

            StartCoroutine(DeadSound());

        }

        if (is_Player)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for(int i = 0; i < enemies.Length; i++)
            {

                enemies[1].GetComponent<EnemyController>().enabled = false;

            }

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAtack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);


        }

        if(tag == Tags.PLAYER_TAG)
        {

            Invoke("RestartGame", 3f);

        }
        else
        {

            Invoke("TurnOffGameObject", 3f);

        }

    }

    void RestartGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

    } 

    void TurnOffGameObject()
    {

        gameObject.SetActive(false);

    }

    IEnumerator DeadSound()
    {

        yield return new WaitForSeconds(0.3f);
        enemy_Audio.Play_DeadSound();

    }
}




















































