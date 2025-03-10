using Assets.Scripts.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Assets.Scripts.Game
{
    public sealed class GameModel : IGameModel
    {
        private const string AttachmentLabel = "Attachment";
        public Dictionary<AttachmentType, GameObject> Attachments { get; private set; }

        public AttachmentType SelectedAttachmentType { get; private set; }

        public GameModel()
        {
            LoadAttachmentsGameObjects();
        }

        private void LoadAttachmentsGameObjects()
        {
            Addressables.LoadResourceLocationsAsync(AttachmentLabel, typeof(GameObject)).Completed
                += OnResourceLocationsLoaded;
        }

        private void OnResourceLocationsLoaded(AsyncOperationHandle<IList<IResourceLocation>> handle)
        {
            Addressables
                .LoadAssetsAsync<GameObject>(
                    handle.Result,
                    null)
                .Completed += OnAttachmentGameObjectsLoaded;

            Addressables.Release(handle);
        }

        private void OnAttachmentGameObjectsLoaded(AsyncOperationHandle<IList<GameObject>> handle)
        {
            var attachmentNames = Enum.GetNames(typeof(AttachmentType));

            var attachments = handle.Result.ToList();

            foreach (var attachmentName in attachmentNames)
            {
                var attachmentType = Enum.Parse<AttachmentType>(attachmentName);
                var attachment = attachments.FirstOrDefault(attachment => attachment.name == attachmentName);

                Attachments.Add(attachmentType, attachment);
            }

            Addressables.Release(handle);
        }

        public void SetCurrentAttachmentType(AttachmentType attachmentType)
        {
            SelectedAttachmentType = attachmentType;
        }
    }
}