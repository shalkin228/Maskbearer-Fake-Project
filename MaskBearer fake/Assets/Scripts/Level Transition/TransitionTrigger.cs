using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    [SerializeField] private string _transitionScene;
    [SerializeField] private float _movingTimeAfterTransition;
    [SerializeField] private string _transitionDoorExitName; // where will be spawnpoint for player after
    // transitioning
    [SerializeField] private AfterTransitionsDirection _afterTransitionsDirection;

    public bool canTransition = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCharacter>(out PlayerCharacter character) && canTransition)
        {
            TransitionManager.LevelTransition(_transitionScene, _afterTransitionsDirection, 
                _transitionDoorExitName, _movingTimeAfterTransition);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerCharacter>(out PlayerCharacter character))
        {
            canTransition = true;
        }
    }
}