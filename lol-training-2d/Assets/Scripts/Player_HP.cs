using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HP : MonoBehaviour
{
    public int hpMaxPlayer;
    public int hpAtualPlayer;
    public int manaMaxPlayer;
    public int manaAtualPlayer;

    [SerializeField] private Slider hp;
    [SerializeField] private Slider mana;

    AtivadorDeSkills atvSkills;
    // Start is called before the first frame update
    void Start()
    {
        atvSkills = FindObjectOfType<AtivadorDeSkills>();

        hpMaxPlayer = 100;
        manaMaxPlayer = 100;

        hpAtualPlayer = hpMaxPlayer;
        manaAtualPlayer = manaMaxPlayer;

        hp.maxValue = hpMaxPlayer;
        hp.value = hpAtualPlayer;

        mana.maxValue = manaMaxPlayer;
        mana.value = manaAtualPlayer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MachucarJogador(int danoParaReceber)
    {

        if (atvSkills.temEscudo == false)
        {
           hpAtualPlayer -= danoParaReceber;
           hp.value = hpAtualPlayer;

           if(hpAtualPlayer <= 0)
           {    
                this.gameObject.SetActive(false);
           }
        }
    }

    public void ConsumirMana(int manaParaRetirar)
    {
        manaAtualPlayer -= manaParaRetirar;
        mana.value = manaAtualPlayer;
    }
}
