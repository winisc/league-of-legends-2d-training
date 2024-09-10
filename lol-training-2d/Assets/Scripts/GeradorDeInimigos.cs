using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    [SerializeField] private float timerMinionsMage;
    [SerializeField] private float timerMinionsGue;
    public float timer;

    [SerializeField] private GameObject minionsGue;
    [SerializeField] private GameObject minionsMage;
    [SerializeField] private Transform[] gerador;

    public bool onda1;
    public bool onda2;

    public bool onda3;

    // Start is called before the first frame update
    void Start()
    {
        timerMinionsMage = 0;
        timerMinionsGue = 0;
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerMinionsGue += Time.deltaTime;
        timerMinionsMage += Time.deltaTime;

        if(timer <= 0)
        {
            timer = 0;
        }

        if(timer > 0)
        {
            if(timer <= 60 && timer >= 40)
            {
                onda1 = true;
                onda2 = false;
                onda3 = false;

                if(timerMinionsGue >= 5)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsGue, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsGue = 0;
                }

                if(timerMinionsMage >= 4)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsMage, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsMage = 0;
                }
            }
            else if(timer <= 40 && timer >= 20)
            {
                onda1 = false;
                onda2 = true;
                onda3 = false;
                
                if(timerMinionsGue >= 4)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsGue, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsGue = 0;
                }

                if(timerMinionsMage >= 3)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsMage, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsMage = 0;
                }
            }
            else if(timer <= 20 && timer >= 5)
            {
                onda1 = false;
                onda2 = false;
                onda3 = true;
                
                if(timerMinionsGue >= 3)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsGue, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsGue = 0;
                }

                if(timerMinionsMage >= 2)
                {
                    int random = Random.Range(0, gerador.Length);
                    Instantiate(minionsMage, gerador[random].position, Quaternion.Euler(0f, 0f, 0f));
                    timerMinionsMage = 0;
                }
            }
        }
    }
}
