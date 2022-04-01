using TMPro;

public class TextPanel : Panel
{
    internal TMP_Text TextMeshPro { get; private set; }

    public string Text
    {
        get { return TextMeshPro.text; }
        set { TextMeshPro.text = value; }
    }

    protected override void Awake()
    {
        base.Awake();

        TextMeshPro = GetComponentInChildren<TMP_Text>();
    }
}
