using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveIfYouDare.Events;

namespace MoveIfYouDare.Lights
{
    public class LightSwitch : MonoBehaviour
    {
        [SerializeField] private int lightId;
        private bool isInContact = true;

        private void Update() 
        {
            if (isInContact)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ActionsList.OnSingleLightSwitch?.Invoke(lightId);
                }
            }
        }
    }
}

