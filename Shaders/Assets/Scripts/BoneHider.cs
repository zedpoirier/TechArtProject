using UnityEditor;
using UnityEngine.Animations.Rigging;
using UnityEditor.SceneManagement;

public class BoneHider : ScriptableWizard
{
    [MenuItem("Animation Rigging/Toggle Bones ON")]
    public static void ToggleBonesON()
    {
        BoneRenderer[] bones = StageUtility.GetCurrentStageHandle().FindComponentsOfType<BoneRenderer>();
        foreach (var bone in bones)
        {
            bone.enabled = true;
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
    
    [MenuItem("Animation Rigging/Toggle Bones OFF")]
    public static void ToggleBonesOFF()
    {
        BoneRenderer[] bones = StageUtility.GetCurrentStageHandle().FindComponentsOfType<BoneRenderer>();
        foreach (var bone in bones)
        {
            bone.enabled = false;
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    [MenuItem("Animation Rigging/Toggle Effectors ON")]
    public static void ToggleEffectorsON()
    {
        Rig[] rigs = StageUtility.GetCurrentStageHandle().FindComponentsOfType<Rig>();
        foreach (var rig in rigs)
        {
            var enumerator = rig.effectors.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.visible = true;
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
    
    [MenuItem("Animation Rigging/Toggle Effectors OFF")]
    public static void ToggleEffectorsOFF()
    {
        Rig[] rigs = StageUtility.GetCurrentStageHandle().FindComponentsOfType<Rig>();
        foreach (var rig in rigs)
        {
            var enumerator = rig.effectors.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.visible = false;
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
