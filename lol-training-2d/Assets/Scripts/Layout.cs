using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout : MonoBehaviour
{
    [SerializeField] private Text tempo;
    [SerializeField] private Text contadorDeAbates;
    [SerializeField] private int timerInt;

    public GameObject aprimoramentoDeItens;
    public GameObject aprimoramentoDeHabilidades;
    public GameObject timerDaOnda;
    public GameObject wonWin;

    [SerializeField] private Text valorAtckFis;
    [SerializeField] private Text valorAtckMag;
    [SerializeField] private Text valorVelAtck;
    [SerializeField] private Text valorVelMov;

    public Text timerQ;
    public Text timerW;
    public Text timerE;
    public Text timerR;

    MoveAutoAtck autoAtaque;
    AtivadorDeSkills atvS;
    MoveSkill mvSkill;
    Player_Controller playerC;
    GeradorDeInimigos ger;
    GameManager gMan;
    // Start is called before the first frame update
    void Start()
    {
        ger = FindObjectOfType<GeradorDeInimigos>();
        gMan = FindObjectOfType<GameManager>();
        autoAtaque = FindObjectOfType<MoveAutoAtck>();
        atvS = FindObjectOfType<AtivadorDeSkills>();
        mvSkill = FindObjectOfType<MoveSkill>();
        playerC = FindObjectOfType<Player_Controller>();

        Time.timeScale = 0;

        aprimoramentoDeItens.SetActive(true);
        aprimoramentoDeHabilidades.SetActive(false);
        timerDaOnda.SetActive(false);

        wonWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerInt = (int) (ger.timer % 60); 
        tempo.text = ("" + timerInt);

        contadorDeAbates.text = ("" + gMan.countAbates);

        valorAtckFis.text = ("" + gMan.danoFisico);
        valorAtckMag.text = ("" + gMan.danoMagico);
        valorVelAtck.text = ("" + (1/(atvS.velocidadeDeAtaque)));
        valorVelMov.text = ("" + playerC.moveSpeed);

        if(ger.timer <= 0)
        {
            wonWin.SetActive(true);
        }

        timerQ.text = ("" + ((int) atvS.timerToQ % 60));
        timerW.text = ("" + ((int) atvS.timerToW % 60));
        timerE.text = ("" + ((int) atvS.timerToE % 60));
        timerR.text = ("" + ((int) atvS.timerToR % 60));
    }
}
