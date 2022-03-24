using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class Panel : MonoBehaviour
{
    [SerializeField]
    private bool showAtStart;

    [SerializeField]
    private bool openAtStart;

    [SerializeField]
    [Range(0.05f, 20f)]
    private float defaultSpeedMultiplier = 10f;

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

    public Animator Animator { get; private set; }

    public float DefaultSpeedMultiplier
    {
        get { return defaultSpeedMultiplier; }
    }

    public float InitialSpeedMultiplier
    {
        get { return Animator.GetFloat("Initial Speed Multiplier"); }

        private set
        {
            if (value < 0.05f || value > 20f)
            {
                Mathf.Clamp(value, 0.05f, 20f);
            }

            Animator.SetFloat("Initial Speed Multiplier", value);
        }
    }

    public float SpeedMultiplier
    {
        get { return Animator.GetFloat("Speed Multiplier"); }

        private set
        {
            if (value < 0.05f || value > 20f)
            {
                Mathf.Clamp(value, 0.05f, 20f);
            }

            Animator.SetFloat("Speed Multiplier", value);
        }
    }

    public int Sign
    {
        get { return Animator.GetInteger("Sign"); }

        private set
        {
            if (value < -2 || value > 2)
            {
                Mathf.Clamp(value, -2, 2);
            }

            Animator.SetInteger("Sign", value);
        }
    }

    public bool IsBusy
    {
        get { return Animator.GetBool("Is Busy"); }
    }

    public void SetOpacity(int alpha)
    {
        if (alpha < 0 || alpha > 255)
        {
            Mathf.Clamp(alpha, 0, 255);
        }

        Opacity = (float)alpha / 255;
    }

    public void Show()
    {
        Sign = 1;
    }

    public void Hide()
    {
        Sign = -1;
    }

    public void Open()
    {
        Sign = 2;
    }

    public void Open(float speedMultiplier)
    {
        if (Sign <= 0)
        {
            SpeedMultiplier = speedMultiplier;

            Open();
        }
    }

    public void Close()
    {
        Sign = -2;
    }

    public void Close(float speedMultiplier)
    {
        if (Sign >= 0)
        {
            SpeedMultiplier = speedMultiplier;

            Close();
        }
    }

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
        Animator = GetComponent<Animator>();

        InitialSpeedMultiplier = DefaultSpeedMultiplier;
        SpeedMultiplier = DefaultSpeedMultiplier;
    }

    protected virtual void Start()
    {
        if (showAtStart)
        {
            Show();
        }

        if (openAtStart)
        {
            Open();
        }
    }
}