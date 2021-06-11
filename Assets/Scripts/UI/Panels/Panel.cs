using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Panel : MonoBehaviour
{
    [SerializeField]
    [Range(0.05f, 20f)]
    private float defaultSpeedMultiplier = 10f;

    public float DefaultSpeedMultiplier
    {
        get { return defaultSpeedMultiplier; }
    }

    public Animator Animator { get; private set; }

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

    public PanelBackground Background { get; private set; }

    public PanelForeground Foreground { get; private set; }

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
        Animator = GetComponent<Animator>();

        Background = GetComponentInChildren<PanelBackground>();
        Foreground = GetComponentInChildren<PanelForeground>();
    }

    protected virtual void Start()
    {
        InitialSpeedMultiplier = DefaultSpeedMultiplier;
        SpeedMultiplier = DefaultSpeedMultiplier;
    }
}