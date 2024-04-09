using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    public Transform[] enemies;
    public RectTransform playerIcon;
    public RectTransform[] enemyIcons;

    public Vector2 mapSize = new Vector2(200, 200);

    private void Update()
    {
        UpdatePlayerIconPosition();
        UpdateEnemyIconPositions();
    }

    private void UpdatePlayerIconPosition()
    {
        if (player != null && playerIcon != null)
        {
            Vector2 playerPos = WorldToMapPosition(player.position);
            playerIcon.anchoredPosition = playerPos;
        }
    }

    private void UpdateEnemyIconPositions()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && enemyIcons[i] != null)
            {
                Vector2 enemyPos = WorldToMapPosition(enemies[i].position);
                enemyIcons[i].anchoredPosition = enemyPos;
            }
        }
    }

    private Vector2 WorldToMapPosition(Vector3 worldPos)
    {
        Vector2 mapCenter = new Vector2(mapSize.x * 0.5f, mapSize.y * 0.5f);
        Vector2 worldCenter = new Vector2(player.position.x, player.position.z); // 假设地图中心点与玩家位置相同

        float scaleX = mapSize.x / 50; // 50是世界中的一个单位长度
        float scaleY = mapSize.y / 50;

        float x = (worldPos.x - worldCenter.x) * scaleX + mapCenter.x;
        float y = (worldPos.z - worldCenter.y) * scaleY + mapCenter.y;

        return new Vector2(x, y);
    }
}
