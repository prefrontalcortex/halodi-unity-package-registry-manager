using System.Collections;
using System.Collections.Generic;
using Halodi.PackageRegistry;
using UnityEngine;

public class Automate : MonoBehaviour
{
    // Start is called before the first frame update
    [UnityEditor.MenuItem("pfc/Automate")]
    static void Aut()
    {
        var controller = new RegistryManagerController();
        var reg = new ScopedRegistry();

        reg.name = "needle-github"; 
        reg.url = "https://npm.pkg.github.com/@needle-tools";
        reg.scopes = new string[] { "com.needle" };

        UpdateCredential(controller, reg);

        // URL to generate tokens
        // https://github.com/settings/tokens

        // Felix' token - read:packages
        var githubToken = "da48fccfde6413ccd9ddfb7377a9a5df865eb7cc";

        reg.token = githubToken;
        
        controller.Save(reg);
    }

    private static void UpdateCredential(RegistryManagerController controller, ScopedRegistry registry)
    {
        if (controller.credentialManager.HasRegistry(registry.url))
        {
            NPMCredential cred = controller.credentialManager.GetCredential(registry.url);
            registry.auth = cred.alwaysAuth;
            registry.token = cred.token;
        }
    }
}
