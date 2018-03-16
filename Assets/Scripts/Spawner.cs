using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject ball;

    private int force = 1;
    private int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(string.Format("{0}, {1}", count, 1 / Time.deltaTime));

        for (int i = 0; i < 2; i++)
        {
            var b = Instantiate(ball, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
            force *= -1;
            count += 1;
        }
	}
}
