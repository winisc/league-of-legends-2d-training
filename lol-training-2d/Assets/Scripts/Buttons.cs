using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    Layout layout;

    [SerializeField] private GameObject iten1Hud;
    [SerializeField] private GameObject iten2Hud;
    [SerializeField] private GameObject iten3Hud;

    [SerializeField] private GameObject habiliadeQHud;
    [SerializeField] private GameObject habiliadeWHud;
    [SerializeField] private GameObject habiliadeEHud;
    [SerializeField] private GameObject habiliadeRHud;

    public bool habilidadeQDisponivel;
    public bool habilidadeWDisponivel;
    public bool habilidadeEDisponivel;
    public bool habilidadeRDisponivel;

    Player_Controller playerC;
    GameManager genMan;
    // Start is called before the first frame update
    void Start()
    {
       layout = FindObjectOfType<Layout>();
       genMan = FindObjectOfType<GameManager>();

       iten1Hud.SetActive(false);
       iten2Hud.SetActive(false);
       iten3Hud.SetActive(false);

       habiliadeQHud.SetActive(false);
       habiliadeWHud.SetActive(false);
       habiliadeEHud.SetActive(false);
       habiliadeRHud.SetActive(false);

       habilidadeQDisponivel = false;
       habilidadeWDisponivel = false;
       habilidadeEDisponivel = false;
       habilidadeRDisponivel = false;

       playerC = FindObjectOfType<Player_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Item1()
    {
        playerC.moveSpeed += 1;
        layout.aprimoramentoDeItens.SetActive(false);
        layout.aprimoramentoDeHabilidades.SetActive(true);
        iten1Hud.SetActive(true);
    }
    public void Item2()
    {
        genMan.danoFisico += 1;
        layout.aprimoramentoDeItens.SetActive(false);
        layout.aprimoramentoDeHabilidades.SetActive(true);
        iten2Hud.SetActive(true);
    }
    public void Item3()
    {
        genMan.danoMagico += 1;
        layout.aprimoramentoDeItens.SetActive(false);
        layout.aprimoramentoDeHabilidades.SetActive(true);
        iten3Hud.SetActive(true);
    }

    public void HabilidadeQ()
    {
        layout.timerDaOnda.SetActive(true);
        layout.aprimoramentoDeHabilidades.SetActive(false);
        habiliadeQHud.SetActive(true);
        habilidadeQDisponivel = true;
        Time.timeScale = 1;
    }
    public void HabilidadeW()
    {
        layout.timerDaOnda.SetActive(true);
        layout.aprimoramentoDeHabilidades.SetActive(false);
        habiliadeWHud.SetActive(true);
        habilidadeWDisponivel = true;
        Time.timeScale = 1;
    }
    public void HabilidadeE()
    {
        layout.timerDaOnda.SetActive(true);
        layout.aprimoramentoDeHabilidades.SetActive(false);
        habiliadeEHud.SetActive(true);
        habilidadeEDisponivel = true;
        Time.timeScale = 1;
    }

    public void HabilidadeR()
    {
        layout.timerDaOnda.SetActive(true);
        layout.aprimoramentoDeHabilidades.SetActive(false);
        habiliadeRHud.SetActive(true);
        habilidadeRDisponivel = true;
        Time.timeScale = 1;
    }
}
