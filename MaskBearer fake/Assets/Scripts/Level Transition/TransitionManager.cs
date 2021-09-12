using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Action = System.Action;

public class TransitionManager : ScriptableObject
{
    public static void LevelTransition(string newLevel, AfterTransitionsDirection afterTranstion, 
        string transitionDoorExitName, float movingTime)
    {
        Fader.instance.FadeIn();
        Fader.instance.FadedIn += Action => LevelTransitioning(newLevel, afterTranstion,
            transitionDoorExitName,
            movingTime);
    }

    public static void LevelTransitioning(string newLevel, AfterTransitionsDirection afterTranstion,
    string transitionDoorExitName, float movingTime)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(newLevel);
        async.completed += AsyncOperation => AfterTransition(afterTranstion, transitionDoorExitName,
            movingTime);
    }

    public static void AfterTransition(AfterTransitionsDirection afterTranstion
        , string transitionDoorExitName, float movingTime)
    {
        GameObject.Find(transitionDoorExitName).GetComponent<TransitionTrigger>()
    .canTransition = false;

        Vector3 oldPos = PlayerCharacter.instance.transform.position;

        PlayerCharacter.instance.transform.position =
            GameObject.Find(transitionDoorExitName).transform.position;
        PlayerCharacter.instance.GetComponentInChildren<CameraConfinerFinder>()
            .ResetBoundingShape();

        Vector3 newPos = PlayerCharacter.instance.transform.position;
        Vector3 difference = oldPos - newPos;

        Camera.main.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
        Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().enabled = false;
        Camera.main.transform.position = new Vector3
            (PlayerCharacter.instance.transform.position.x,
            PlayerCharacter.instance.transform.position.y,
            Camera.main.transform.position.z);
        Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().enabled = true;
        Camera.main.GetComponent<Cinemachine.CinemachineBrain>().enabled = true;

        PlayerCharacter.instance.GetComponent<PlayerMoving>().
            InputBlockAndGoingDirection(afterTranstion, movingTime);

        Fader.instance.FadeOut();
    }
}
public enum AfterTransitionsDirection
{
    GoRight, GoLeft
}