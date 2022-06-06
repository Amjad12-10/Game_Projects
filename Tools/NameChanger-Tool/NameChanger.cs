using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class NameChanger : MonoBehaviour
{

    public GameObject MainParent;

    [SerializeField] List<GameObject> NameChangeElements;
    [SerializeField] string Name;
    [SerializeField] string ChildrenName;
    [SerializeField] string Symbol;

    private void Start()
    {
      //  NameChange();
    }

    public void NameChange()
    {
        NameChangeElements = new List<GameObject>();
        if(MainParent != null)
        {
          if(MainParent.transform.childCount != 0)
          {
               foreach(Transform children in MainParent.transform)
               {
                    NameChangeElements.Add(children.gameObject);
                    if(Name == "")
                         MainParent.transform.name = "Dude...Assign => ParentName";
                    else
                         MainParent.transform.name = Name;
               }
               for(int i = 0; i < NameChangeElements.Count; i++)
               {
                    if(ChildrenName == "")
                    {
                         NameChangeElements[i].gameObject.name = Name +" - "+(i + 1);
                    }
                    else
                    {
                         NameChangeElements[i].gameObject.name = ChildrenName+" - "+(i + 1);
                    }
               }
          }
          else
          {
               MainParent.transform.name = Name;
               Debug.Log("Dude... You Can assign Childrens to the Selected Gameobject");
          }
        }
        else
        {
          Debug.Log("Dude...Assign => MainParent ");

        }
    }
    public void _ListChange()
    {
         if(NameChangeElements.Count != 0)
         {
              foreach(GameObject Objects in NameChangeElements)
              {
                   if(Name == "")
                    Objects.transform.name = "Dude...Assign => Name ";
                   else
                    Objects.transform.name = Name;
              }
         }
         else
         {          
               Debug.Log("Dude...Assign => Elemnts to the List Name ");
         }
    }

   
}
