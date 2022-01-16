using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudCouncil : MonoBehaviour
{
    public int Power { get; private set; } = 2;
    public int MembersCount { get; private set; } = 2;

    public void AddMembersCount(int i = 1)
    {
        Power += i;
        MembersCount += i;
    }

    public void AddPower(int i = 1)
    {
        Power += i;
    }
}
