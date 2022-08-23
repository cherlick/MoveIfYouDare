using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveIfYouDare.Events;

namespace MoveIfYouDare.Events
{
    public static class ActionsList
    {
        public static Action<bool> OnLightSwitch;
        public static Action<int> OnSingleLightSwitch;
        public static Action<bool> OnTheLight;
        public static Action<bool, Vector2> OnPlayerMoving;
        public static Action OnPlayerDeath;
    }
}

