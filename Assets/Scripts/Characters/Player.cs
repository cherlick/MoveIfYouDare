using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveIfYouDare.Events;

namespace MoveIfYouDare.Characters
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float moveSpeed;
        private bool canMove = true;
        private bool isAbleToClimb = false;
        private Vector2 climbToPosition;
        private void Update() 
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            bool isTryClimbing = Input.GetKeyDown(KeyCode.W);
            Move(xAxis);
            Climb(isTryClimbing);
            CheckIfMoving(xAxis, isTryClimbing);
        }

        private void FinishClimb()
        {
            transform.position = climbToPosition;
            canMove = true;
        }

        private void Move(float axisValue)
        {
            if (!canMove) return;
            if ((int)axisValue == -1)
            {
                spriteRenderer.flipX = false;
            }
            if ((int)axisValue == 1)
            {
                spriteRenderer.flipX = true;
            }

            Vector2 direction = new Vector2(axisValue, rigidBody2D.velocity.y);
            direction = direction * moveSpeed;
            rigidBody2D.velocity = direction;
            animator.SetFloat("walk", Mathf.Abs(axisValue));
        }

        private void Climb(bool isTryClimbing)
        {
            
            if (!isTryClimbing) return;

            if (isAbleToClimb)
            {
                animator.SetTrigger("canClimb");
                canMove = false;
            }
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
            }

            if (other.CompareTag("ClimbZone"))
            {
                var dist = Vector2.Distance(other.transform.position,transform.position);
                float distToAdd = other.transform.position.x > transform.position.x 
                    ? dist/2 : -(dist/2);

                climbToPosition = new Vector2(other.transform.position.x - distToAdd, other.transform.position.y + 1f);
                isAbleToClimb = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("LightZone"))
            {
                ActionsList.OnTheLight?.Invoke(false);
                Debug.Log("Not Safe");
            }

            if (other.CompareTag("ClimbZone"))
            {
                isAbleToClimb = false;
            }
        }
    }
}

