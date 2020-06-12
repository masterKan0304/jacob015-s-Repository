using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour {

    public static int[] PlayerHp = new int[5];
    public static int[] EnemyHp = new int[15];
    public int[] PlayerMonsterHp = new int[100];
    public int[] EnemyMonsterHp = new int[100];

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        PlayerMonsterHp[CardScripts.CardCode[i]] = CardScripts.MonsterHp[CardScripts.CardCode[i]];

        PlayerHp[0] = 80;
        DamageSystem damage;
        damage.MonsterPower[0] = 1;
        
        
    }


}
