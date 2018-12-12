using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PersonnageEditor : EditorWindow
{

    public Personnage perso;
    private int viewIndex = 1;

    [MenuItem("Window/Personnage Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(PersonnageEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            perso = AssetDatabase.LoadAssetAtPath(objectPath, typeof(Personnage)) as Personnage;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Personnage Editor", EditorStyles.boldLabel);
        if (perso != null)
        {
            if (GUILayout.Button("Show Personnage"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = perso;
            }
        }
        if (GUILayout.Button("Open Personnage"))
        {
            OpenPersonnage();
        }
        if (GUILayout.Button("New Personnage"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = perso;
        }
        GUILayout.EndHorizontal();

        if (perso == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Create Personnage", GUILayout.ExpandWidth(false)))
            {
                CreateNewPersonnage();
            }
            if (GUILayout.Button("Open Existing Personnage", GUILayout.ExpandWidth(false)))
            {
                OpenPersonnage();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (perso != null)
        {
            GUILayout.Space(10);

            perso.name = EditorGUILayout.TextField("Nom", perso.name);
            perso.description = EditorGUILayout.TextField("Description", perso.description);
            perso.age = EditorGUILayout.IntField("Age", perso.age);
            perso.artwork = EditorGUILayout.ObjectField("Artwork", perso.artwork, typeof(Sprite), false) as Sprite;

            
            GUILayout.BeginHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex > 1)
                    viewIndex--;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex < perso.genome.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Gene", GUILayout.ExpandWidth(false)))
            {
                AddGene();
            }
            if (GUILayout.Button("Delete Gene", GUILayout.ExpandWidth(false)))
            {
                DeleteGene(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (perso.genome == null)
                Debug.Log("wtf");
            if (perso.genome.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Gene", viewIndex, GUILayout.ExpandWidth(false)), 1, perso.genome.Count);
                //Mathf.Clamp (viewIndex, 1, perso.genome.Count);
                EditorGUILayout.LabelField("of   " + perso.genome.Count.ToString() + "  genes", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();
               
                perso.genome[viewIndex - 1].bonusConstitution = EditorGUILayout.FloatField("Constitution", perso.genome[viewIndex - 1].bonusConstitution);
                perso.genome[viewIndex - 1].bonusAgilite = EditorGUILayout.FloatField("Agilité", perso.genome[viewIndex - 1].bonusAgilite);
                perso.genome[viewIndex - 1].bonusPerception = EditorGUILayout.FloatField("Perception", perso.genome[viewIndex - 1].bonusPerception);
                perso.genome[viewIndex - 1].bonusTir = EditorGUILayout.FloatField("Tir", perso.genome[viewIndex - 1].bonusTir);
                perso.genome[viewIndex - 1].bonusMelee = EditorGUILayout.FloatField("Melee", perso.genome[viewIndex - 1].bonusMelee);

            }
            else
            {
                GUILayout.Label("Le génome est vide");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(perso);
        }
    }

    void CreateNewPersonnage()
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        perso = CreatePersonnage.Create();
        if (perso)
        {
            perso.genome = new List<Gene>();
            string relPath = AssetDatabase.GetAssetPath(perso);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenPersonnage()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Personnage", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            perso = AssetDatabase.LoadAssetAtPath(relPath, typeof(Personnage)) as Personnage;
            if (perso.genome == null)
                perso.genome = new List<Gene>();
            if (perso)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddGene()
    {
        Gene newGene = CreateGene.Create();
        perso.AddGene(newGene);
        viewIndex = perso.genome.Count;
    }

    void DeleteGene(int index)
    {
        perso.genome.RemoveAt(index);
    }
}