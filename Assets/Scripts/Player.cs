﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    private float initMana = 50;

    private float initHealth = 100;

    [SerializeField]
    private GameObject[] spellPrefab;

    public Transform target { get; set; }

	// Use this for initialization
	protected override void Start ()
    {
        Debug.Log("I'm Woke");
        health.Initialize(initHealth, initHealth);

        mana.Initialize(initMana, initMana);

        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update()
    {
        GetInput();
        InLineOfSight();
        base.Update();
	}

    private void GetInput()
    {

        direction = Vector2.zero;

        ///THIS IS USED FOR DEBUGGING ONLY (health go down, and health go up)
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }



        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !IsMoving)
            {
                attackRoutine = StartCoroutine(Attack());
            }
           
        }
    }

    public IEnumerator Attack()
    {

        isAttacking = true;
        animator.SetBool("attack", isAttacking);

        yield return new WaitForSeconds(2); //cast time

        CastSpell();

        StopAttack();
    }

    public void CastSpell()
    {
        Instantiate(spellPrefab[0], transform.position, Quaternion.identity);
    }

    private bool InLineOfSight()
    {
        Vector3 targetDirection = (target.transform.position - transform.position).normalized;

        Debug.DrawRay(transform.position, targetDirection);
        return false;
    }
}
