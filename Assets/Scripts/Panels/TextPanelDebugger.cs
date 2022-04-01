using UnityEngine;

public class TextPanelDebugger : MonoBehaviour
{
    private string text;

    private TextPanel textPanel { get; set; }

    private void Awake()
    {
        textPanel = GetComponent<TextPanel>();
    }

    private void OnGUI()
    {
        Rect textRect = new Rect(18, 18, 720, 180);
        text = GUI.TextArea(textRect, text);

        Rect buttonRect = new Rect(18, 18 + 180 + 18, 144, 36);
        if (GUI.Button(buttonRect, "Apply"))
        {
            if (textPanel.Text != text)
            {
                textPanel.Text = text;
            }
        }
    }
}
