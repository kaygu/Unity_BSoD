using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BSOD.ScriptableObjects.Enemies;

public class MouseSelect : MonoBehaviour
{
    [SerializeField] RectTransform m_selection;
    [SerializeField] EnemyRuntimeSet m_enemySet;
    [SerializeField] EnemyRuntimeSet m_enemyToDestroySet;

    private Vector2 m_boxStart;
    private Vector2 m_boxEnd;

    private Vector2 m_boxStartRealWorld;
    private Vector2 m_boxEndRealWorld;
    private Vector2 m_boxSizeRealWorld;

    private bool m_draggingMouse = false;
   
    void Start()
    {
        
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_boxStart = Input.mousePosition;
            m_draggingMouse = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            m_draggingMouse = false;
            m_boxEnd = Input.mousePosition;

            m_boxStartRealWorld = Camera.main.ScreenToWorldPoint(m_boxStart);
            m_boxEndRealWorld = Camera.main.ScreenToWorldPoint(m_boxEnd);
            m_boxSizeRealWorld = new Vector2(m_boxStartRealWorld.x - m_boxEndRealWorld.x, m_boxStartRealWorld.y - m_boxEndRealWorld.y);

            KillEnemies();


            // Reset square
            m_boxStart = Vector2.zero;
            m_boxEnd = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (m_draggingMouse)
        {
            m_selection.gameObject.SetActive(true);

            // Box Position
            Vector2 currentMousePos = Input.mousePosition;
            Vector2 boxMiddle = (m_boxStart + currentMousePos) / 2f;
            m_selection.position = boxMiddle;

            // Box Size
            m_selection.sizeDelta = new Vector2(Mathf.Abs(m_boxStart.x - currentMousePos.x), Mathf.Abs(m_boxStart.y - currentMousePos.y));
        }
        else
        {
            m_selection.gameObject.SetActive(false);
        }
    }

    private void KillEnemies()
    {
        Rect rect = new Rect(m_boxStartRealWorld, m_boxSizeRealWorld); // Doesnt work yet
        
        foreach(Transform enemy in m_enemySet.Items)
        {
            if (rect.Contains(enemy.position, true))
            {
                print("Its a mtch!");
                m_enemyToDestroySet.Add(enemy);
            }
            

        }
        print(m_enemyToDestroySet.Items.Count);
            
    }
}