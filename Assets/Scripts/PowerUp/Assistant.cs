using UnityEngine;
using System.Collections;

// Klasse für Assistant-PowerUps

public class Assistant : MonoBehaviour
{
    public int AddAssistantCount(int count)
    {
        ++count;

        return count;
    }
}