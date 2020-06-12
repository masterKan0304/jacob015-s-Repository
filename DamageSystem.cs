using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int[] MonsterPower = new int[100];
    public int[] DamageType = new int[100]; //int형이 아니여도 됨 int형 쓰면 1:물리2:마법3:고정:4혼합
    //HpSystem,MonsterScripts와 상호작용 할것

    // Update is called once per frame
    void Update()
    {
        
    }
}
