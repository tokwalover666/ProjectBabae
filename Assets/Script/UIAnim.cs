using UnityEngine;
using UnityEngine.UI;

public class UIAnim : MonoBehaviour
{
    private Image img;
    private RectTransform rect;
    private Vector3 startPos;

    [Header("Float Settings")]
    public float floatHeight = 10f;
    public float floatSpeed = 1f;

    [Header("Rotation Settings")]
    public float rotationAmount = 5f;
    public float rotationSpeed = 0.5f;

    [Header("Flicker Settings")]
    public float flickerAmount = 0.2f;
    public float flickerSpeed = 2f;

    void Start()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
    }

    void Update()
    {
        float time = Time.time;

        float floatY = Mathf.Sin(time * floatSpeed) * floatHeight;
        rect.anchoredPosition = startPos + new Vector3(0, floatY, 0);

        float rotation = Mathf.Sin(time * rotationSpeed) * rotationAmount;
        rect.localRotation = Quaternion.Euler(0, 0, rotation);

  
        Color color = img.color;
        float alpha = 1f - (Mathf.Sin(time * flickerSpeed) * flickerAmount);
        color.a = Mathf.Clamp(alpha, 0.6f, 1f);
        img.color = color;

        float scale = 1 + Mathf.Sin(time * 0.8f) * 0.03f;
        rect.localScale = new Vector3(scale, scale, 1);
    }
}