using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour {
    public GameObject ball;

    private float force = 0.5f;
    private int count = 0;
    private int conditionCount = 0;

    private float distance = 2.695f;
    private float frustum_height;
    private float frustum_width;

    // Use this for initialization
    void Start () {
        var aspect = 1024f / 768f;
        frustum_height = 2.0f * -distance * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        frustum_width = frustum_height * aspect;
    }

    // Update is called once per frame
    void Update () {
        float fps = 1 / Time.deltaTime;

        Debug.Log(string.Format("bench {0}, {1}", count, fps));

        for (int i = 0; i < 2; i++)
        {
            var b = Instantiate(ball, transform.position + new Vector3(-force, 0f , 0f), Quaternion.identity);
            b.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0, -force), ForceMode.Impulse);
            force *= -1;

            count += 1;
        }

        if (fps < 60.0f) conditionCount++;
        else conditionCount = 0;
        if (conditionCount > 60) Application.Quit();
    }
}
