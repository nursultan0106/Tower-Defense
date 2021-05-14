using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    private IEnumerator FadeIn()
    {
        float time = 1f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            float a = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }
    private IEnumerator FadeOut(string scene)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float a = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}