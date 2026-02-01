#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using GGJ2026.Data;

namespace GGJ2026.Editor
{
    [CustomEditor(typeof(MaskPart))]
    public class MaskPartEditor : UnityEditor.Editor
    {
        SerializedProperty partImageProp;

        void OnEnable()
        {
            partImageProp = serializedObject.FindProperty("partImage");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(10);

            Sprite sprite = partImageProp.objectReferenceValue as Sprite;
            if (sprite != null)
            {
                EditorGUILayout.LabelField("Preview", EditorStyles.boldLabel);

                Rect rect = GUILayoutUtility.GetRect(200, 200);
                rect.width = Mathf.Min(rect.width, 200);
                rect.height = 200;

                Texture2D texture = sprite.texture;
                Rect spriteRect = sprite.rect;
                Rect texCoords = new Rect(
                    spriteRect.x / texture.width,
                    spriteRect.y / texture.height,
                    spriteRect.width / texture.width,
                    spriteRect.height / texture.height
                );

                GUI.DrawTextureWithTexCoords(rect, texture, texCoords);
            }
            else
            {
                EditorGUILayout.HelpBox("No sprite assigned to Part Image.", MessageType.Info);
            }
        }

        public override bool HasPreviewGUI() => true;

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            Sprite sprite = partImageProp.objectReferenceValue as Sprite;
            if (sprite == null) return;

            Texture2D texture = sprite.texture;
            Rect spriteRect = sprite.rect;

            float aspectRatio = spriteRect.width / spriteRect.height;
            float previewWidth = r.width;
            float previewHeight = r.height;

            if (previewWidth / previewHeight > aspectRatio)
            {
                previewWidth = previewHeight * aspectRatio;
            }
            else
            {
                previewHeight = previewWidth / aspectRatio;
            }

            Rect previewRect = new Rect(
                r.x + (r.width - previewWidth) / 2,
                r.y + (r.height - previewHeight) / 2,
                previewWidth,
                previewHeight
            );

            Rect texCoords = new Rect(
                spriteRect.x / texture.width,
                spriteRect.y / texture.height,
                spriteRect.width / texture.width,
                spriteRect.height / texture.height
            );

            GUI.DrawTextureWithTexCoords(previewRect, texture, texCoords);
        }

        public override GUIContent GetPreviewTitle()
        {
            return new GUIContent("Mask Part Preview");
        }
    }
}
#endif
