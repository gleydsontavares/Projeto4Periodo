using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterPanelController : MonoBehaviour
{
    public GameObject comumAlexPanel;
    public GameObject especialAlexPanel;
    public GameObject abilityPanel;
    public Button BTN_alex;
    public Button BTN_especial_alex;
    public Button BTN_comum_alex;

    public GameObject comumMayaPanel;
    public GameObject especialMayaPanel;
    public Button BTN_maya;
    public Button BTN_especial_maya;
    public Button BTN_comum_maya;

    public GameObject comumOliverPanel;
    public GameObject especialOliverPanel;
    public Button BTN_oliver;
    public Button BTN_especial_oliver;
    public Button BTN_comum_oliver;

    private bool comumAlexActive = false;
    private bool especialAlexActive = false;

    private bool comumMayaActive = false;
    private bool especialMayaActive = false;

    private bool comumOliverActive = false;
    private bool especialOliverActive = false;

    private void Start()
    {
        // Desativa os painéis no início do jogo
        comumAlexPanel.SetActive(false);
        especialAlexPanel.SetActive(false);

        comumMayaPanel.SetActive(false);
        especialMayaPanel.SetActive(false);

        comumOliverPanel.SetActive(false);
        especialOliverPanel.SetActive(false);

        abilityPanel.SetActive(false);

        // Configura os eventos de clique
        BTN_alex.onClick.AddListener(ActivateComumAlexPanel);
        BTN_especial_alex.onClick.AddListener(ActivateEspecialAlexPanel);
        BTN_comum_alex.onClick.AddListener(ActivateComumAlexPanel);

        BTN_maya.onClick.AddListener(ActivateComumMayaPanel);
        BTN_especial_maya.onClick.AddListener(ActivateEspecialMayaPanel);
        BTN_comum_maya.onClick.AddListener(ActivateComumMayaPanel);

        BTN_oliver.onClick.AddListener(ActivateComumOliverPanel);
        BTN_especial_oliver.onClick.AddListener(ActivateEspecialOliverPanel);
        BTN_comum_oliver.onClick.AddListener(ActivateComumOliverPanel);
    }

    void Update()
    {
        // Verifique se o jogador pressionou a tecla ESC e desative os painéis se estiverem ativos
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (comumAlexActive)
            {
                comumAlexPanel.SetActive(false);
                comumAlexActive = false;
                abilityPanel.SetActive(true);
            }

            if (especialAlexActive)
            {
                especialAlexPanel.SetActive(false);
                especialAlexActive = false;
                abilityPanel.SetActive(true);
            }

            if (comumMayaActive)
            {
                comumMayaPanel.SetActive(false);
                comumMayaActive = false;
                abilityPanel.SetActive(true);
            }

            if (especialMayaActive)
            {
                especialMayaPanel.SetActive(false);
                especialMayaActive = false;
                abilityPanel.SetActive(true);
            }

            if (comumOliverActive)
            {
                comumOliverPanel.SetActive(false);
                comumOliverActive = false;
                abilityPanel.SetActive(true);
            }

            if (especialOliverActive)
            {
                especialOliverPanel.SetActive(false);
                especialOliverActive = false;
                abilityPanel.SetActive(true);
            }
        }

    }

    public void ActivateComumAlexPanel()
    {
        comumAlexPanel.SetActive(true);
        comumAlexActive = true;
        especialAlexPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }

    public void ActivateEspecialAlexPanel()
    {
        especialAlexPanel.SetActive(true);
        especialAlexActive = true;
        comumAlexPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }

    public void ActivateComumMayaPanel()
    {
        comumMayaPanel.SetActive(true);
        comumMayaActive = true;
        especialMayaPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }

    public void ActivateEspecialMayaPanel()
    {
        especialMayaPanel.SetActive(true);
        especialMayaActive = true;
        comumMayaPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }

    public void ActivateComumOliverPanel()
    {
        comumOliverPanel.SetActive(true);
        comumOliverActive = true;
        especialOliverPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }

    public void ActivateEspecialOliverPanel()
    {
        especialOliverPanel.SetActive(true);
        especialOliverActive = true;
        comumOliverPanel.SetActive(false);
        abilityPanel.SetActive(false);
    }
}