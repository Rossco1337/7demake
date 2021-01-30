using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Manager class for the debug popup
namespace IngameDebugConsole
{
    public class DebugLogPopup : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        // Background image that will change color to indicate an alert
        private Image backgroundImage;

        // Canvas group to modify visibility of the popup
        private CanvasGroup canvasGroup;

        // Dimensions of the popup divided by 2
        private Vector2 halfSize;

        private bool isPopupBeingDragged;

        // Coroutines for simple code-based animations
        private IEnumerator moveToPosCoroutine;

        // Number of new debug entries since the log window has been closed
        private int newInfoCount, newWarningCount, newErrorCount;

        private Color normalColor;
        private RectTransform popupTransform;

        private void Awake()
        {
            popupTransform = (RectTransform) transform;
            backgroundImage = GetComponent<Image>();
            canvasGroup = GetComponent<CanvasGroup>();

            normalColor = backgroundImage.color;
        }

        private void Reset()
        {
            newInfoCount = 0;
            newWarningCount = 0;
            newErrorCount = 0;

            newInfoCountText.text = "0";
            newWarningCountText.text = "0";
            newErrorCountText.text = "0";

            backgroundImage.color = normalColor;
        }

        private void Start()
        {
            halfSize = popupTransform.sizeDelta * 0.5f * popupTransform.root.localScale.x;
        }

        public void OnBeginDrag(PointerEventData data)
        {
            isPopupBeingDragged = true;

            // If a smooth movement animation is in progress, cancel it
            if (moveToPosCoroutine != null)
            {
                StopCoroutine(moveToPosCoroutine);
                moveToPosCoroutine = null;
            }
        }

        // Reposition the popup
        public void OnDrag(PointerEventData data)
        {
            popupTransform.position = data.position;
        }

        // Smoothly translate the popup to the nearest edge
        public void OnEndDrag(PointerEventData data)
        {
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            var pos = popupTransform.position;

            // Find distances to all four edges
            var distToLeft = pos.x;
            var distToRight = Mathf.Abs(pos.x - screenWidth);

            var distToBottom = Mathf.Abs(pos.y);
            var distToTop = Mathf.Abs(pos.y - screenHeight);

            var horDistance = Mathf.Min(distToLeft, distToRight);
            var vertDistance = Mathf.Min(distToBottom, distToTop);

            // Find the nearest edge's coordinates
            if (horDistance < vertDistance)
            {
                if (distToLeft < distToRight)
                    pos = new Vector3(halfSize.x, pos.y, 0f);
                else
                    pos = new Vector3(screenWidth - halfSize.x, pos.y, 0f);

                pos.y = Mathf.Clamp(pos.y, halfSize.y, screenHeight - halfSize.y);
            }
            else
            {
                if (distToBottom < distToTop)
                    pos = new Vector3(pos.x, halfSize.y, 0f);
                else
                    pos = new Vector3(pos.x, screenHeight - halfSize.y, 0f);

                pos.x = Mathf.Clamp(pos.x, halfSize.x, screenWidth - halfSize.x);
            }

            // If another smooth movement animation is in progress, cancel it
            if (moveToPosCoroutine != null)
                StopCoroutine(moveToPosCoroutine);

            // Smoothly translate the popup to the specified position
            moveToPosCoroutine = MoveToPosAnimation(pos);
            StartCoroutine(moveToPosCoroutine);

            isPopupBeingDragged = false;
        }

        // Popup is clicked
        public void OnPointerClick(PointerEventData data)
        {
            // Hide the popup and show the log window
            if (!isPopupBeingDragged)
                debugManager.ShowLogWindow();
        }

        public void OnViewportDimensionsChanged()
        {
            if (!gameObject.activeSelf)
                return;

            halfSize = popupTransform.sizeDelta * 0.5f * popupTransform.root.localScale.x;
            OnEndDrag(null);
        }

        public void NewInfoLogArrived()
        {
            newInfoCount++;
            newInfoCountText.text = newInfoCount.ToString();

            if (newWarningCount == 0 && newErrorCount == 0)
                backgroundImage.color = alertColorInfo;
        }

        public void NewWarningLogArrived()
        {
            newWarningCount++;
            newWarningCountText.text = newWarningCount.ToString();

            if (newErrorCount == 0)
                backgroundImage.color = alertColorWarning;
        }

        public void NewErrorLogArrived()
        {
            newErrorCount++;
            newErrorCountText.text = newErrorCount.ToString();

            backgroundImage.color = alertColorError;
        }

        // A simple smooth movement animation
        private IEnumerator MoveToPosAnimation(Vector3 targetPos)
        {
            var modifier = 0f;
            var initialPos = popupTransform.position;

            while (modifier < 1f)
            {
                modifier += 4f * Time.unscaledDeltaTime;
                popupTransform.position = Vector3.Lerp(initialPos, targetPos, modifier);

                yield return null;
            }
        }

        // Hides the log window and shows the popup
        public void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;

            // Reset the counters
            Reset();

            // Update position in case resolution changed while hidden
            OnViewportDimensionsChanged();
        }

        // Hide the popup
        public void Hide()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;

            isPopupBeingDragged = false;
        }

#pragma warning disable 0649
        [SerializeField] private DebugLogManager debugManager;

        [SerializeField] private Text newInfoCountText;

        [SerializeField] private Text newWarningCountText;

        [SerializeField] private Text newErrorCountText;

        [SerializeField] private Color alertColorInfo;

        [SerializeField] private Color alertColorWarning;

        [SerializeField] private Color alertColorError;
#pragma warning restore 0649
    }
}