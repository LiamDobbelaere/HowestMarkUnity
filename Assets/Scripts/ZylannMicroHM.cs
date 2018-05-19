using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZylannMicroHM : MonoBehaviour {
    private const int ITERATIONS = 2000000;
    private const float AVG_TIMES = 10.0f;

    private Chronometer chronometer = new Chronometer();
    private long forTime;

    /* Stuff used for tests { */
    private int memberVar = 1;

    void EmptyVoidFunction()
    {

    }
    /* } Stuff used for tests */

    // Use this for initialization
    void Start() {
        float vtest_for_loop = 0.0f;
        float vtest_empty_func = 0.0f;
        float vtest_increment = 0.0f;
        float vtest_increment_x5 = 0.0f;
        float vtest_increment_with_member_var = 0.0f;
        float vtest_increment_with_local_outside_loop = 0.0f;
        float vtest_increment_with_local_inside_loop = 0.0f;
        float vtest_increment_vector2 = 0.0f;
        float vtest_increment_vector3 = 0.0f;
        float vtest_increment_vector3_constant = 0.0f;
        float vtest_increment_vector3_individual_xyz = 0.0f;
        float vtest_unused_local = 0.0f;
        float vtest_divide = 0.0f;
        float vtest_increment_with_array_member = 0.0f;
        float vtest_if_true = 0.0f;
        float vtest_if_true_else = 0.0f;

        var avg_count = 0;
        while (avg_count < AVG_TIMES) {
            vtest_for_loop += test_for_loop();
            vtest_empty_func += test_empty_func();
            vtest_increment += test_increment();
            vtest_increment_x5 += test_increment_x5();
            vtest_increment_with_member_var += test_increment_with_member_var();
            vtest_increment_with_local_outside_loop += test_increment_with_local_outside_loop();
            vtest_increment_with_local_inside_loop += test_increment_with_local_inside_loop();
            vtest_increment_vector2 += test_increment_vector2();
            vtest_increment_vector3 += test_increment_vector3();
            vtest_increment_vector3_constant += test_increment_vector3_constant();
            vtest_increment_vector3_individual_xyz += test_increment_vector3_individual_xyz();
            vtest_unused_local += test_unused_local();
            vtest_divide += test_divide();
            vtest_increment_with_array_member += test_increment_with_array_member();
            vtest_if_true += test_if_true();
            vtest_if_true_else += test_if_true_else();
            avg_count += 1;
        }

        vtest_for_loop /= AVG_TIMES;
        vtest_empty_func /= AVG_TIMES;
        vtest_increment /= AVG_TIMES;
        vtest_increment_x5 /= AVG_TIMES;
        vtest_increment_with_member_var /= AVG_TIMES;
        vtest_increment_with_local_outside_loop /= AVG_TIMES;
        vtest_increment_with_local_inside_loop /= AVG_TIMES;
        vtest_increment_vector2 /= AVG_TIMES;
        vtest_increment_vector3 /= AVG_TIMES;
        vtest_increment_vector3_constant /= AVG_TIMES;
        vtest_increment_vector3_individual_xyz /= AVG_TIMES;
        vtest_unused_local /= AVG_TIMES;
        vtest_divide /= AVG_TIMES;
        vtest_increment_with_array_member /= AVG_TIMES;
        vtest_if_true /= AVG_TIMES;
        vtest_if_true_else /= AVG_TIMES;

        Debug.Log(string.Format("bench test_for_loop, {0}", vtest_for_loop));
        Debug.Log(string.Format("bench test_empty_func, {0}", vtest_empty_func));
        Debug.Log(string.Format("bench test_increment, {0}", vtest_increment));
        Debug.Log(string.Format("bench test_increment_x5, {0}", vtest_increment_x5));
        Debug.Log(string.Format("bench test_increment_with_member_var, {0}", vtest_increment_with_member_var));
        Debug.Log(string.Format("bench test_increment_with_local_outside_loop, {0}", vtest_increment_with_local_outside_loop));
        Debug.Log(string.Format("bench test_increment_with_local_inside_loop, {0}", vtest_increment_with_local_inside_loop));
        Debug.Log(string.Format("bench test_increment_vector2, {0}", vtest_increment_vector2));
        Debug.Log(string.Format("bench test_increment_vector3, {0}", vtest_increment_vector3));
        Debug.Log(string.Format("bench test_increment_vector3_constant, {0}", vtest_increment_vector3_constant));
        Debug.Log(string.Format("bench test_increment_vector3_individual_xyz, {0}", vtest_increment_vector3_individual_xyz));
        Debug.Log(string.Format("bench test_unused_local, {0}", vtest_unused_local));
        Debug.Log(string.Format("bench test_divide, {0}", vtest_divide));
        Debug.Log(string.Format("bench test_increment_with_array_member, {0}", vtest_increment_with_array_member));
        Debug.Log(string.Format("bench test_if_true, {0}", vtest_if_true));
        Debug.Log(string.Format("bench test_if_true_else, {0}", vtest_if_true_else));

        Application.Quit();
    }

    //-------------------------------------------------------------------------------
    private long test_for_loop()
    {
        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {

        }

        forTime = chronometer.Stop();

        return forTime;
    }
    //-------------------------------------------------------------------------------
    private long test_empty_func () {
        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            EmptyVoidFunction();
        }

        return chronometer.Stop() - forTime;
    }
    //-------------------------------------------------------------------------------
    private long test_increment()
    {
        var a = 0;

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += 1;
        }

        return chronometer.Stop() - forTime;
    }


    //-------------------------------------------------------------------------------
    private long test_increment_x5()
    {
        var a = 0;

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += 1;
            a += 1;
            a += 1;
            a += 1;
            a += 1;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_with_member_var()
    {
        var a = 0;

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += memberVar;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_with_local_outside_loop()
    {
        var a = 0;
        var b = 1;

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += b;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_with_local_inside_loop()
    {
        var a = 0;

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            var b = 1;
            a += b;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_vector2()
    {
        var a = new Vector2(0, 0);
        var b = new Vector2(1, 1);

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += b;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_vector3()
    {
        var a = new Vector3(0, 0, 0);
        var b = new Vector3(1, 1, 1);

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += b;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_vector3_constant()
    {
        var a = new Vector3(0, 0, 0);

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += new Vector3(1, 1, 1);
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_vector3_individual_xyz()
    {
        var a = new Vector3(0, 0, 0);
        var b = new Vector3(1, 1, 1);

        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            a.x += b.x;
            a.y += b.y;
            a.z += b.z;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_unused_local()
    {
        chronometer.Start();

        for (int i = 0; i < ITERATIONS; i++)
        {
            var b = 1;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_divide()
    {
        chronometer.Start();

        var a = 9999.0;

        for (int i = 0; i < ITERATIONS; i++)
        {
            a /= 1.01;
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_increment_with_array_member()
    {
        chronometer.Start();
        var a = 0;
        int[] arr = { 1 };

        for (int i = 0; i < ITERATIONS; i++)
        {
            a += arr[0];
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_if_true()
    {
        chronometer.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            if (true)
            {

            }
        }

        return chronometer.Stop() - forTime;
    }

    //-------------------------------------------------------------------------------
    private long test_if_true_else()
    {
        chronometer.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            if (true)
            {

            }
            else
            {

            }
        }

        return chronometer.Stop() - forTime;
    }
}
