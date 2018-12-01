using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //target of interest
    public GameObject focusTarget;
    private Vector3 targetPosition;
    public float moveSpeed;
	// Use this for initialization
	void Start () {
        //focusTarget = new GameObject("Player");
        moveSpeed = 7;

        focusTarget = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if(focusTarget != null)
        {
            //each frame update the camera's position changes to the main character's position
            targetPosition = new Vector3(focusTarget.transform.position.x, focusTarget.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(findTarget());
        }

	}

    public IEnumerator findTarget()
    {
        while(focusTarget == null)
        {
            Debug.Log("focus target is null");
            focusTarget = GameObject.Find("Player(Clone)");
            yield return null;
        }
    }
}
