using UnityEngine;

using TMPro;
public class Character : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private int apple= 0;
    [SerializeField] private int life = 100;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI lifeText;
    public int Apple { get => apple; set => apple = value; }
    public int Life { get => life; set => life = value; }
    public TextMeshProUGUI AppleText { get => appleText; set => appleText = value; }
    public TextMeshProUGUI LifeText { get => lifeText; set => lifeText = value; }
    public static Character instance; //geramos um acessador estatico para o player



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
    public void IncleaseScore()
    {
        apple++;
        appleText.text = apple.ToString();
    }
}
