using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlow : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DateTimeInfo _dateTimeInfo;
    [SerializeField] private PlayerStats _playerStats;

    void Update()
    {
        Timer();
        CheckTimeSkip();
        CheckMoneySpend();
    }

    private void CheckTimeSkip()
    {
        if (StateBus.TimeSkip.Value == 0) return;

        _dateTimeInfo.Hour += StateBus.TimeSkip.Value;
        _playerStats.Energy += StateBus.TimeSkip.Value * 11;
    }

    private void CheckMoneySpend()
    {
        if (StateBus.MoneySpend.Value == 0) return;

        _playerStats.Money -= StateBus.MoneySpend.Value;
    }

    private void Timer()
    {
        if (!_rigidbody.IsSleeping())
        {
            _dateTimeInfo.MinuteF += Time.deltaTime;
        }
    }
}
