using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{

    public GameController gameController;
    public void SetWinner()
    {
        gameController.SwitchState(stateMachine.WIN);
    }
    private void Update()
    {
        SetWinner();
    }
}
