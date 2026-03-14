using System.Collections;
using UnityEngine;

public class FragmentsManager : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] photographs;

    [SerializeField] GameObject captureButton;

    [SerializeField] int totalCoreObjects;

    [SerializeField] GameObject whiteShutter;
    [SerializeField] float flashDuration = 0.25f;

    int currentRoomIndex = 0;
    int placedObjects = 0;

    bool roomComplete = false;

    void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(i == 0);
        }

        for (int i = 0; i < photographs.Length; i++)
        {
            photographs[i].SetActive(false);
        }

        captureButton.SetActive(false);
    }

    public void ObjectPlacedCorrectly()
    {
        placedObjects++;
        Debug.Log("num of placed obj:" + placedObjects);

        if (placedObjects >= totalCoreObjects)
        {
            PuzzleCompleted();
        }
    }

    void PuzzleCompleted()
    {
        roomComplete = true;
        captureButton.SetActive(true);
    }

    public void CapturePhotograph()
    {
        if (!roomComplete) return;

        captureButton.SetActive(false);

        StartCoroutine(CaptureSequence());
    }

    IEnumerator CaptureSequence()
    {
        whiteShutter.SetActive(true);

        yield return new WaitForSeconds(flashDuration);

        whiteShutter.SetActive(false);

        photographs[currentRoomIndex].SetActive(true);
    }

    public void ClickPhotograph()
    {
        photographs[currentRoomIndex].SetActive(false);

        GoToNextRoom();
    }

    void GoToNextRoom()
    {
        rooms[currentRoomIndex].SetActive(false);

        currentRoomIndex++;

        if (currentRoomIndex < rooms.Length)
        {
            rooms[currentRoomIndex].SetActive(true);

            placedObjects = 0;
            roomComplete = false;
        }
        else
        {
            Debug.Log("All rooms completed!");
        }
    }
}