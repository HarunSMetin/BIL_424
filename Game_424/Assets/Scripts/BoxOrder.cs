using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOrder : MonoBehaviour
{
    public GameObject[] cubes; // 4 cube'u bu dizi i�inde tutaca��z
    private float[] targetZPositions; // Hedeflenen Z pozisyonlar�n� tutaca��z
    private int currentCubeIndex = 0; // S�radaki cube'u takip edece�imiz indeks

    void Start()
    {
        // cubes dizisine cube'lar� atayal�m (Unity Inspector'dan da yapabilirsiniz)
        cubes = new GameObject[4];
        cubes[0] = GameObject.Find("Cube1");
        cubes[1] = GameObject.Find("Cube2");
        cubes[2] = GameObject.Find("Cube3");
        cubes[3] = GameObject.Find("Cube4");

        // Hedeflenen Z pozisyonlar�n� olu�tural�m
        targetZPositions = new float[cubes.Length];
        for (int i = 0; i < cubes.Length; i++)
        {
            targetZPositions[i] = (i + 1) * 1.0f;
        }
    }

    // Her frame'de kontrol edecek kodumuzu Update metodu i�inde yazaca��z
    void Update()
    {
        // E�er s�radaki cube'un Z pozisyonu, hedeflenen Z pozisyonuna yak�nsa, bir sonraki cube'a ge�elim
        if (Mathf.Approximately(cubes[currentCubeIndex].transform.position.z, targetZPositions[currentCubeIndex]))
        {
            currentCubeIndex++;

            // E�er t�m cube'lar hedeflenen pozisyonlara gelmi�se, "kapi acil" mesaj�n� yazd�ral�m
            if (currentCubeIndex >= cubes.Length)
            {
                Debug.Log("kapi acil");
                // �stedi�iniz ekstra i�lemleri burada yapabilirsiniz
            }
        }
    }
}
