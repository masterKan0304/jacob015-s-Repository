using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {

    public GameObject DeckText;
    public Text tx1;
    public GameObject[] CardImage = new GameObject[10];

    public int[] Decks = new int[100];
    public int[] BattleDecks = new int[100];
    public int[] Cards = new int[10];
    public Text[] Cardtxt = new Text[10];

    public Text Announce;

    public int CardPosition = 0;
    public int DeckDrowCount = 0;
    public int deckcards;
    public int Turn = 0;
    public bool PlayerTurn = true; //첫턴은 항상 플레이어의 우선 나중에 수정 가능
    float AATC; //경고문 알파 값 변경


    void Start ()
    {
        Color color = Announce.color;
        color.a = 0;
        Announce.color = color;
        AATC = 0;
        DeckSame();
        AnemyBattle anemyBattle = GameObject.Find("Systems").GetComponent<AnemyBattle>();
    }

    public void DeckOn()
    {
        DeckText.SetActive(true);
    }
    public void DeckOff()
    {
        DeckText.SetActive(false);
    }

    
    public void DeckSame()
    {
        for (int i = 0; i < Decks.Length; i++)
        {
            if (Decks[i] == 0)
            {
                deckcards = i;
                break;
            }
        }
        for (int i = 0; i < deckcards; i++)
        {
            BattleDecks[i] = Decks[i];
        }
    }
    public void CardDraw(int Count)
    {
        for (int l = 0; l < Count; l++)
        {
            for (int i = 0; i >= 0; i++)
            {
                int b = Random.Range(0, deckcards);
                if (BattleDecks[b] != 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Cards[j] == 0)
                        {
                            Cards[j] = BattleDecks[b];
                            BattleDecks[b] = 0;
                            Cardtxt[j].text = "" + Cards[j];
                            CardReload(b);
                            DeckDrowCount++;
                            HandCard();
                            deckcards--;
                            break;
                        }
                        else if (Cards[9] != 0)
                        {
                            BattleDecks[b] = 0;
                            Announce.text = "카드를 더 이상 뽑을 수 없어 카드가 소멸됩니다.";
                            StopCoroutine("AnnounceAppear");
                            StopCoroutine("AnnounceDisappear");
                            AATC = 0;
                            StartCoroutine("AnnounceAppear");
                            CardReload(b);
                            deckcards--;
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
    
    IEnumerator AnnounceAppear()
    {
        if (AATC < 1)
        {
            AATC += 0.02f;
            Color color = Announce.color;
            color.a = AATC;
            Announce.color = color;
            yield return new WaitForSeconds(0.02f);
            StartCoroutine("AnnounceAppear");
        }
        else
        {
            StartCoroutine("AnnounceDisappear");
        }
    }
    IEnumerator AnnounceDisappear()
    {
        if (AATC > 0)
        {
            AATC -= 0.02f;
            Color color = Announce.color;
            color.a = AATC;
            Announce.color = color;
            yield return new WaitForSeconds(0.02f);
            StartCoroutine("AnnounceDisappear");
        }
        else
        {
            AATC = 0;
        }
    }

    public void CardReload(int Startnum)
    {
        for (int i = Startnum; i >= 0; i++)
        {
            if (BattleDecks[i] == 0 && BattleDecks[i+1] != 0)
            {
                BattleDecks[i] = BattleDecks[i+1];
                BattleDecks[i+1] = 0;
            }
            else if (BattleDecks[i] == 0 && BattleDecks[i+1] == 0)
            {
                break;
            }
        }
    }
    public void CardGain(int CardCode)
    {
        BattleDecks[deckcards] = CardCode;
        deckcards++;
    }

    void TurnOver()
    {
        PlayerTurn = false;
        AnemyBattle anemyBattle = GameObject.Find("Systems").GetComponent<AnemyBattle>();
        anemyBattle.EnemyTurn = true;
    }

    void HandCard()
    {

        if (DeckDrowCount == 1)
        {
            CardImage[0].SetActive(true);
            CardImage[0].transform.position = new Vector3(CardPosition, -254, 0);
        }
        else if (DeckDrowCount == 2)
        {
            CardImage[1].SetActive(true);
            CardImage[0].transform.position = new Vector3(CardPosition + 8, -254, 0);
            CardImage[1].transform.position = new Vector3(CardPosition - 8, -254, 0);
        }
        else if (DeckDrowCount == 3)
        {
            CardImage[2].SetActive(true);
            CardImage[0].transform.position = new Vector3(CardPosition + 14, -254, 0);
            CardImage[1].transform.position = new Vector3(CardPosition, -254, 0);
            CardImage[2].transform.position = new Vector3(CardPosition - 14, -254, 0);
        }
       
    
    }

    
    void Update()
    {
        if (PlayerTurn == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CardDraw(1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                CardGain(100);
            }

            if (BattleDecks[0] == 0)
            {
                tx1.text = "카드가 다 떨어졌습니다!!";
            }
            else
            {
                tx1.text = "덱에 카드가 " + deckcards + " 장 있습니다.";
            }
            //TurnOver();
        }
        else if (PlayerTurn == false)
        {
            //플레이어 턴이 아니더라도 카드에 대응 할 수 있게 만들것
        }
    }
}
