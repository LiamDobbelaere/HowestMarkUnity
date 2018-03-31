using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stress3D : MonoBehaviour {
    public GameObject stamp;

    private int count = 0;
    private int conditionCount = 0;

    private float extents = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.deltaTime;

        Debug.Log(string.Format("bench {0}, {1}", count, fps));

        for (int i = 0; i < 25; i++)
        {
            Vector3 position = new Vector3(transform.position.x + Random.Range(-extents, extents),
                transform.position.y + Random.Range(-extents, extents), transform.position.z + Random.Range(-extents, extents));

            Instantiate(stamp, position, Quaternion.identity);

            count += 1;
        }

        if (fps < 60.0f) conditionCount++;
        else conditionCount = 0;
        if (conditionCount > 60) Application.Quit();
    }
}
