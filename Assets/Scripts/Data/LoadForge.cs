using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using System.Xml;
using Random = UnityEngine.Random;

public class LoadForge : MonoBehaviour
{
    public static LoadForge data;

    public List<Forge> forgeList;

    public bool isLoadDone;

    void Start()
    {
        data = this;

        forgeList = new List<Forge>();

        StartCoroutine(LoadCharacterData());
    }

    //Load item to datalist
    private IEnumerator LoadCharacterData()
    {
        isLoadDone = false;
        TextAsset xml = Resources.Load<TextAsset>("XmlData/Forge");
        yield return xml;
        if (xml == null)
        {
            Debug.Log("bug here");
        }
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = false;

        doc.LoadXml(xml.text);

        LoadListRawMaterial(doc.SelectNodes("dataroot/Forge"));
    }


    // Converts an XmlNodeList into item objects and add to datalist
    private void LoadListRawMaterial(XmlNodeList nodes)
    {
        foreach (XmlNode node in nodes)
            forgeList.Add(GetInfor(node));

        isLoadDone = true;
    }

    //	Set information for item
    private Forge GetInfor(XmlNode info)
    {
        Forge forge = new Forge();
        XmlNode node;
        forge.idItemCraft = info.SelectSingleNode("IDProduct").InnerText;

        node = info.SelectSingleNode("IDMaterial1");
        if (node == null)
            return forge;
        forge.idIngre1 = node.InnerText;
        forge.numIngre1 = int.Parse(info.SelectSingleNode("Number1").InnerText);
        forge.idIngres[0] = node.InnerText;
        forge.numbers[0] = int.Parse(info.SelectSingleNode("Number1").InnerText);

        node = info.SelectSingleNode("IDMaterial2");
        if (node == null)
            return forge;
        forge.idIngre2 = node.InnerText;
        forge.numIngre2 = int.Parse(info.SelectSingleNode("Number2").InnerText);
        forge.idIngres[1] = node.InnerText;
        forge.numbers[1] = int.Parse(info.SelectSingleNode("Number2").InnerText);

        node = info.SelectSingleNode("IDMaterial3");
        if (node == null)
            return forge;
        forge.idIngre3 = node.InnerText;
        forge.numIngre3 = int.Parse(info.SelectSingleNode("Number3").InnerText);
        forge.idIngres[2] = node.InnerText;
        forge.numbers[2] = int.Parse(info.SelectSingleNode("Number3").InnerText);

        node = info.SelectSingleNode("IDMaterial4");
        if (node == null)
            return forge;
        forge.idIngre4 = node.InnerText;
        forge.numIngre4 = int.Parse(info.SelectSingleNode("Number4").InnerText);
        forge.idIngres[3] = node.InnerText;
        forge.numbers[3] = int.Parse(info.SelectSingleNode("Number4").InnerText);

        return forge;
    }

    public Forge GetForge(string itemID)
    {
        return forgeList.Find(x => (x.idItemCraft.CompareTo(itemID) == 0));
    }

    public void UnlockForge(string itemID)
    {
        forgeList.Find(x => x.idItemCraft.CompareTo(itemID) == 0).isUnLock = true;
    }

    public void GetItemCanCraft(ref List<Forge> result, string codeItem)
    {
        result = forgeList.FindAll(x => x.idItemCraft.StartsWith(codeItem));
    }

    public void GetForgeCanLoad(ref List<Forge> forge, ShadowItem[] shadowItems)
    {
        List<Forge> resultForges = forgeList.FindAll(f => !f.isUnLock && GetNewForce(f, shadowItems));

        forge.Clear();
        int numberResearch = 3;

        if (resultForges.Count <= numberResearch)
            forge = resultForges;
        else
        {
            HashSet<Forge> newFroges = new HashSet<Forge>();
            for (int i = 0; i < numberResearch; i++)
                newFroges.Add(resultForges[Random.Range(0, resultForges.Count)]);
            
            forge = new List<Forge>(newFroges);
        }

        foreach (Forge f in forge)
        {
            f.isUnLock = true;
        }
    }

    private bool GetNewForce(Forge f, ShadowItem[] shadowItems)
    {
        for (int i = 0; i < f.idIngres.Length; i++)
            if (f.idIngres[i] != null)
            {
                bool foundItem = false;
                foreach (ShadowItem s in shadowItems)
                    if (s!=null&&f.idIngres[i].CompareTo(s.idItem) == 0)
                        if (f.numbers[i] <= s.number)
                            foundItem = true;

                if (!foundItem)
                    return false;
            }
        return true;
    }
}
