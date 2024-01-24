using UnityEngine;

using TMPro;
using System.Collections;

public class Character : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private int apple= 0;
    [SerializeField] private int life = 100;
    private bool recovery; //se estiver piscando nao pode tomar outro dano
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI lifeText;
    //Propiedades
    public int Apple { get => apple; set => apple = value; }
    public int Life { get => life; set => life = value; }
    public TextMeshProUGUI AppleText { get => appleText; set => appleText = value; }
    public TextMeshProUGUI LifeText { get => lifeText; set => lifeText = value; }
    [Header("Intance")]
    public static Character instance; //geramos um acessador estatico para o player

    public SpriteRenderer sprite; //referencia ao spriteRenderer
    public GameController gc;
    private void Awake()
    {
        //o trecho abaixo verifica se já existe um objeto do player na cena. Caso sim, destroi a copia.
        //caso nao, chama o dondestroyonload para o objeto ser mantido na cena
        //isso evitara duplicacoes do objeto do player
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        apple = 0;
        inicialise();
    }
    private void inicialise()
    {
        lifeText.text = life.ToString();
        Time.timeScale = 1;
    }
    private void dead()
    {
        if (life <= 0)
        {
            Time.timeScale = 0;
        }
    }
    public void Hit()
    {
        if (recovery == false)
        {
            StartCoroutine(Flick());
        }
    }
    //morrer
    void Death()
    {
        if (life <= 0)
        {
            gc.SwitchState(stateMachine.DEAD);
            //gameOver.SetActive(true); old Script
            Time.timeScale = 0;
        }
    }
    //faz piscar
    IEnumerator Flick()
    {
        recovery = true;
        life--;
        Death();
        lifeText.text = life.ToString();
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        recovery = false;
    }
    public void IncleaseScore()
    {
        apple++;
        appleText.text = apple.ToString();
    }
}
