using UnityEngine;

using BSOD.ScriptableObjects.Enemies;
using BSOD.ScriptableObjects.Event;
using BSOD.ScriptableObjects.GameState;

public class MouseSelect : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet m_enemySet;
    [SerializeField] private EnemyRuntimeSet m_enemyToDestroySet;
    [Space]
    [SerializeField] private RectTransform m_selection;
    [Space]
    [SerializeField] private FloatGameEvent m_selectedEvent;

    private Vector2 m_boxStart;
    private Vector2 m_boxEnd;

    private Vector2 m_boxStartRealWorld;
    private Vector2 m_boxEndRealWorld;
    private Vector2 m_boxSizeRealWorld;

    private bool m_draggingMouse = false;

    // Time Delay after Selection
    [SerializeField] private SelectionCooldown m_selectionCooldown;

    private float m_delay = 0f;



    private void Update()
    {
        if (m_delay >= 0)
        {
            m_delay -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_boxStart = Input.mousePosition;
                m_draggingMouse = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && m_draggingMouse)
            {
                m_draggingMouse = false;
                m_boxEnd = Input.mousePosition;

                m_boxStartRealWorld = Camera.main.ScreenToWorldPoint(m_boxStart);
                m_boxEndRealWorld = Camera.main.ScreenToWorldPoint(m_boxEnd);
                m_boxSizeRealWorld = new Vector2(Mathf.Abs(m_boxStartRealWorld.x - m_boxEndRealWorld.x), Mathf.Abs(m_boxStartRealWorld.y - m_boxEndRealWorld.y));

                EnemiesToKill();

                // Reset square
                m_boxStart = Vector2.zero;
                m_boxEnd = Vector2.zero;

                // Calc Delay
                m_delay = m_boxSizeRealWorld.x * m_boxSizeRealWorld.y * m_selectionCooldown.PerUnit;
                if (m_delay < m_selectionCooldown.Minimum) m_delay = m_selectionCooldown.Minimum;
                else if (m_delay > m_selectionCooldown.Maximum) m_delay = m_selectionCooldown.Maximum;

                // Raise Selected Event
                m_selectedEvent.Raise(m_delay);
            }
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

    private void EnemiesToKill()
    {
        Vector2 BoxBottomLeftCorner = new Vector2(m_boxStartRealWorld.x < m_boxEndRealWorld.x ? m_boxStartRealWorld.x : m_boxEndRealWorld.x, m_boxStartRealWorld.y < m_boxEndRealWorld.y ? m_boxStartRealWorld.y : m_boxEndRealWorld.y);
        Rect rect = new Rect(BoxBottomLeftCorner, m_boxSizeRealWorld);
        
        for (int i = m_enemySet.Items.Count -1; i >= 0; i--)
        {
            Transform enemy = m_enemySet.Items[i];
            if (rect.Contains(enemy.position))
            {
                m_enemyToDestroySet.Add(enemy);
            }
        }
    }
}
