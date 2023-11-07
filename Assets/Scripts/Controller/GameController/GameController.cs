using UnityEngine;

public enum stateMachine
{
    START,
    PAUSED,
    PLAY,
    WIN,
    DEAD,
    NULL
}

public class GameController : MonoBehaviour
{
    private stateMachine currentState = stateMachine.START;
    private stateMachine lastState = stateMachine.NULL;

    public CharacterMoviment moviment;
    public AnimationCharacter animationCharacter;
    public GameObject Winneer, gameOver, Paused, character;
   
  
    
    

    private void Update()
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        switch (currentState)
        {
            case stateMachine.START:
                StartStateLogic();
                break;

            case stateMachine.PAUSED:
                PausedStateLogic();
                break;

            case stateMachine.PLAY:
                PlayStateLogic();
                break;

            case stateMachine.WIN:
                WinStateLogic();
                break;

            case stateMachine.DEAD:
                DeadStateLogic();
                break;
        }
    }

    private void StartStateLogic()
    {
        
        // Configurações iniciais e transição para o estado PLAY.
        SwitchState(stateMachine.PLAY);
    }

    private void PausedStateLogic()
    {
       
        // Mostra o menu de pausa e manipula entradas básicas.
        BasicInputs();
        Paused.SetActive(true);
    }

    private void PlayStateLogic()
    {
       
        // Atualiza o movimento do personagem e outras ações do jogo.



        moviment.HandleMovement();
        moviment.HandleInput();
        animationCharacter.PlayAnimation();
        BasicInputs();
        gameOver.SetActive(false);
        Paused.SetActive(false);
        Winneer.SetActive(false);
        
    }

    private void WinStateLogic()
    {
      
        // Mostra uma tela de vitória e executa ações relacionadas à vitória.
        BasicInputs();
        
        // Outras ações relacionadas à vitória.
    }

    private void DeadStateLogic()
    {
        
        // Mostra uma tela de derrota e desativa o personagem.
        gameOver.SetActive(true);
        character.SetActive(false);
    }

    public void SwitchState(stateMachine nextState)
    {
        lastState = currentState;
        currentState = nextState;
    }

    public stateMachine GetCurrentState()
    {
        return currentState;
    }

    private void BasicInputs()
    {
        if (Input.GetKeyDown(KeyCode.Pause) && currentState == stateMachine.PLAY)
        {
            SwitchState(stateMachine.PAUSED);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Pause) && currentState == stateMachine.PAUSED)
        {
            SwitchState(stateMachine.PLAY);
            Time.timeScale = 1;
        }
    }
}
