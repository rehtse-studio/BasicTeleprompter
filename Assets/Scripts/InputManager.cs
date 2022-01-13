using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RehtseStudio.Teleprompter.Scrips
{
    public class InputManager : MonoBehaviour
    {
        private UIManager _uiManager;
        private PlayerInput _inputs;
        private InputAction _upOrDown;
        private int _yIndex;

        private void Awake()
        {
            _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
            _inputs = GetComponent<PlayerInput>();
            _upOrDown = _inputs.actions["UpOrDown"];
        }

        private void Update()
        {
            _uiManager.ScrollbarIndex((int)_upOrDown.ReadValue<Vector2>().y);
        }
    }
}

