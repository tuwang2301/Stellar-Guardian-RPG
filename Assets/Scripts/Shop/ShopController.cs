using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject[] planets;

    private GameObject selectedPlanet;

    [SerializeField]
    private Text value;

    private int coins;

    private void Start()
    {
        SelectPlanet(planets[0]);
    }

    public void OnClick(int index)
    {
        SelectPlanet(planets[index]);
    }

    public void Buy()
    {
        int coins = EconomyManager.Instance.currentGold;
        int index = GetIndex(selectedPlanet);
        int balance = coins - int.Parse(value.text);


        if (coins >= int.Parse(value.text))
        {
            // withdraw the game object value from total coins and update text value
            EconomyManager.Instance.currentGold = balance;

            PlayerPrefs.SetInt("selected", index);
            PlayerPrefs.SetInt("status " + index, 1);
        }

    }

    private void SelectPlanet(GameObject obj)
    {
        int index = GetIndex(obj);

        if (selectedPlanet)
        {
            GetChildGameObject(selectedPlanet, 1).SetActive(false);
            selectedPlanet = obj;
        }
        else
        {
            selectedPlanet = obj;
        }
        GetChildGameObject(obj, 1).SetActive(true);

        //change text value with the planet game object value
        value.text = GetChildGameObject(obj, 0).GetComponent<Text>().text;

    }


    // return a child game object from a game object
    private GameObject GetChildGameObject(GameObject obj, int child)
    {
        return obj.transform.GetChild(child).gameObject;
    }

    private void OnScreenLeave()
    {
        int index = GetIndex(selectedPlanet);
        PlayerPrefs.SetInt("selected", index);
        PlayerPrefs.SetInt("status " + index, 1);
    }

    // find the game object index and save
    private int GetIndex(GameObject obj)
    {
        int index = 0;

        while (obj != planets[index])
        {
            index++;
        }

        return index;
    }
}