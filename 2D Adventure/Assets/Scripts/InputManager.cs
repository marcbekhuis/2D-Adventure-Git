using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    enum KeyState
    {
        KeyDown,
        Key,
        KeyUp
    }


    [System.Serializable]
    class KeyInput 
    {
        public string actionName = "New Action";
        [Space]
        public KeyState keyState;
        [Space]
        public KeyCode[] keys;
        [Space]
        public UnityEvent functionsToCall;

        public void CheckForInput()
        {
            foreach (var key in keys)
            {
                switch (keyState)
                {
                    case KeyState.KeyDown:
                        if (Input.GetKeyDown(key))
                        {
                            functionsToCall.Invoke();
                            return;
                        }
                        break;
                    case KeyState.Key:
                        if (Input.GetKey(key))
                        {
                            functionsToCall.Invoke();
                            return;
                        }
                        break;
                    case KeyState.KeyUp:
                        if (Input.GetKeyUp(key))
                        {
                            functionsToCall.Invoke();
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

    [SerializeField] private KeyInput[] keyInputs;

    void Update()
    {
        foreach (var keyInput in keyInputs)
        {
            keyInput.CheckForInput();
        }
    }
}
