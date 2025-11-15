using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HauntBar : MonoBehaviour
{
    public Image hauntBar;
    public float currHaunt = 0;
    public float maxHaunt = 0;


    private void Start()
    {
        hauntBar.fillAmount = 0;
    }

    public void UpdateHauntingBar()
    {
        currHaunt = Mathf.Clamp(currHaunt + 1, 0, maxHaunt);
        float fill = currHaunt / maxHaunt;
        StartCoroutine(SmoothFill(fill));
    }

    IEnumerator SmoothFill(float fill)
    {
        float duration = 0.3f;
        float elapsed = 0f;
        float start = hauntBar.fillAmount;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            hauntBar.fillAmount = Mathf.Lerp(start, fill, elapsed / duration);
            yield return null;
        }
    }
}
