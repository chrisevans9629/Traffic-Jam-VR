using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private GenerateTower tower;
    void Start()
    {
        tower = GameObject.FindObjectOfType<GenerateTower>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plank"))
        {
            foreach (Transform o in tower.transform)
            {
                Destroy(o.gameObject);
            }

            tower.BuildTower();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



}
