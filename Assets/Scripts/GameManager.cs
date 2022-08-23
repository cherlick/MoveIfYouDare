using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveIfYouDare.Tools;
using MoveIfYouDare.Events;
using MoveIfYouDare.ScenesChangeSystem;

namespace MoveIfYouDare.Core
{
    public class GameManager : Singleton<GameManager>
    {
        private void OnEnable() 
        {
            ActionsList.OnPlayerDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            ScenesManager.RestartScene();
        }
    }
}

