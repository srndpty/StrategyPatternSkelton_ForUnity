using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

    [SerializeField]
    private Feature1.Type feature1Type;
    private Feature1.IStrategy feature1;


    [SerializeField]
    private Feature2.Type feature2Type;
    private Feature2.IStrategy feature2;


    [SerializeField]
    private Feature3.Type feature3Type;
    private Feature3.IStrategy feature3;


    void Awake()
    {
        feature1 = Feature1.Strategies.types[(int)feature1Type];
        feature2 = Feature2.Strategies.types[(int)feature2Type];
        feature3 = Feature3.Strategies.types[(int)feature3Type];
    }

    // Use this for initialization
    IEnumerator Start ()
    {
        yield return feature2.A2();
        var a = feature3.A3();  
	}
	
	// Update is called once per frame
	void Update ()
    {
        feature1.A1();
	}
}
