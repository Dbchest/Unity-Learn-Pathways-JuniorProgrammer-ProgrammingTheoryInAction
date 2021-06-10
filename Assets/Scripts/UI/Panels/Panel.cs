using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Panel : MonoBehaviour
{
    [SerializeField]
    private PanelImage background;

    [SerializeField]
    private PanelImage foreground;

    public Animator Animator { get; private set; }

    public PanelImage Background
    {
        get { return background; }
    }

    public PanelImage Foreground
    {
        get { return foreground; }
    }

    public void Open()
    {
        throw new System.NotImplementedException();
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
    }
}