using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private List<KeyCode> keyCodeList = new List<KeyCode>();

    public void AddKeyCode(KeyCode keyCode)
    {
        keyCodeList.Add(keyCode);
    }

    public void Awake()
    {
       Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameDone)
        {
            return;
        }
        foreach (KeyCode keyCode in keyCodeList)
        {
            if(Input.GetKeyDown(keyCode))
            {
                NoteManager.Instance.OnInput(keyCode);
                break;
            }
        }
        
    }
}
