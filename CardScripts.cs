using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScripts : MonoBehaviour
{
    public static int[] CardCode = new int[100]; //몬스터의 코드
    public static int[] MonsterHp = new int[100]; //몬스터의 체력 HpSystem
    public static int[] MonsterPower = new int[100]; //몬스터의 공격력
    private int MonsterDamageType; //몬스터의 대미지 타입 1:물리2:마법3:고정4:혼합
    
    //MonsterScripts와 HpSystem과 상호작용 할것
    void Start()
    {
        CardCode[0] = (int)Code.Example;//예시
        MonsterHp[CardCode[0]] = 100;
        MonsterPower[CardCode[0]] = 50;
        
    }

    void Update()
    {
        

    }
    enum Code
    {
        Example
    };
}
