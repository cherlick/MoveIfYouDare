using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveIfYouDare.Events;

namespace MoveIfYouDare.Characters
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private float moveSpeed;
        private bool isMoving = false;
        private void Update() 
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            bool isTryClimbing = Input.GetKeyDown(KeyCode.W);
            Move(xAxis);
            Climb(isTryClimbing);
            CheckIfMoving(xAxis, isTryClimbing);

        }

        private void Move(float axisValue)
        {
            Vector2 direction = new Vector2(axisValue, 0);
            direction = direction * moveSpeed;
            rigidBody2D.velocity = direction;
        }

        private void Climb(bool isTryClimbing)
        {
            if (!isTryClimbing) return;
        }

        private void CheckIfMoving(float xAxis, bool isClimbing)
        {
            ActionsList.OnPlayerMoving?.Invoke(Mathf.Abs(xAxis) > 0 || isClimbing, transform.position);
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("LightZone"))
            {
                ActionsList.OnTheLight?.Invoke(true);
                Debug.Log("Safe");
            }
            if (other.CompareTag("Enemy"))
            {
                ActionsList.OnPlayerDeath?.Invoke();
                //Play Animation
                Debug.Log("Death");
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("LightZone"))
            {
                ActionsList.OnTheLight?.Invoke(false);
                Debug.Log("Not Safe");
            }
        }
    }
}

