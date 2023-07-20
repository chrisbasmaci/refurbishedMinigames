using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
// using UnityEngine.UI;

// public enum Shape {Circle = 0, Triangle = 3, Square = 4}
public class ShapeFactory : MonoBehaviour
{
    public static TextMeshPro constructPrompt(float size, Card tile, GameObject tileFace){

        string first_prompt_text  = RandomFactory.getRandomColor().ToString();
        string second_prompt_text = ((ColorBundle)RandomFactory.getRandomShape()).ToString();

        string first_prompt_color  = RandomFactory.getRandomColor().ToString();
        string second_prompt_color  = RandomFactory.getRandomColor().ToString();

        // tile.addPrompt((ColorBundle)Enum.Parse(typeof(ColorBundle), first_prompt_text), 
        //     (ColorBundle)Enum.Parse(typeof(ColorBundle), first_prompt_color), 
        //     (ShapeBundle)Enum.Parse(typeof(ShapeBundle), second_prompt_text),
        //     (ColorBundle)Enum.Parse(typeof(ColorBundle), second_prompt_color));
        
        

        Debug.Log(first_prompt_text + second_prompt_text);

        string full_text = formatText(first_prompt_text,  first_prompt_color,  second_prompt_text,  second_prompt_color);
        Debug.Log(full_text);

        return createTextMesh("Prompt", tileFace, full_text, size);
        // createTextMesh("Prompt", tileFace, full_text, size);
        // textObject.transform.position = position;
    }
    public static TextMeshPro createTextMesh(string name, GameObject parent_tile, string text, float size)
    { 
        TextMeshPro textMesh = new GameObject(name).AddComponent<TextMeshPro>();
        textMesh.transform.SetParent(parent_tile.transform, false);
        textMesh.transform.position  += new Vector3(0f, 0f, 1);
        textMesh.text = text;

        TMP_FontAsset fontAsset = Resources.Load<TMP_FontAsset>("goodfont");
        textMesh.font = fontAsset;
        textMesh.fontSize = size;

        textMesh.enableVertexGradient = false;
        textMesh.color = Color.white;
        textMesh.alignment = TextAlignmentOptions.Center;
        
        textMesh.outlineColor = Color.black;
        textMesh.enableWordWrapping = false; 
        return textMesh;
    }   
    private static string formatText(string shape_text, string shape_color, string color_text, string color_color){
        string text = string.Format("{0}\n{1}",
            $"<color={shape_color}>{shape_text}</color>",
            $"<color={color_color}>{color_text}</color>"
        );
        return text;
    }   

}
