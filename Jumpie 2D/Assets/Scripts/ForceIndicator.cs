using UnityEngine;
using UnityEngine.UI;

public class ForceIndicator : MonoBehaviour
{

    public Image forceIndicatorImg;
    [SerializeField] private CharacterController characterController;

    void Update()
    {

        forceIndicatorImg.fillAmount = characterController.jumpForce;
    }

    private void OnDisable()
    {
        forceIndicatorImg.fillAmount = 0;

    }
}
