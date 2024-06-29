using System.Collections;
using UnityEngine;

public class PauseTimer : MonoBehaviour
{
    [SerializeField] private QuotesConfig _config;

    private float _pauseDuration;

    public IEnumerator PauseCoroutine()
    {
        _pauseDuration = _config.PauseDuration;

        WaitForSeconds pause = new WaitForSeconds(_pauseDuration);

        yield return pause;
    }
}
