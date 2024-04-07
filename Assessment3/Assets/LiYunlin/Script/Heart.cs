using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Heart
{
    public void TaskHit(float damage, RaycastHit hit);
}