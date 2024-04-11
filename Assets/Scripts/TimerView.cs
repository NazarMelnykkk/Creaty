using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private int _timeToChangeColorOnRed = 3;

    public void SetTime(float time)
    {

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        _timerText.text = string.Format("{0:00:{1:00}", minutes, seconds);

        if (time <= _timeToChangeColorOnRed)
        {
            _timerText.color = Color.red;
        }
    }
}
