using UnityEngine;
using UnityEngine.UI;

public class FastForwardButton : MonoBehaviour {

    public Color fastForwardActivatedColor;
    public Color fastForwardDeactivatedColor;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        img.color = fastForwardDeactivatedColor;
    }

    private void Update()
    {
        if (FastForward.isFastForwarded)
        {
            img.color = fastForwardActivatedColor;
        }
        else
        {
            img.color = fastForwardDeactivatedColor;
        }
    }

    public void Toggle()
    {
        FastForward.Toggle();
    }
}
