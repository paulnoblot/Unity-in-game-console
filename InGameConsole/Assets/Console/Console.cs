﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameConsole
{
    public class Console : MonoBehaviour
    {
        [SerializeField]
        private static Transform consoleContent;
        private static InputField input;
        private static Button enterButton;
        private static Button exitButton;
        private static Button minusButton;
        private static Button clearButton;

        private static GameObject gameobjectNewText;

        // private static Console singleton;


        private void Awake()
        {
            consoleContent = transform.Find("ScrollView").Find("Viewport").Find("Content");
            input = transform.Find("InputField").GetComponent<InputField>();
            enterButton = transform.Find("EnterButton").GetComponent<Button>();
            exitButton = transform.Find("Buttons").Find("ExitButton").GetComponent<Button>();
            minusButton = transform.Find("Buttons").Find("MinusButton").GetComponent<Button>();
            clearButton = transform.Find("Buttons").Find("ClearButton").GetComponent<Button>();
            gameobjectNewText = transform.Find("NewText").gameObject;

            clearButton.onClick.AddListener(ClearConsole);
        }


        public static void Write(string _message, Color _color)
        {
            // if (!singleton)
            //     singleton = new Console();
         
            GameObject newText = Instantiate(gameobjectNewText, consoleContent);
            newText.GetComponent<Text>().color = _color;
            newText.GetComponent<Text>().text = "[" + System.DateTime.UtcNow.ToString("HH:mm:ss") + "] " + _message;
            //newText.transform.SetAsFirstSibling();

            // width = 580

            //consoleContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, consoleContent.childCount * 30);
        }
        
        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == consoleContent.gameObject)
            {
                input.Select();
                input.ActivateInputField();
            }

            if (EventSystem.current.currentSelectedGameObject == input.gameObject && Input.GetKeyDown(KeyCode.Return))
            {
                Send();
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                input.Select();
                input.ActivateInputField();
            }
        }
        
        public static void Write(string _message)
        {
            Write(_message, new Color(0.12f, 0.12f, 0.12f));
        }
        
        public static void Warning(string _message)
        {
            Write(_message, Color.yellow);
        }

        public static void Error(string _message)
        {
            Write(_message, Color.red);
        }

        private static void Send()
        {
            Write(input.text);
            input.text = string.Empty;
            input.Select();
            input.ActivateInputField();
        }

        public static void ClearConsole()
        {
            foreach (Transform child in consoleContent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
