using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject upgradeEffect;
    public GameObject sellEffect;

    public bool showRadiusVisualizer;
    public GameObject radiusVisualizer;
    public Vector3 radiusVisualizerOffset = new Vector3(0f, 0.01f, 0f);

    private TurretBlueprint turretToBuild;
    private GameObject turretPreview;
    private Node selectedNode;

    public NodeUI nodeUI;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.price; } }

    public void ShowTurretPreview(Node node)
    {
        node.turretPreview = (GameObject)Instantiate(turretToBuild.previewPrefab, node.GetBuildPosition(), Quaternion.identity);
        if (showRadiusVisualizer)
            ShowRadiusVisualizer(node.turretPreview.transform.position, turretToBuild.prefab.GetComponent<Turret>().range);
    }
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
        ShowRadiusVisualizer(node.turret.transform.position, node.turret.GetComponent<Turret>().range);
    }

    public void DeselectNode()
    {
        HideRadiusVisualizer();
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    void ShowRadiusVisualizer(Vector3 position, float radius)
    {
        radiusVisualizer.transform.position = position + radiusVisualizerOffset;
        radiusVisualizer.transform.localScale = new Vector3(radius, radius, 0f);
        radiusVisualizer.SetActive(true);
    }

    public void HideRadiusVisualizer()
    {
        radiusVisualizer.SetActive(false);
    }
}
