
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PickableManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;
    [SerializeField]
    private ScoreManager scoreManager;

    private List<Pickable> pickableList = new List<Pickable>();
    void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        Pickable[] pickableObject = GameObject.FindObjectsOfType<Pickable>();
        for (int i = 0; i < pickableObject.Length; i++)
        {
            pickableList.Add(pickableObject[i]);
            pickableObject[i].OnPicked += OnPickablePicked;
        }
        Debug.Log("Pickable List: " + pickableList.Count);

        scoreManager.SetMaxScore(pickableList.Count);

    }

    private void OnPickablePicked(Pickable pickable)
    {
        pickableList.Remove(pickable);
        Debug.Log("Pickable List: " + pickableList.Count);

        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }

        if (pickable.type == PickableType.PowerUp)
        {
            player?.PickPowerUp();
        }
        if (pickableList.Count <= 0)
        {
            Debug.Log("All pickables collected!");
            SceneManager.LoadScene("WinScene");
        }
    }
}