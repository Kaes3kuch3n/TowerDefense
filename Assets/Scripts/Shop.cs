using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint[] turretBlueprints;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        foreach (TurretBlueprint tb in turretBlueprints)
        {
            tb.priceLabel.text = "$ " + tb.price.ToString();
        }
    }

    public void SelectTurret(string name)
    {
        for (int i = 0; i < turretBlueprints.Length; i++)
        {
            if (turretBlueprints[i].name.Equals(name))
            {
                buildManager.SelectTurretToBuild(turretBlueprints[i]);
            }
        }
    }

    //Shop Hotkeys
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && turretBlueprints.Length >= 1)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[0]);
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && turretBlueprints.Length >= 2)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[1]);
        } else if (Input.GetKeyDown(KeyCode.Alpha3) && turretBlueprints.Length >= 3)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[2]);
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && turretBlueprints.Length >= 4)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[3]);
        } else if (Input.GetKeyDown(KeyCode.Alpha5) && turretBlueprints.Length >= 5)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[4]);
        } else if (Input.GetKeyDown(KeyCode.Alpha6) && turretBlueprints.Length >= 6)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[5]);
        } else if (Input.GetKeyDown(KeyCode.Alpha7) && turretBlueprints.Length >= 7)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[6]);
        } else if (Input.GetKeyDown(KeyCode.Alpha8) && turretBlueprints.Length >= 8)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[7]);
        } else if (Input.GetKeyDown(KeyCode.Alpha9) && turretBlueprints.Length >= 9)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[8]);
        } else if (Input.GetKeyDown(KeyCode.Alpha0) && turretBlueprints.Length >= 0)
        {
            buildManager.SelectTurretToBuild(turretBlueprints[9]);
        }
    }
}
