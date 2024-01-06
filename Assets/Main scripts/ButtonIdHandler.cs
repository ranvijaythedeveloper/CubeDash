using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonIdHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject player;
    private Player Playerclass;
    public enum ButtonType
    {
        LeftControllerButton,
        RightControllerButton,
        NextLevelButton,
        RestartLevelButton,
        MainMenuButton
    }
    public ButtonType buttonType;
    private string id;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Playerclass = player.GetComponent<Player>();
    }
    private void parseButtonType()
    {
        if (buttonType == ButtonType.LeftControllerButton)
        {
            id = "left";
        }
        else if (buttonType == ButtonType.RightControllerButton)
        {
            id = "right";
        }
        else if (buttonType == ButtonType.NextLevelButton)
        {
            id = "next lvl";
        }
        else if (buttonType == ButtonType.RestartLevelButton)
        {
            id = "restart lvl";
        }
        else if (buttonType == ButtonType.MainMenuButton)
        {
            id = "main menu";
        }
    }
    private void Start()
    {
        parseButtonType();
    }
    public void OnPointerDown(PointerEventData data)
    {
        Playerclass.buttononclick(id);
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (id == "left" || id == "right")
        {
            Playerclass.buttononrelease();
        }
    }

}