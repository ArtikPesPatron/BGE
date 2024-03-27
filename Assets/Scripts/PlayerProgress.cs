using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    private float _expTargetValue = 100;
    private float _expCurrentValue = 0;
    private int _levelValue = 3;

    public List<PlayerProgressLevel> levels;
    public RectTransform ExpTransform;
    public TextMeshProUGUI levelValueTMP;
    public void AddExperience(float exp)
    {
        _expCurrentValue += exp;
        if(_expCurrentValue >= _expTargetValue)
        {
            SetLevel(_levelValue + 1);
            _expCurrentValue = 0;
        }
        DrawUI();
    }

    private void DrawUI()
    {
        ExpTransform.anchorMax = new Vector2(_expCurrentValue / _expTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }
    private void Update()
    {
        DrawUI();
    }
    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLVL = levels[_levelValue - 1];
        _expTargetValue = currentLVL.expForNextLVL;
        GetComponent<FireballCaster>().damage = currentLVL.fireballDamage;
        
        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentLVL.grenadeDamage;

        if(currentLVL.grenadeDamage < 0)
        {
            grenadeCaster.enabled = false;
        }
        else
        {
            grenadeCaster.enabled = true;
        }
    }
}
