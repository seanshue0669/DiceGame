using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(UISO.GUIComponent))]
public class GUIComponentEntryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        float lineHeight = EditorGUIUtility.singleLineHeight + 2;

        // Define the positions for each property field
        Rect typeRect = new Rect(position.x, position.y, position.width, lineHeight);
        Rect keyRect = new Rect(position.x, position.y + lineHeight, position.width, lineHeight);
        Rect componentRect = new Rect(position.x, position.y + 2 * lineHeight, position.width, lineHeight);

        // Find the properties
        SerializedProperty keyProp = property.FindPropertyRelative("Key");
        SerializedProperty typeProp = property.FindPropertyRelative("Type");
        SerializedProperty elementProp = property.FindPropertyRelative("Prefab");

        // Ensure all required properties are valid
        if (keyProp == null || typeProp == null)
        {
            EditorGUI.HelpBox(position, "Property fields are not initialized correctly!", MessageType.Error);
            return;
        }

        // Draw the fields for Type and Key
        EditorGUI.PropertyField(typeRect, typeProp, new GUIContent("Type"));
        EditorGUI.PropertyField(keyRect, keyProp, new GUIContent("Key"));

        // Get the selected type
        UISO.FullUIComponentType type = (UISO.FullUIComponentType)typeProp.enumValueIndex;

        // Draw the appropriate component field based on the selected type
        switch (type)
        {
            case UISO.FullUIComponentType.Button:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Button (Prefab)"));
                break;

            case UISO.FullUIComponentType.Image:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Image (Prefab)"));
                break;

            case UISO.FullUIComponentType.Text:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Text (Prefab)"));
                break;

            case UISO.FullUIComponentType.Slider:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Slider (Prefab)"));
                break;

            case UISO.FullUIComponentType.InputField:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("InputField (Prefab)"));
                break;

            case UISO.FullUIComponentType.Toggle:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Toggle (Prefab)"));
                break;

            case UISO.FullUIComponentType.Scrollbar:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Scrollbar (Prefab)"));
                break;

            case UISO.FullUIComponentType.ScrollView:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("ScrollView (Prefab)"));
                break;

            case UISO.FullUIComponentType.Dropdown:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Dropdown (Prefab)"));
                break;

            case UISO.FullUIComponentType.RawImage:
                 EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Raw Image (Prefab)"));
                break;

            case UISO.FullUIComponentType.Panel:
                EditorGUI.PropertyField(componentRect, elementProp, new GUIContent("Panel (Prefab)"));
                break;
            default:
                EditorGUI.HelpBox(componentRect, "Unsupported or Unknown Type!", MessageType.Warning);
                break;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Adjust height dynamically based on the number of fields
        return 3 * (EditorGUIUtility.singleLineHeight + 2);
    }
}
