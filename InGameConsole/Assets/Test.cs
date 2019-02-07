using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameConsole.Console.Write("this is a message");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameConsole.Console.Warning("this is a warning");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GameConsole.Console.Error("this is an error");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GameConsole.Console.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
        }
    }
}
