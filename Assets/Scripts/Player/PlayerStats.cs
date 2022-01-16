using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private Slider _studySlider;
    [SerializeField] private Text _moneyValue;

    void Start()
    {
        _hungerSlider.value = Hunger;
        _healthSlider.value = Health;
        _energySlider.value = Energy;
        _moodSlider.value = Mood;
        _studySlider.value = Study;
        _moneyValue.text = Money.ToString();
    }

    #region perks

    private int knowledgeXP;

    public int KnowledgeXP
    {
        get => knowledgeXP;
        set
        {
            //if (value / 5 > KnowledgeLevel)
                //InfoPanelScript.PerkIncreaseInfo("Энциклопедические знания", KnowledgeLevel + (value / 5));
            knowledgeXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int KnowledgeLevel
    {
        get => knowledgeXP / 5;
    }

    private int physicalXP;

    public int PhysicalXP
    {
        get => physicalXP;
        set
        {
            //if (value / 5 > PhysicalLevel)
               // InfoPanelScript.PerkIncreaseInfo("Физическая подготовка", PhysicalLevel + (value / 5));
            physicalXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int PhysicalLevel
    {
        get => physicalXP / 5;
    }

    private int charismaXP;

    public int CharismaXP
    {
        get => charismaXP;
        set
        {
            //if (value / 5 > CharismaLevel)
               // InfoPanelScript.PerkIncreaseInfo("Харизма", CharismaLevel + (value / 5));
            charismaXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int CharismaLevel
    {
        get => charismaXP / 5;
    }

    private int studWaveXP;

    public int StudWaveXP
    {
        get => studWaveXP;
        set
        {
           // if (value / 5 > StudWaveLevel)
                //InfoPanelScript.PerkIncreaseInfo("Студенческая волна", StudWaveLevel + (value / 5));
            studWaveXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int StudWaveLevel
    {
        get => studWaveXP / 5;
    }

    private int techXP;

    public int TechXP
    {
        get => techXP / 5;
        set
        {
            //if (value / 5 > TechLevel)
                //InfoPanelScript.PerkIncreaseInfo("Физическая подготовка", TechLevel + (value / 5));
            techXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int TechLevel
    {
        get => techXP / 5;
    }

    #endregion

    #region stats
    private int hunger = 50;
    public int Hunger
    {
        get => hunger;
        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
            _hungerSlider.value = hunger;
        }
    }

    private int energy = 50;
    public int Energy
    {
        get => energy;
        set
        {
            energy = Mathf.Clamp(value, 0, 100);
            _energySlider.value = energy;
        }
    }

    private int health = 50;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
            _healthSlider.value = health;
        }
    }

    private int study = 50;

    public int Study
    {
        get => study;
        set
        {
            study = Mathf.Clamp(value, 0, 100);
            _studySlider.value = study;
        }
    }

    private int mood = 50;

    public int Mood
    {
        get => mood;
        set
        {
            mood = Mathf.Clamp(value, 0, 100);
            _moodSlider.value = mood;
        }
    }

    private int money = 10000;

    public int Money
    {
        get => money;
        set
        {
            money = value;
            _moneyValue.text = money.ToString();
        }
    }

    #endregion
}
