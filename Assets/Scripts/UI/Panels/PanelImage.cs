using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PanelImage : MonoBehaviour
{
    public Image Image { get; private set; }

    public bool Enabled
    {
        get { return Image.enabled; }

        private set { Image.enabled = value; }
    }

    public Sprite Sprite
    {
        get { return Image.sprite; }

        set { Image.sprite = value; }
    }

    public Color Color
    {
        get { return Image.color; }

        set { Image.color = value; }
    }

    public Material Material
    {
        get { return Image.material; }

        set { Image.material = value; }
    }

    public bool IsRaycastTarget
    {
        get { return Image.raycastTarget; }

        set { Image.raycastTarget = value; }
    }

    public float Opacity
    {
        get { return Color.a; }

        set
        {
            Mathf.Clamp(value, 0f, 1f);
            Color = new Color(Color.r, Color.g, Color.b, value);
        }
    }

    public void Show()
    {
        Enabled = true;
    }

    public void Hide()
    {
        Enabled = false;
    }

    public void SetOpacity(int alpha)
    {
        Mathf.Clamp(alpha, 0, 255);
        Opacity = (float)alpha / 255;
    }

    private void Awake()
    {
        Image = GetComponent<Image>();
    }
}