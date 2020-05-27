using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMercenary : SelectButton
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        FindObjectOfType<LevelController>().DeleteMercenaryModeEnabled = true;
    }
}
