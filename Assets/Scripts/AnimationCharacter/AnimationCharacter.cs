using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    [Header("AnimationState")]
    [SerializeField] private int runAnimation, idleAnimation,jumpAnim;
    [Header("Component")]
    private Animator animCharacter;
    private CharacterMoviment moviment;

    public int JumpAnim { get => jumpAnim; set => jumpAnim = value; }

    private void Start()
    {
        animCharacter = GetComponent<Animator>();
        moviment = GetComponent<CharacterMoviment>();
    }

   

    public void PlayAnimation()
    {
        int zero = 0;
        if (moviment.direction.x > zero && moviment.isGround)
        {
            SetAnimation(runAnimation);
            SetRotation(Vector2.zero);
        }
        else if (moviment.direction.x < zero && moviment.isGround)
        {
            SetAnimation(runAnimation);
            SetRotation(new Vector2(0, 180));
        }
        else if (moviment.direction.x == zero && moviment.isGround)
        {
            SetAnimation(idleAnimation);
        }
    }
    

    public void SetAnimation(int animationValue)
    {
        animCharacter.SetInteger("transition", animationValue);
    }

    private void SetRotation(Vector2 rotationVector)
    {
        transform.eulerAngles = rotationVector;
    }
}
