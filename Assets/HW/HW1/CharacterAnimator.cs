using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Transform lookTarget;
    Vector3 lastLookTargetPosition; 
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
    }
    void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (lookTarget != null)
        {
            Vector3 currentLookPosition = lookTarget.position;
            if (currentLookPosition != lastLookTargetPosition)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(currentLookPosition);
                lastLookTargetPosition = currentLookPosition;
            }
        }
    }
}
