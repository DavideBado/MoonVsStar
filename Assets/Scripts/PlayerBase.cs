using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int life = 3;

    public void Damage()
    {
        life--;       
    }
}
