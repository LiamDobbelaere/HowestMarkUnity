using System.Collections;
using System.Collections.Generic;
using Stopwatch = System.Diagnostics.Stopwatch;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    private Text textComponent;

    private const string COLOR_PINK = "#ec008c";
    private const string COLOR_YELLOW = "#fff200";
    private const string COLOR_BLUE = "#44c8f4";

    private readonly List<string> OPTIONS = new List<string> { "[Physics 2D]", "BallMark", "BoxMark", "PolyMark", "[Physics 3D]", "BallMark3D", "BoxMark3D", "PolyMark3D", "[Rendering]", "Stress2D", "Stress3D", "Stress3DUnlit", "[Logic]", "ZylannMicroHM" };
    private List<int> untouchable = new List<int>();

    private int index = -1;

    // Use this for initialization
    void Start () {
        //Automated mode
        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].StartsWith("-test"))
            {
                string scene = args[i].Split('=')[1];

                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }
        }

        textComponent = GetComponent<Text>();

        for (int x = 0; x < OPTIONS.Count; x++)
        {
            if (OPTIONS[x].Substring(0, 1) == "[")
            {
                untouchable.Add(x);
            }
        }


        MenuSelectNext();
        RedrawMenu();
	}
	
    void RedrawMenu()
    {
        string richtext = string.Format("<color={0}>Howest</color><color={1}>mark</color> Unity\n", COLOR_BLUE, COLOR_PINK);
        richtext += "----------------\n";

        for (int i = 0; i < OPTIONS.Count; i++)
        {
            if (i == index)
            {
                richtext += string.Format("<color={0}> {1}</color>\n" , COLOR_YELLOW, OPTIONS[i]);
            }
            else
            {
                if (untouchable.Contains(i))
                {
                    richtext += string.Format("<color={0}>{1}</color>\n", COLOR_BLUE, OPTIONS[i]);
                }
                else
                {
                    richtext += string.Format("{0}\n", OPTIONS[i]);
                }
            }
        }

        textComponent.text = richtext;
    }

    void MenuSelectNext()
    {
        index += 1;
        if (index >= OPTIONS.Count)
            index = 0;
        if (untouchable.Contains(index))
            MenuSelectNext();
    }

    void MenuSelectPrevious()
    {
        index -= 1;
        if (index < 0)
            index = OPTIONS.Count - 1;
        if (untouchable.Contains(index))
            MenuSelectPrevious();
    }
   	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MenuSelectNext();
            RedrawMenu();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MenuSelectPrevious();
            RedrawMenu();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(OPTIONS[index], LoadSceneMode.Single);
        }

	}
}
