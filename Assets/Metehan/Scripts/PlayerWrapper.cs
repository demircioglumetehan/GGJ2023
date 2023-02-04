using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour
{
    public static PlayerWrapper THIS;
    private void Awake()
    {
        THIS = this;
    }
}
