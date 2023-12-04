using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

/*namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
}*/

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        public Animator animator;

        private bool isOpened;
        private bool isTouching = false;

        void Update()
        {
            // Check for "E" key press to open the chest
            if (!isOpened && Input.GetKeyDown(KeyCode.E) && isTouching)
            {
                Open();
            }
        }

        public void Open()
        {
            isOpened = true;
            animator.SetBool("IsOpened", isOpened);

            // Additional actions when the chest is opened
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isTouching = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // Check if the player is no longer colliding with the box
            if (collision.CompareTag("Player"))
            {
                isTouching = false;
            }
        }
    }
}
