using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PanelImage : MonoBehaviour
{
    public Image Image { get; private set; }

    public Sprite SourceImage
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

    public void Show()
    {
        Image.enabled = true;
    }

    public void Hide()
    {
        Image.enabled = false;
    }

    public void SetOpacity(float alpha)
    {
        if (alpha >= 0 && alpha <= 1)
        {
            Color = new Color(Color.r, Color.g, Color.b, alpha);
        }

        else
        {
            throw new System.ArgumentOutOfRangeException("alpha");
        }
    }

    public void SetOpacity(int alpha)
    {
        if (alpha >= 0 && alpha <= 255)
        {
            var rate = alpha / 255;
            SetOpacity(rate);
        }

        else
        {
            throw new System.ArgumentOutOfRangeException("alpha");
        }
    }

    private void Awake()
    {
        Image = GetComponent<Image>();
    }
}