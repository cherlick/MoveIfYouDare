using UnityEngine;
using MoveIfYouDare.Events;
using UnityEngine.Rendering.Universal;

namespace MoveIfYouDare.Characters
{
    public class EvilEyes : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private Light2D eyesLight;
        [SerializeField] private BoxCollider2D thisCollider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed;
        private bool isPlayerSafe;
        private bool isPlayerMoving;
        private Vector2 playerPosition;
        private void OnEnable() 
        {
            ActionsList.OnTheLight += OnPlayerSafe;
            ActionsList.OnPlayerMoving += OnPlayerMoving;
        }

        private void OnDisable() 
        {
            ActionsList.OnTheLight -= OnPlayerSafe;
            ActionsList.OnPlayerMoving -= OnPlayerMoving;
        }

        private void Update() 
        {
            Move();
        }

        private void Move()
        {   
            if (!isPlayerSafe && isPlayerMoving)
            {
                Vector2 direction = playerPosition - (Vector2)transform.position;
                direction = direction * moveSpeed;
                rigidBody2D.velocity = direction;
            }
            else
            {
                rigidBody2D.velocity = Vector2.zero;
            }
            
        }

        private void OnPlayerSafe(bool isSafe)
        {
            isPlayerSafe = isSafe;
            eyesLight.enabled = !isSafe;
            thisCollider2D.enabled = !isSafe;
            spriteRenderer.enabled = !isSafe;
            animator.SetTrigger("blink");
            
        }
        private void OnPlayerMoving(bool isMoving, Vector2 newPlayerPosition)
        {
            isPlayerMoving = isMoving;
            playerPosition = newPlayerPosition;
        }
        
    }
}

