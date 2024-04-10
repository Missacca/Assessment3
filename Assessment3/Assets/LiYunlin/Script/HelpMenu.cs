using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject HelpPanel;
    public GameObject MenuPanel;
     public GameObject DeadPanel;
     public GameObject HelpPanel1;
    public void setHelp()
    {
         HelpPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
     public void setMenu()
    {
         HelpPanel.SetActive(false);
         MenuPanel.SetActive(true);
    }
    public void Dead_Help()
    {
        HelpPanel1.SetActive(true);
        DeadPanel.SetActive(false);
    }
    public void Help_Dead()
    {
        HelpPanel1.SetActive(false);
        DeadPanel.SetActive(true);
    }
}
