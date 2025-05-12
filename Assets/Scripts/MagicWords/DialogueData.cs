using System.Collections.Generic;

namespace MagicWords
{
    [System.Serializable]
    public class DialogueData
    {
        public List<DialogueLine> dialogue;
        public List<AvatarData> avatars;
    }

    [System.Serializable]
    public class AvatarData
    {
        public string name;
        public string url;
        public string position;
    }

    [System.Serializable]
    public class DialogueLine
    {
        public string name;
        public string text;
    }
}
