using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBinder_BtnCliam : MonoBehaviour
{

    public enum eBtnState
    {
        None = -1,
        Active = 0,
        InActive,
        Success
    }
    public GameObject[] arrBtns;

    public void ChangeState(eBtnState state)
    {
        foreach(var btn in this.arrBtns)
        {
            btn.SetActive(false);
        }
        this.arrBtns[(int)state].SetActive(true);
    }


}
