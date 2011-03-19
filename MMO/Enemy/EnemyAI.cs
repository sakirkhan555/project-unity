using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform target;
    public int MoveSpeed = 1;
    public int RotationSpeed = 1;
    public int MaxDistance;

    public int AggroDistance = 20;

    private Transform myTransform;

    void Awake ()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

        MaxDistance = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawLine(target.transform.position, myTransform.position, Color.yellow);

        if (Vector3.Distance(target.position, myTransform.position) < AggroDistance)
        {

            // Look at target
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), RotationSpeed * Time.deltaTime);

            if (Vector3.Distance(target.position, myTransform.position) > MaxDistance)
            {

                // Move to target
                myTransform.position += myTransform.forward * MoveSpeed * Time.deltaTime;
            }

        }

        

	}

   
}
