using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBundle : MonoBehaviour
{
    AssetBundle assetBundle;
    [SerializeField] private GameManager gameManager;
    public string _name;
    public string path;
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Capsule;
    private void Start()
    {
        assetBundle = AssetBundle.LoadFromFile(path + "cube");
        Cube = (GameObject)assetBundle.LoadAsset("cube");
        assetBundle = AssetBundle.LoadFromFile(path + "sphere");
        Sphere = (GameObject)assetBundle.LoadAsset("sphere");
        assetBundle = AssetBundle.LoadFromFile(path + "capsule");
        Capsule = (GameObject)assetBundle.LoadAsset("capsule"); 
        ListAdd();
    }

    private void ListAdd()
    {
        gameManager.GeometryObjectModel.Add(Cube);
        gameManager.GeometryObjectModel.Add(Sphere);
        gameManager.GeometryObjectModel.Add(Capsule);
    }
    
}
