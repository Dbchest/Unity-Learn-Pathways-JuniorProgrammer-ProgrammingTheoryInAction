using UnityEngine;

public class PanelDebugGUI : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10f)]
    private float speedMultiplier = 1f;

    [SerializeField]
    private int fontSize;

    [SerializeField]
    private Rect showRect;

    [SerializeField]
    private Rect hideRect;

    [SerializeField]
    private Rect openRect;

    [SerializeField]
    private Rect openWithSpeedRect;

    [SerializeField]
    private Rect closeRect;

    [SerializeField]
    private Rect closeWithSpeedRect;

    public GUIStyle Style { get; private set; }

    public Panel Panel { get; private set; }

    private void Awake()
    {
        Style = new GUIStyle("button")
        {
            fontSize = fontSize
        };

        Panel = GetComponent<Panel>();
    }

    private void OnGUI()
    {
        if (GUI.Button(showRect, "Show", Style))
        {
            Panel.Show();
        }

        if (GUI.Button(hideRect, "Hide", Style))
        {
            Panel.Hide();
        }

        if (GUI.Button(openRect, "Open", Style))
        {
            Panel.Open();
        }

        if (GUI.Button(openWithSpeedRect, "Open with Speed", Style))
        {
            Panel.Open(speedMultiplier);
        }

        if (GUI.Button(closeRect, "Close", Style))
        {
            Panel.Close();
        }

        if (GUI.Button(closeWithSpeedRect, "Close with Speed", Style))
        {
            Panel.Close(speedMultiplier);
        }
    }
}