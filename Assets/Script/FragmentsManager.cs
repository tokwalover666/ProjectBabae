using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FragmentsManager : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] fragments;
    [SerializeField] GameObject[] photographs;
    [SerializeField] GameObject[] roomCharacters; 


    [SerializeField] GameObject captureButton;

    [SerializeField] int totalCoreObjects;
    [SerializeField] AudioClip shutterSound;
    [SerializeField] Image whiteShutter;
    [SerializeField] float flashDuration = 1f;

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

        for (int i = 0; i < fragments.Length; i++)
        {
            fragments[i].SetActive(i == 0);
        }
        for (int i = 0; i < roomCharacters.Length; i++)
        {
            roomCharacters[i].SetActive(false);
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
        whiteShutter.gameObject.SetActive(true);

        Color c = whiteShutter.color;
        c.a = 1f;
        whiteShutter.color = c;

        AudioManager.Instance.PlaySFX(shutterSound);

        yield return new WaitForSeconds(0.08f);

        float fadeTime = 0.8f;
        float t = 0;
        bool photoShown = false;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            float progress = t / fadeTime;

            c.a = 1f - progress;
            whiteShutter.color = c;

            if (!photoShown && progress >= 0.05f)
            {
                photographs[currentRoomIndex].SetActive(true);
                photoShown = true;
            }

            yield return null;
        }

        c.a = 0f;
        whiteShutter.color = c;
    }

    public void ClickPhotograph()
    {
        photographs[currentRoomIndex].SetActive(false);

        if (currentRoomIndex >= rooms.Length - 1)
        {
            whiteShutter.gameObject.SetActive(true);

            Color c = whiteShutter.color;
            c.a = 1f;
            whiteShutter.color = c;

            float fadeTime = 0.8f;
            float t = 0;
            bool photoShown = false;
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            GoToNextRoom();
        }
    }

    void GoToNextRoom()
    {
        rooms[currentRoomIndex].SetActive(false);
        fragments[currentRoomIndex].SetActive(false);

        currentRoomIndex++;

        if (currentRoomIndex < rooms.Length)
        {
            rooms[currentRoomIndex].SetActive(true);
            fragments[currentRoomIndex].SetActive(true);

            placedObjects = 0;
            roomComplete = false;
        }
        else
        {
            Debug.Log("All rooms completed!");
        }
    }

    public void ShowPortraitForCurrentRoom(bool show)
    {
        if (currentRoomIndex < roomCharacters.Length)
            roomCharacters[currentRoomIndex].SetActive(show);
    }
}