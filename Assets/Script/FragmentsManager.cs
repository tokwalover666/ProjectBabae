using UnityEngine;

public class FragmentsManager : MonoBehaviour
{
    [SerializeField] int totalCoreObjects;
    [SerializeField] GameObject room1;
    [SerializeField] GameObject room2;
    int placedObjects;

    private void Start()
    {
        room1.SetActive(true);
        room2.SetActive(false);
    }
    public void ObjectPlacedCorrectly()
    {

        placedObjects++;
        Debug.Log(placedObjects);
        if (placedObjects >= totalCoreObjects)
        {
            PuzzleCompleted();
        }
    }

    void PuzzleCompleted()
    {
        Debug.Log("Room Completed!");


        //coroutine after photograph
        room1.SetActive(false);
        room2.SetActive(true);
    }
}
