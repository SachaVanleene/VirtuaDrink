using UnityEngine;

namespace Assets.Scripts
{
    public class AnimationCrowd : MonoBehaviour
    {

        public string animation = "";
        private string[] names = { "idle", "applause", "applause2", "celebration", "celebration2", "celebration3" };

        // Use this for initialization
        void Start()
        {
            Animation[] AudienceMembers = gameObject.GetComponentsInChildren<Animation>();
            foreach (Animation anim in AudienceMembers)
            {
                string thisAnimation;
                if (string.IsNullOrEmpty(animation))
                    thisAnimation = names[Random.Range(0, 5)];
                else
                    thisAnimation = animation;

                anim.wrapMode = WrapMode.Loop;
                anim.GetComponent<Animation>().CrossFade(thisAnimation);
                anim[thisAnimation].time = Random.Range(0f, 3000f);
            }
        }
    }
}