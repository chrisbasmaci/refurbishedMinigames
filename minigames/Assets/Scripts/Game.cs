using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.U2D.Animation;

public enum ColorBundle{red=0, blue, yellow, green, purple, orange}
public enum ShapeBundle{circle=0, triangle, square, diamond, rectangle}

public static class ColorHex
{
    public static Dictionary<int, (string colorName, string colorHex)> colorMap = new Dictionary<int, (string, string)>()
    {
        { 0, ("red", "#D7263D") },
        { 1, ("blue", "#51D6FF") },
        { 2, ("yellow", "#FFE381") },
        { 3, ("green", "#14CC60") },
    };
    public static readonly int color_total = colorMap.Count;
}
public class Game : MonoBehaviour
{
    public static string arr;

    private static Game instance;
    //set in unity
    [SerializeField] public int defaultTileAmount = 4;
    [SerializeField] public Sprite cardBack;
    [SerializeField] public Sprite cardFace;
    [SerializeField] public Sprite[] cardOrderSheet;

    [SerializeField] public GameObject cardBackPrefab;
    [SerializeField] public AnimationClip orderRevealAnimation;
    [SerializeField] public AnimatorController curtainController;

    [SerializeField] public Sprite[] shapeSheet;
    [SerializeField] public Sprite[] shapeTextSheet;
    [SerializeField] public Sprite[] colorTextSheet;
    // Public property to access the singleton instance
    public static Game Instance
    {
        get
        {
            // If the instance is null, try to find an existing instance in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
                
                // If no instance exists in the scene, create a new GameObject and attach the singleton script to it
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(Game).Name);
                    instance = singletonObject.AddComponent<Game>();
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        // Ensure only one instance of the singleton exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Don't destroy the singleton object when loading new scenes
        DontDestroyOnLoad(gameObject);
    }

}


