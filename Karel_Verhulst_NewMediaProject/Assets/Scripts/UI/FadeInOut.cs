using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    private float _lerpTime = 1;
    [SerializeField]
    private CanvasGroup _uiElement = null;

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(_uiElement, _uiElement.alpha, 1, _lerpTime));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(_uiElement, _uiElement.alpha, 0, _lerpTime));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        print("done");
    }
}
