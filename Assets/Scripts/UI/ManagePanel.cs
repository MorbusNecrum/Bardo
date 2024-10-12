using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanel : MonoBehaviour
{
    //LOS PANELES DEBEN TENR UN PADRE VACIO ACTIVO CON EL panelParentName.
    public void OpenPanelByString(string panelParentName)
    {
        GameObject.Find(panelParentName).transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ClosePanelByString(string panelParentName)
    {
        GameObject.Find(panelParentName).transform.GetChild(0).gameObject.SetActive(false);
    }
}
