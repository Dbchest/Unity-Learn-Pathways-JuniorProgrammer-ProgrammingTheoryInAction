using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Panel : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10f)]
    private float defaultSpeedMultiplier = 1f;

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
            var v = Mathf.Clamp(value, 0.1f, 10f);
            Animator.SetFloat("Initial Speed Multiplier", v);
        }
    }

    public float SpeedMultiplier
    {
        get { return Animator.GetFloat("Speed Multiplier"); }

        private set
        {
            var v = Mathf.Clamp(value, 0.1f, 10f);
            Animator.SetFloat("Speed Multiplier", v);
        }
    }

    public int Sign
    {
        get { return Animator.GetInteger("Sign"); }

        private set { Animator.SetInteger("Sign", value); }
    }

    public bool IsBusy
    {
        get { return Animator.GetBool("Is Busy"); }
    }

    public PanelBackground Background { get; private set; }

    public PanelForeground Foreground { get; private set; }

    public void Show()
    {
        Animator.SetInteger("Sign", 1);
    }

    public void Hide()
    {
        Animator.SetInteger("Sign", -1);
    }

    public void Open()
    {
        Animator.SetInteger("Sign", 2);
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
        Animator.SetInteger("Sign", -2);
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

        Background = GetComponent<PanelBackground>();
        Foreground = GetComponent<PanelForeground>();
    }

    protected virtual void Start()
    {
        InitialSpeedMultiplier = DefaultSpeedMultiplier;
        SpeedMultiplier = DefaultSpeedMultiplier;
    }
}