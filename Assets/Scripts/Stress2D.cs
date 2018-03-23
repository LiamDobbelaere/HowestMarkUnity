using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress2D : MonoBehaviour {
    public GameObject box;

    private Camera camera;
    private int count = 0;
    private int conditionCount = 0;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        float fps = 1 / Time.deltaTime;

        Debug.Log(string.Format("{0}, {1}", count, fps));

        for (int i = 0; i < 25; i++)
        {
            Vector3 position = new Vector3(camera.transform.position.x + Random.Range(-camera.orthographicSize, camera.orthographicSize),
                camera.transform.position.y + Random.Range(-camera.orthographicSize, camera.orthographicSize), 0f);

            Instantiate(box, position, Quaternion.identity);

            count += 1;
        }

        if (fps < 60.0f) conditionCount++;
        else conditionCount = 0;
        if (conditionCount > 60) Application.Quit();
    }
}
