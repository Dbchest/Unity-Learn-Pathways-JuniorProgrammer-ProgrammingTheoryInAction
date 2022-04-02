using UnityEngine;

public class TextPanelDebugger : MonoBehaviour
{
    private TextPanel TextPanel { get; set; }

    private void Awake()
    {
        TextPanel = GetComponent<TextPanel>();
    }

    private void OnGUI()
    {
        float padding = 18f;

        Rect textRect = new (padding, padding, 720, 180);
        TextPanel.Text = GUI.TextArea(textRect, TextPanel.Text);
    }
}
