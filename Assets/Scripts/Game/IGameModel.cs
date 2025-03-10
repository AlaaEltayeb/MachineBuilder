using Assets.Scripts.Attachment;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public interface IGameModel
    {
        AttachmentType SelectedAttachmentType { get; }
        Dictionary<AttachmentType, GameObject> Attachments { get; }

        void SetCurrentAttachmentType(AttachmentType attachmentType);
    }
}