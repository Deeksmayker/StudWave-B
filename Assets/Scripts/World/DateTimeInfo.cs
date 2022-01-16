using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeInfo : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;

    public bool IsWentToPairs;

    [SerializeField] private Text _minorDate;

    void Start()
    {
        _minorDate.text = GetDateTime();
    }

    #region EnumAndProperties

    public enum Months
    {
        Январь = 1,
        Февраль = 2,
        Март = 3,
        Апрель = 4,
        Май = 5,
        Июнь = 6,
        Июль = 7,
        Август = 8,
        Сентябрь = 9,
        Октябрь = 10,
        Ноябрь = 11,
        Декабрь = 12
    }

    private int year = 2020;

    public int Year
    {
        get => year;
    }

    private int month = 9;

    public int Month
    {
        get => month;
        set
        {
            if (value > 12)
            {
                value -= 12;
                year++;
            }

            if (value == 9)
                Course++;

            month = value;
            _minorDate.text = GetDateTime();
        }
    }

    private int week = 1;

    public int Week
    {
        get => week;
        set
        {
            if (value > 4)
            {
                value -= 4;
                Month++;
            }

            week = value;
            _minorDate.text = GetDateTime();
        }
    }

    private int hour = 8;

    public int Hour
    {
        get => hour;
        set
        {
            _player.Hunger -= (value - Hour) * 5;
            if (value >= 24)
            {
                value -= 24;
                Week++;
                if (IsWentToPairs)
                    _player.Study += 5;
                else
                    _player.Study -= 10;
            }

            if (hour < 8 && value >= 8)
                StateBus.DayCompleted += true;

            hour = value;
            _minorDate.text = GetDateTime();
        }
    }

    private float minuteF = 0;

    public int Minute
    {
        get => (int)MinuteF;
    }

    public float MinuteF
    {
        get => minuteF;
        set
        {
            if (value >= 60)
            {
                value -= 60;
                Hour++;
            }

            minuteF = value;
            _minorDate.text = GetDateTime();
        }
    }

    private int course = 1;

    public int Course
    {
        get => course;
        set => course = value < course ? throw new Exception("Курс стал меньше, как") : value;
    }

    #endregion

    public string GetDateTime()
    {
        var hourStr = Hour > 9 ? Hour.ToString() : "0" + Hour;
        var minuteStr = Minute > 9 ? Minute.ToString() : "0" + Minute;

        return String.Format($"{hourStr}:{minuteStr}\n\n{(Months)month}\n{week} неделя");
    }
}
