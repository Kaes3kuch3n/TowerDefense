using UnityEngine;

public class FastForward : MonoBehaviour {

    public float timeMultiplicator = 2f;

    public static float forwardSpeed;

    [HideInInspector]
    public static bool isFastForwarded;

    private void Start()
    {
        isFastForwarded = false;
        forwardSpeed = timeMultiplicator;
        Time.timeScale = 1f;
    }

    public static void Toggle()
    {
        if (isFastForwarded)
        {
            isFastForwarded = false;
            Time.timeScale = 1f;
        } else
        {
            isFastForwarded = true;
            Time.timeScale = forwardSpeed;
        }
    }
}
