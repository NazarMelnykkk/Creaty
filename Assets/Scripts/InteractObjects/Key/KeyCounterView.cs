using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _keyCounterText;


    public void SetKeyCount(int currentKey, int maxKey)
    {
        _keyCounterText.text = $"{currentKey}/{maxKey}";
    }
}
