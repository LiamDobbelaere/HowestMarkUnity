using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress2D : MonoBehaviour {
    public GameObject box;

    private Camera camera;
    private int count = 0;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(string.Format("{0}, {1}", count, 1 / Time.deltaTime));

        for (int i = 0; i < 25; i++)
        {
            Vector3 position = new Vector3(camera.transform.position.x + Random.Range(-camera.orthographicSize, camera.orthographicSize),
                camera.transform.position.y + Random.Range(-camera.orthographicSize, camera.orthographicSize), 0f);

            Instantiate(box, position, Quaternion.identity);

            count += 1;
        }

    }
}
