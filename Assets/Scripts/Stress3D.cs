using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stress3D : MonoBehaviour {
    public GameObject stamp;

    private int count = 0;
    private int conditionCount = 0;

    private Camera camera;

    private float distance = 18f * 2f; //2.695f;
    private float frustum_height;
    private float frustum_width;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;

        var aspect = 1024f / 768f;
        frustum_height = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        frustum_width = frustum_height * aspect;

        Debug.Log(frustum_width);
        Debug.Log(frustum_height);
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.deltaTime;

        Debug.Log(string.Format("bench {0}, {1}", count, fps));

        for (int i = 0; i < 25; i++)
        {
            float rand_width = Random.Range(-frustum_width * 0.5f, frustum_width * 0.5f);
            float rand_height = Random.Range(-frustum_height * 0.5f, frustum_height * 0.5f);

            Vector3 position = new Vector3(rand_width, rand_height, distance);
            
            Instantiate(stamp, position, Quaternion.identity);

            count += 1;
        }

        if (fps < 60.0f) conditionCount++;
        else conditionCount = 0;
        if (conditionCount > 60) Application.Quit();
    }
}
