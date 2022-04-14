using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Eggorko { 

public class Utils
    {
        public static Vector3 ScreenToWorldMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;   
            Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(mousePos);
            return new Vector3(screenToWorld.x, screenToWorld.y, 0f);
        }
        
        public static TextMeshPro CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 12, Color? color = null, TextAlignmentOptions textAlignment = TextAlignmentOptions.Center, int sortingOrder = 5000)
        {
            if (color == null)
                color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, sortingOrder, textAlignment);
        }
        
        private static TextMeshPro CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, int sortingOrder, TextAlignmentOptions textAlignment)
        {
            GameObject gameObject = new GameObject("Word_Text", typeof(TextMeshPro));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMeshPro textMesh = gameObject.GetComponent<TextMeshPro>();
            textMesh.alignment = textAlignment;
            textMesh.color = color;
            textMesh.fontSize = fontSize;
            textMesh.text = text;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }
    }
}