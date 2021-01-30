﻿using System.Collections.Generic;
using UnityEngine;

// Handles the log items in an optimized way such that existing log items are
// recycled within the list instead of creating a new log item at each chance
namespace IngameDebugConsole
{
    public class DebugLogRecycledListView : MonoBehaviour
    {
        // Unique debug entries
        private List<DebugLogEntry> collapsedLogEntries;

        // Current indices of debug entries shown on screen
        private int currentTopIndex = -1, currentBottomIndex = -1;
        private float deltaHeightOfSelectedLogEntry;

        private int indexOfSelectedLogEntry = int.MaxValue;

        // Indices of debug entries to show in collapsedLogEntries
        private DebugLogIndexList indicesOfEntriesToShow;

        private bool isCollapseOn;

        private float _1OverLogItemHeight;

        // Log items used to visualize the debug entries at specified indices
        private readonly Dictionary<int, DebugLogItem> logItemsAtIndices = new Dictionary<int, DebugLogItem>();

        private DebugLogManager manager;
        private float positionOfSelectedLogEntry = float.MaxValue;
        private float viewportHeight;

        public float ItemHeight { get; private set; }

        public float SelectedItemHeight { get; private set; }

        private void Awake()
        {
            viewportHeight = viewportTransform.rect.height;
        }

        public void Initialize(DebugLogManager manager, List<DebugLogEntry> collapsedLogEntries,
            DebugLogIndexList indicesOfEntriesToShow, float logItemHeight)
        {
            this.manager = manager;
            this.collapsedLogEntries = collapsedLogEntries;
            this.indicesOfEntriesToShow = indicesOfEntriesToShow;
            this.ItemHeight = logItemHeight;
            _1OverLogItemHeight = 1f / logItemHeight;
        }

        public void SetCollapseMode(bool collapse)
        {
            isCollapseOn = collapse;
        }

        // A log item is clicked, highlight it
        public void OnLogItemClicked(DebugLogItem item)
        {
            if (indexOfSelectedLogEntry != item.Index)
            {
                DeselectSelectedLogItem();

                indexOfSelectedLogEntry = item.Index;
                positionOfSelectedLogEntry = item.Index * ItemHeight;
                SelectedItemHeight = item.CalculateExpandedHeight(item.ToString());
                deltaHeightOfSelectedLogEntry = SelectedItemHeight - ItemHeight;

                manager.SetSnapToBottom(false);
            }
            else
            {
                DeselectSelectedLogItem();
            }

            if (indexOfSelectedLogEntry >= currentTopIndex && indexOfSelectedLogEntry <= currentBottomIndex)
                ColorLogItem(logItemsAtIndices[indexOfSelectedLogEntry], indexOfSelectedLogEntry);

            CalculateContentHeight();

            HardResetItems();
            UpdateItemsInTheList(true);

            manager.ValidateScrollPosition();
        }

        // Deselect the currently selected log item
        public void DeselectSelectedLogItem()
        {
            var indexOfPreviouslySelectedLogEntry = indexOfSelectedLogEntry;
            indexOfSelectedLogEntry = int.MaxValue;

            positionOfSelectedLogEntry = float.MaxValue;
            SelectedItemHeight = deltaHeightOfSelectedLogEntry = 0f;

            if (indexOfPreviouslySelectedLogEntry >= currentTopIndex &&
                indexOfPreviouslySelectedLogEntry <= currentBottomIndex)
                ColorLogItem(logItemsAtIndices[indexOfPreviouslySelectedLogEntry], indexOfPreviouslySelectedLogEntry);
        }

        // Number of debug entries may be changed, update the list
        public void OnLogEntriesUpdated(bool updateAllVisibleItemContents)
        {
            CalculateContentHeight();
            viewportHeight = viewportTransform.rect.height;

            if (updateAllVisibleItemContents)
                HardResetItems();

            UpdateItemsInTheList(updateAllVisibleItemContents);
        }

        // A single collapsed log entry at specified index is updated, refresh its item if visible
        public void OnCollapsedLogEntryAtIndexUpdated(int index)
        {
            DebugLogItem logItem;
            if (logItemsAtIndices.TryGetValue(index, out logItem))
                logItem.ShowCount();
        }

        // Log window is resized, update the list
        public void OnViewportDimensionsChanged()
        {
            viewportHeight = viewportTransform.rect.height;
            UpdateItemsInTheList(false);
        }

        private void HardResetItems()
        {
            if (currentTopIndex != -1)
            {
                DestroyLogItemsBetweenIndices(currentTopIndex, currentBottomIndex);
                currentTopIndex = -1;
            }
        }

        private void CalculateContentHeight()
        {
            var newHeight = Mathf.Max(1f, indicesOfEntriesToShow.Count * ItemHeight + deltaHeightOfSelectedLogEntry);
            transformComponent.sizeDelta = new Vector2(0f, newHeight);
        }

        // Calculate the indices of log entries to show
        // and handle log items accordingly
        public void UpdateItemsInTheList(bool updateAllVisibleItemContents)
        {
            // If there is at least one log entry to show
            if (indicesOfEntriesToShow.Count > 0)
            {
                var contentPosTop = transformComponent.anchoredPosition.y - 1f;
                var contentPosBottom = contentPosTop + viewportHeight + 2f;

                if (positionOfSelectedLogEntry <= contentPosBottom)
                {
                    if (positionOfSelectedLogEntry <= contentPosTop)
                    {
                        contentPosTop -= deltaHeightOfSelectedLogEntry;
                        contentPosBottom -= deltaHeightOfSelectedLogEntry;

                        if (contentPosTop < positionOfSelectedLogEntry - 1f)
                            contentPosTop = positionOfSelectedLogEntry - 1f;

                        if (contentPosBottom < contentPosTop + 2f)
                            contentPosBottom = contentPosTop + 2f;
                    }
                    else
                    {
                        contentPosBottom -= deltaHeightOfSelectedLogEntry;
                        if (contentPosBottom < positionOfSelectedLogEntry + 1f)
                            contentPosBottom = positionOfSelectedLogEntry + 1f;
                    }
                }

                var newTopIndex = (int) (contentPosTop * _1OverLogItemHeight);
                var newBottomIndex = (int) (contentPosBottom * _1OverLogItemHeight);

                if (newTopIndex < 0)
                    newTopIndex = 0;

                if (newBottomIndex > indicesOfEntriesToShow.Count - 1)
                    newBottomIndex = indicesOfEntriesToShow.Count - 1;

                if (currentTopIndex == -1)
                {
                    // There are no log items visible on screen,
                    // just create the new log items
                    updateAllVisibleItemContents = true;

                    currentTopIndex = newTopIndex;
                    currentBottomIndex = newBottomIndex;

                    CreateLogItemsBetweenIndices(newTopIndex, newBottomIndex);
                }
                else
                {
                    // There are some log items visible on screen

                    if (newBottomIndex < currentTopIndex || newTopIndex > currentBottomIndex)
                    {
                        // If user scrolled a lot such that, none of the log items are now within
                        // the bounds of the scroll view, pool all the previous log items and create
                        // new log items for the new list of visible debug entries
                        updateAllVisibleItemContents = true;

                        DestroyLogItemsBetweenIndices(currentTopIndex, currentBottomIndex);
                        CreateLogItemsBetweenIndices(newTopIndex, newBottomIndex);
                    }
                    else
                    {
                        // User did not scroll a lot such that, there are still some log items within
                        // the bounds of the scroll view. Don't destroy them but update their content,
                        // if necessary
                        if (newTopIndex > currentTopIndex)
                            DestroyLogItemsBetweenIndices(currentTopIndex, newTopIndex - 1);

                        if (newBottomIndex < currentBottomIndex)
                            DestroyLogItemsBetweenIndices(newBottomIndex + 1, currentBottomIndex);

                        if (newTopIndex < currentTopIndex)
                        {
                            CreateLogItemsBetweenIndices(newTopIndex, currentTopIndex - 1);

                            // If it is not necessary to update all the log items,
                            // then just update the newly created log items. Otherwise,
                            // wait for the major update
                            if (!updateAllVisibleItemContents)
                                UpdateLogItemContentsBetweenIndices(newTopIndex, currentTopIndex - 1);
                        }

                        if (newBottomIndex > currentBottomIndex)
                        {
                            CreateLogItemsBetweenIndices(currentBottomIndex + 1, newBottomIndex);

                            // If it is not necessary to update all the log items,
                            // then just update the newly created log items. Otherwise,
                            // wait for the major update
                            if (!updateAllVisibleItemContents)
                                UpdateLogItemContentsBetweenIndices(currentBottomIndex + 1, newBottomIndex);
                        }
                    }

                    currentTopIndex = newTopIndex;
                    currentBottomIndex = newBottomIndex;
                }

                if (updateAllVisibleItemContents)
                    // Update all the log items
                    UpdateLogItemContentsBetweenIndices(currentTopIndex, currentBottomIndex);
            }
            else
            {
                HardResetItems();
            }
        }

        private void CreateLogItemsBetweenIndices(int topIndex, int bottomIndex)
        {
            for (var i = topIndex; i <= bottomIndex; i++)
                CreateLogItemAtIndex(i);
        }

        // Create (or unpool) a log item
        private void CreateLogItemAtIndex(int index)
        {
            var logItem = debugManager.PopLogItem();

            // Reposition the log item
            var anchoredPosition = new Vector2(1f, -index * ItemHeight);
            if (index > indexOfSelectedLogEntry)
                anchoredPosition.y -= deltaHeightOfSelectedLogEntry;

            logItem.Transform.anchoredPosition = anchoredPosition;

            // Color the log item
            ColorLogItem(logItem, index);

            // To access this log item easily in the future, add it to the dictionary
            logItemsAtIndices[index] = logItem;
        }

        private void DestroyLogItemsBetweenIndices(int topIndex, int bottomIndex)
        {
            for (var i = topIndex; i <= bottomIndex; i++)
                debugManager.PoolLogItem(logItemsAtIndices[i]);
        }

        private void UpdateLogItemContentsBetweenIndices(int topIndex, int bottomIndex)
        {
            DebugLogItem logItem;
            for (var i = topIndex; i <= bottomIndex; i++)
            {
                logItem = logItemsAtIndices[i];
                logItem.SetContent(collapsedLogEntries[indicesOfEntriesToShow[i]], i, i == indexOfSelectedLogEntry);

                if (isCollapseOn)
                    logItem.ShowCount();
                else
                    logItem.HideCount();
            }
        }

        // Color a log item using its index
        private void ColorLogItem(DebugLogItem logItem, int index)
        {
            if (index == indexOfSelectedLogEntry)
                logItem.Image.color = logItemSelectedColor;
            else if (index % 2 == 0)
                logItem.Image.color = logItemNormalColor1;
            else
                logItem.Image.color = logItemNormalColor2;
        }
#pragma warning disable 0649
        // Cached components
        [SerializeField] private RectTransform transformComponent;

        [SerializeField] private RectTransform viewportTransform;

        [SerializeField] private DebugLogManager debugManager;

        [SerializeField] private Color logItemNormalColor1;

        [SerializeField] private Color logItemNormalColor2;

        [SerializeField] private Color logItemSelectedColor;
#pragma warning restore 0649
    }
}