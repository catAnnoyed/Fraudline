using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ScenePreloader : MonoBehaviour
{
    private Dictionary<string, AsyncOperation> preloadOps = new Dictionary<string, AsyncOperation>();
    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void PreloadScene(string sceneName)
    {
        if (!preloadOps.ContainsKey(sceneName))
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            op.allowSceneActivation = false;  // preload without activating
            preloadOps[sceneName] = op;

            Debug.Log($"Started preloading scene: {sceneName}");
        }
        else
        {
            Debug.LogWarning($"Scene {sceneName} is already preloaded.");
        }
    }

    public void ActivateScene(string sceneName)
    {
        if (preloadOps.TryGetValue(sceneName, out AsyncOperation op))
        {
            StartCoroutine(ActivateAndUnload(sceneName, op));
        }
        else
        {
            Debug.LogWarning($"Scene {sceneName} has not been preloaded.");
        }
    }

    private System.Collections.IEnumerator ActivateAndUnload(string sceneName, AsyncOperation op)
    {
        // Allow the preloaded scene to activate
        op.allowSceneActivation = true;

        // Wait until the new scene is fully loaded
        while (!op.isDone)
        {
            yield return null;
        }

        // Unload the old scene
        AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(currentScene);

        while (!unloadOp.isDone)
        {
            yield return null;
        }

        currentScene = sceneName;

        Debug.Log($"Scene {sceneName} activated and previous scene unloaded.");
    }
}
//////////////////
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;
// using System.Collections.Generic;

// /// <summary>
// /// A centralized scene manager for asynchronously preloading, activating, and unloading scenes.
// /// This allows for smooth, lag-free scene transitions by loading multiple scenes at once.
// /// </summary>
// public class ScenePreloader : MonoBehaviour
// {
//     // A private list to hold the asynchronous loading operations for multiple scenes.
//     private List<AsyncOperation> asyncOperations = new List<AsyncOperation>();

//     // Optional: Reference to a UI Image for a loading bar.
//     [Tooltip("Reference to a UI component for displaying the loading progress.")]
//     public UnityEngine.UI.Image loadingBar;

//     /// <summary>
//     /// Gets a value indicating whether all scenes have been loaded and are ready for activation.
//     /// Use this to check if you can call ActivateLoadedScene().
//     /// </summary>
//     public bool AreScenesReadyToActivate
//     {
//         get
//         {
//             // If the list is empty, nothing has been loaded.
//             if (asyncOperations.Count == 0)
//             {
//                 return false;
//             }

//             // Check if all operations have reached the 0.9 progress state.
//             foreach (var op in asyncOperations)
//             {
//                 if (op.progress < 0.9f)
//                 {
//                     return false; // Found one that is not ready yet.
//                 }
//             }
//             return true; // All scenes are loaded.
//         }
//     }

//     /// <summary>
//     /// Starts the asynchronous loading of one or more scenes in the background.
//     /// This is the "preload" function.
//     /// </summary>
//     /// <param name="sceneNames">An array of scene names to start loading.</param>
//     public void c(params string[] sceneNames)
//     {
//         // Clear any previous operations to prepare for a new load.
//         asyncOperations.Clear();
//         // Start the loading process as a coroutine.
//         StartCoroutine(LoadMultipleAsync(sceneNames));
//     }

//     /// <summary>
//     /// Activates the preloaded scenes, making them visible and playable.
//     /// This should be called after LoadScenesAsync() has finished preloading (i.e., AreScenesReadyToActivate is true).
//     /// </summary>
//     public void ActivateLoadedScenes()
//     {
//         if (AreScenesReadyToActivate)
//         {
//             // Iterate through all operations and allow activation.
//             foreach (var op in asyncOperations)
//             {
//                 op.allowSceneActivation = true;
//             }
//         }
//         else
//         {
//             Debug.LogWarning("Not all scenes are fully loaded yet! Cannot activate.");
//         }
//     }

//     /// <summary>
//     /// Unloads a scene from memory. This is useful for cleaning up after a scene change.
//     /// </summary>
//     /// <param name="sceneName">The name of the scene to unload.</param>
//     public void UnloadScene(string sceneName)
//     {
//         SceneManager.UnloadSceneAsync(sceneName);
//     }

//     /// <summary>
//     /// The coroutine that handles the actual asynchronous loading process for multiple scenes.
//     /// </summary>
//     /// <param name="sceneNames">An array of scene names to load.</param>
//     private IEnumerator LoadMultipleAsync(string[] sceneNames)
//     {
//         // Loop through each scene name provided.
//         foreach (string sceneName in sceneNames)
//         {
//             // Additive mode loads the scene alongside the current one.
//             AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

//             // Crucial: Prevent the scene from activating automatically.
//             op.allowSceneActivation = false;

//             // Add the operation to our list for later tracking.
//             asyncOperations.Add(op);
//         }

//         // Wait until all operations are finished loading (progress >= 0.9f).
//         while (!AreScenesReadyToActivate)
//         {
//             float totalProgress = 0f;

//             // Sum the progress of all loading operations.
//             foreach (var op in asyncOperations)
//             {
//                 totalProgress += op.progress;
//             }

//             // Calculate the average progress and normalize it.
//             float averageProgress = Mathf.Clamp01(totalProgress / (asyncOperations.Count * 0.9f));

//             // Update the loading bar if a reference exists.
//             if (loadingBar != null)
//             {
//                 loadingBar.fillAmount = averageProgress;
//             }

//             // Yield control back to the game loop.
//             yield return null;
//         }

//         // All scenes are loaded. Now we wait for ActivateLoadedScenes() to be called.
//     }
// }
