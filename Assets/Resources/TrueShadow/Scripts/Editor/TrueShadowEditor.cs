using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;

namespace LeTai.TrueShadow.Editor
{
[CanEditMultipleObjects]
[CustomEditor(typeof(TrueShadow))]
public class TrueShadowEditor : UnityEditor.Editor
{
    EditorProperty insetProp;
    EditorProperty sizeProp;
    EditorProperty spreadProp;
    EditorProperty useGlobalAngleProp;
    EditorProperty angleProp;
    EditorProperty distanceProp;
    EditorProperty colorProp;
    EditorProperty blendModeProp;
    EditorProperty multiplyCasterAlphaProp;
    EditorProperty ignoreCasterColorProp;
    EditorProperty colorBleedModeProp;
    EditorProperty disableFitCompensationProp;

#if LETAI_TRUESHADOW_DEBUG
    SerializedProperty alwayRenderProp;
#endif

    GUIContent procrastinateLabel;
    GUIContent editGlobalAngleLabel;

    static bool showExperimental;
    static bool showAdvanced;

    void OnEnable()
    {
        insetProp                  = new EditorProperty(serializedObject, nameof(TrueShadow.Inset));
        sizeProp                   = new EditorProperty(serializedObject, nameof(TrueShadow.Size));
        spreadProp                 = new EditorProperty(serializedObject, nameof(TrueShadow.Spread));
        useGlobalAngleProp         = new EditorProperty(serializedObject, nameof(TrueShadow.UseGlobalAngle));
        angleProp                  = new EditorProperty(serializedObject, nameof(TrueShadow.OffsetAngle));
        distanceProp               = new EditorProperty(serializedObject, nameof(TrueShadow.OffsetDistance));
        colorProp                  = new EditorProperty(serializedObject, nameof(TrueShadow.Color));
        blendModeProp              = new EditorProperty(serializedObject, nameof(TrueShadow.BlendMode));
        multiplyCasterAlphaProp    = new EditorProperty(serializedObject, nameof(TrueShadow.UseCasterAlpha));
        ignoreCasterColorProp      = new EditorProperty(serializedObject, nameof(TrueShadow.IgnoreCasterColor));
        colorBleedModeProp         = new EditorProperty(serializedObject, nameof(TrueShadow.ColorBleedMode));
        disableFitCompensationProp = new EditorProperty(serializedObject, nameof(TrueShadow.DisableFitCompensation));

#if LETAI_TRUESHADOW_DEBUG
        alwayRenderProp = serializedObject.FindProperty(nameof(TrueShadow.alwaysRender));
#endif

        if (EditorPrefs.GetBool("LeTai_TrueShadow_" + nameof(showExperimental)))
        {
            showExperimental = EditorPrefs.GetBool("LeTai_TrueShadow_" + nameof(showExperimental), false);
            showAdvanced     = EditorPrefs.GetBool("LeTai_TrueShadow_" + nameof(showAdvanced),     false);
        }

        procrastinateLabel   = new GUIContent("Procrastinate", "A bug that is too fun to fix");
        editGlobalAngleLabel = new GUIContent("Edit...");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var ts = (TrueShadow)target;

        DrawPresetButtons(ts);

        Space();

        insetProp.Draw();
        sizeProp.Draw();
        spreadProp.Draw();
        useGlobalAngleProp.Draw(GUILayout.ExpandWidth(!ts.UseGlobalAngle));
        if (ts.UseGlobalAngle)
        {
            var settingRect = GUILayoutUtility.GetLastRect();
            settingRect.xMin  += EditorGUIUtility.labelWidth + EditorGUIUtility.singleLineHeight;
            settingRect.width =  GUI.skin.button.CalcSize(editGlobalAngleLabel).x;
            if (GUI.Button(settingRect, editGlobalAngleLabel))
            {
                SettingsService.OpenProjectSettings("Project/True Shadow");
            }
        }
        else
        {
            angleProp.Draw();
        }

        distanceProp.Draw();
        colorProp.Draw();
        if (ts.UsingRendererMaterialProvider)
        {
            using (new EditorGUI.DisabledScope(true))
                LabelField(blendModeProp.serializedProperty.displayName, "Custom Material");
        }
        else
        {
            blendModeProp.Draw();
        }

        DrawAdvancedSettings();

        serializedObject.ApplyModifiedProperties();
    }

    void DrawPresetButtons(TrueShadow ts)
    {
        if (!ProjectSettings.Instance.ShowQuickPresetsButtons) return;

        using (new HorizontalScope())
        {
            var presets  = ProjectSettings.Instance.QuickPresets;
            var selected = GUILayout.Toolbar(-1, presets.Select(p => p.name).ToArray());
            if (selected != -1)
            {
                Undo.RecordObject(ts, "Apply Quick Preset on " + ts.name);
                presets[selected].Apply(ts);
                EditorApplication.QueuePlayerLoopUpdate();
            }

            if (GUILayout.Button("...", GUILayout.ExpandWidth(false)))
            {
                SettingsService.OpenProjectSettings("Project/True Shadow");
            }
        }
    }

    void DrawAdvancedSettings()
    {
        using (var change = new EditorGUI.ChangeCheckScope())
        {
            showAdvanced = Foldout(showAdvanced, "Advanced Settings", true);
            using (new EditorGUI.IndentLevelScope())
                if (showAdvanced)
                {
                    multiplyCasterAlphaProp.Draw();
                    ignoreCasterColorProp.Draw();
                    colorBleedModeProp.Draw();
                    disableFitCompensationProp.Draw();

                    if (KnobPropertyDrawer.procrastinationMode)
                    {
                        var rot = GUI.matrix;
                        GUI.matrix                             =  Matrix4x4.identity;
                        KnobPropertyDrawer.procrastinationMode ^= Toggle("Be Productive", false);
                        GUI.matrix                             =  rot;
                    }
                    else
                    {
                        KnobPropertyDrawer.procrastinationMode |= Toggle(procrastinateLabel, false);
                    }

#if LETAI_TRUESHADOW_DEBUG
                    PropertyField(alwayRenderProp);
#endif
                }

            if (change.changed)
            {
                EditorPrefs.SetBool("LeTai_TrueShadow_" + nameof(showExperimental), showExperimental);
                EditorPrefs.SetBool("LeTai_TrueShadow_" + nameof(showAdvanced),     showAdvanced);
            }
        }
    }
}
}
