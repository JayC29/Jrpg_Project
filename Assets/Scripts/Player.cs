using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;

    private float initHealth = 100;

	// Use this for initialization
	protected override void Start ()
    {
        Debug.Log("I'm Woke");
        health.Initialize(initHealth, initHealth);

        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        GetInput();

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
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
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
    }
}
