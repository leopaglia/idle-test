using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public void SetHealth(float normalizedValue)
    {
        fillImage.fillAmount = normalizedValue;
    }
}