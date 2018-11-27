using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Animator animator;

    protected Vector2 direction;

    // Use this for initialization
    protected virtual void Start ()
    {
        speed = 5;
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }
    /// <summary>
    /// Moves the Player
    /// </summary>
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        AnimateMovement(direction);
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
    
}
