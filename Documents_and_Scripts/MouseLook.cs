using UnityEngine;

namespace Polyperfect.Universal
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 3f;
        public Transform playerBody;
        float xRotation = 0f;
        float yRotation = 0f;
        public float topClamp = -90f;
        public float bottomClamp = 90f;


        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

            yRotation += mouseX;

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
  