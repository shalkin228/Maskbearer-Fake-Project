using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonRemoveAfterDoingMenu : MonoBehaviour
{
    private Player player;

    private void OnEnable()
    {
        player = new Player();
        player.Enable();
        player.PlayerInput.Exit.performed += ctx => Application.Quit();
    }
    private void OnDisable()
    {
        player.Disable();
    }
}
