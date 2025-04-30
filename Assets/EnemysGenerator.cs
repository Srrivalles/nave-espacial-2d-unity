using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class EnemysGenerator : MonoBehaviour
{
    float minTime = .5f;
    float maxTime = 1;
    public GameObject[] enemies;

    IEnumerator Start()
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0);
        float screnWidth = Camera.main.ScreenToWorldPoint(screenSize).x;

        while (true)
        {

            float time = UnityEngine.Random.Range(minTime, maxTime);
            int index = UnityEngine.Random.Range(0, enemies.Length); // Corrected the upper bound
            float x = UnityEngine.Random.Range(-screnWidth, screnWidth);

            yield return new WaitForSeconds(time);

            Vector3 position = transform.position;
            Quaternion rotation = Quaternion.identity;
            position.x = x;

            GameObject enemy = Instantiate(enemies[index], position, rotation);
            Destroy(enemy, 5);

        }
    }
}