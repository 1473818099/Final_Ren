using UnityEngine;

namespace Polyperfect.Universal
{
    public class PlayerMovement : MonoBehaviour
    {

        public CharacterController controller;
        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;


        Vector3 velocity;
        bool isGrounded;
        bool isMoving;

        private Vector3 lastPostiion = new Vector3(0f, 0f, 0f);


        void Update()
        {
            // Ground check
            controller = GetComponent<CharacterController>();
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                // Reset the default velocity
                controller.slopeLimit = 45.0f;
                velocity.y = -2f;
            }

            // Get inputs
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Create moving vector
            Vector3 move = transform.right * x + transform.forward * z;
            if (move.magnitude > 1)
                move /= move.magnitude;

            // Actually move the player
            controller.Move(move * speed * Time.deltaTime);
            
            // Jump
            if (Input.GetButtonDown("Jump") && isGrounded)

            {
                controller.slopeLimit = 100.0f;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }


            // Falling down
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
            
            if (lastPostiion != gameObject.transform.position && isGrounded == true)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            lastPostiion = gameObject.transform.position;




        }
    }
}