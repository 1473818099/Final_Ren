using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Image healthFillImage;
    public Transform lookAtCamera;
    public float maxWidth = 2f;

    public void SetHealth(float current, float max)
    {
        float width = (current / max) * maxWidth;
        RectTransform healthRectTransform = healthFillImage.GetComponent<RectTransform>();
        healthRectTransform.sizeDelta = new Vector2(width, healthRectTransform.sizeDelta.y);
    }

    void LateUpdate()
    {
        // Make the health bar always face the camera
        if (lookAtCamera != null)
        {
            transform.LookAt(transform.position + lookAtCamera.forward);
        }
    }
}

