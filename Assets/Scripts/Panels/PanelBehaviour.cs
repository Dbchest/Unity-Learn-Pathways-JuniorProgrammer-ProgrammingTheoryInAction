using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class PanelBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool showAtStart;

    [SerializeField]
    private bool openAtStart;

    [SerializeField]
    [Range(0.05f, 20f)]
    private float defaultSpeedMultiplier = 10f;

    public Image Image { get; private set; }

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