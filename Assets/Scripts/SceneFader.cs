// MARIANO CODUTTI ALARCON
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private AnimationCurve fadeCurve;


    private void Start()
    {
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn()
    {
        float fadeTime = 1f;

        while (fadeTime > 0f)
        {
            fadeTime -= Time.deltaTime;
            float alphaValue = fadeCurve.Evaluate(fadeTime);
            fadeImage.color = new Color(0f, 0f, 0f, alphaValue);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string _sceneToTransitionTo)
    {
        float fadeTime = 0f;

        while (fadeTime < 1f)
        {
            fadeTime += Time.deltaTime;
            float alphaValue = fadeCurve.Evaluate(fadeTime);
            fadeImage.color = new Color(0f, 0f, 0f, alphaValue);
            yield return 0;
        }

        SceneManager.LoadScene(_sceneToTransitionTo);
    }

    public void FadeTo(string _scene)
    {
        StartCoroutine(FadeOut(_scene));
    }
}
