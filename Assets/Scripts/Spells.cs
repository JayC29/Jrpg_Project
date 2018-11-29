using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour {

    private Rigidbody2D rigidbody;

    [SerializeField]
    private float spellSpeed;

    private Transform target;
    // Use this for initialization
    void Start() {
        spellSpeed = 3;
        rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Jerry").transform;
        //Debug.Log("Target is " + );
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        rigidbody.velocity = direction.normalized * spellSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


}
