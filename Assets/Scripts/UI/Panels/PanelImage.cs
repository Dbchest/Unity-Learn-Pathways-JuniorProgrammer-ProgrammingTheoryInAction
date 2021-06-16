using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PanelImage : MonoBehaviour
{
    public Image Image { get; private set; }

    public float Opacity
    {
        get { return Image.color.a; }

        set
        {
            var color = Image.color;

            if (value < 0f || value > 1f)
            {
                Mathf.Clamp(value, 0f, 1f);
            }

            Image.color = new Color(color.r, color.g, color.b, value);
        }
    }

    public void SetOpacity(int alpha)
    {
        if (alpha < 0 || alpha > 255)
        {
            Mathf.Clamp(alpha, 0, 255);
        }

        Opacity = (float)alpha / 255;
    }

    private void Awake()
    {
        Image = GetComponent<Image>();
    }
}