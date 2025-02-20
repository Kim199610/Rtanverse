using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNPCController : BaseNPCController
{
    protected override void OnClickInBasicMassageButton()
    {
        base.OnClickInBasicMassageButton();
        basicMassage.SetActive(false);
    }
}
