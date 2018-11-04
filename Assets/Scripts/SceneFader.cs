using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image img;
    public float fadeTime = 1;
    public AnimationCurve fadeCurve;
    
    public void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime / fadeTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0.141176f, 0.141176f, 0.141176f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / fadeTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0.141176f, 0.141176f, 0.141176f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / fadeTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0.141176f, 0.141176f, 0.141176f, a);
            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
