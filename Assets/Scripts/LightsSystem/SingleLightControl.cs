using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using MoveIfYouDare.Events;
using System;

namespace MoveIfYouDare.Lights
{
    public class SingleLightControl : MonoBehaviour
    {
        [SerializeField] private int lightId;
        [SerializeField] private Light2D thisLight;
        [SerializeField] private PolygonCollider2D trigger;
        [SerializeField] private bool isChangedByLightsEvents = true;

        private bool wasOn;
        
        private void OnEnable() 
        {
            ActionsList.OnSingleLightSwitch += OnSwitchLight;
            ActionsList.OnLightSwitch += OnSwitchLights;
        }

        private void OnDisable() 
        {
            ActionsList.OnSingleLightSwitch -= OnSwitchLight;
            ActionsList.OnLightSwitch -= OnSwitchLights;
        }

        private void OnSwitchLights(bool isOn)
        {
            if (isChangedByLightsEvents)
            {
                thisLight.enabled = isOn;
                trigger.enabled = isOn;
            }
        }

        private void OnSwitchLight(int id)
        {
            if ( id == lightId)
            {
                thisLight.enabled = !thisLight.enabled;
                trigger.enabled = thisLight.enabled;
            }
            
        }
    }
}
