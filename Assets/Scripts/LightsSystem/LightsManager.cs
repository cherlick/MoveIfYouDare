using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using MoveIfYouDare.Events;

namespace MoveIfYouDare.Core
{
    public class LightsManager : MonoBehaviour
    {
        [SerializeField] private float lightsOffTimer;
        [SerializeField] private float lightsOnTimer;
        private float countTimer;
        private bool isLightsOn = true;
        

        private void Start() 
        {
            SwitchLights(true);
        }

        private void FixedUpdate() 
        {
            if (countTimer <= 0)
            {
                countTimer = isLightsOn ? lightsOnTimer : lightsOffTimer;
                SwitchLights(!isLightsOn);
            }
            else
            {
                countTimer -= Time.deltaTime;
            }
        }

        private void SwitchLights(bool isOn)
        {
            isLightsOn = isOn;
            ActionsList.OnLightSwitch?.Invoke(isOn);
        }
        
    }
}

