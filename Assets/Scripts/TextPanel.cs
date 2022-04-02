using TMPro;

public class TextPanel : Panel
{
    public string Text
    {
        get { return TextMeshPro.text; }
        set { TextMeshPro.text = value; }
    }

    private TMP_Text TextMeshPro { get; set; }

    protected override void Awake()
    {
        base.Awake();

        TextMeshPro = GetComponentInChildren<TMP_Text>();
    }
}
