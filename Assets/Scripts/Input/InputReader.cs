using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    //Allows us to creats an instance of this in the editor
    [CreateAssetMenu(menuName = "InputReader")]

    public class InputReader : ScriptableObject, InputMap.IGameplayActions, InputMap.IPauseMenuActions
    {
        private InputMap inputMap;

        private void OnEnable()
        {
            //Creates an inputMap if it doesnt already exist
            if (inputMap == null) 
            { 
                inputMap = new InputMap();

                inputMap.Gameplay.SetCallbacks(this);
                inputMap.PauseMenu.SetCallbacks(this);

                SetGameplay();
            }
        }

        //Easy function to set which inputs are active
        public void SetGameplay()
        {
            inputMap.Gameplay.Enable();
            inputMap.PauseMenu.Disable();
        }
        public void SetPauseMenu()
        {
            inputMap.PauseMenu.Enable();
            inputMap.Gameplay.Disable();
        }

        //Creation of events to inform other scripts when a button is pressed 
        public event Action<Vector2> MoveEvent;

        public event Action ShootEvent;
        public event Action ShootCancelledEvent;
       
        public event Action PauseEvent;

        public event Action ResumeEvent;



        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();
                SetPauseMenu();
            }
        }    

        public void OnResume(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ResumeEvent?.Invoke();
                SetGameplay();
            }

        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ShootEvent?.Invoke();
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                ShootCancelledEvent?.Invoke();
            }

        }
    }
}
